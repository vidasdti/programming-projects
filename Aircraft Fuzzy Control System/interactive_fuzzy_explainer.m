function interactive_fuzzy_explainer()
    phases = {'takeoff','climb','cruise','approach','landing'};
    fprintf('--- Flight Phases ---\n');
    for i = 1:length(phases)
        fprintf('%d = %s\n', i-1, phases{i});
    end

    phase_index = input('\nSelect flight_phase (0-4): ');
    while phase_index < 0 || phase_index > 4
        phase_index = input('Invalid. Please enter a number between 0 and 4: ');
    end
    selected_phase = phases{phase_index + 1};
    fis_file = ['plane_' selected_phase '.fis'];
    fprintf('\nLoading fuzzy system for "%s" phase...\n', selected_phase);

    fis = readfis(fis_file);
    num_inputs = length(fis.input);
    input_values = zeros(1, num_inputs);
    input_labels = cell(1, num_inputs);
    input_degrees = zeros(1, num_inputs);

    % Prepare log
    timestamp = datestr(now, 'yyyy_mm_dd_HH_MM_SS');
    if ~exist('logs', 'dir')
        mkdir('logs');
    end
    logfile = fullfile('logs', ['log_' timestamp '.txt']);
    fid = fopen(logfile, 'w');

    fprintf(fid, 'Flight Phase: %s\n', upper(selected_phase));
    fprintf(fid, '==========================================\n');

    fprintf('\n--- Input Data Entry ---\n');
    fprintf(fid, '\n--- Input Data Entry ---\n');
    for i = 1:num_inputs
        var = fis.input(i);
        min_val = var.range(1);
        max_val = var.range(2);
        valid = false;
        while ~valid
            fprintf('\nInput %d: %s [%.2f to %.2f]\n', i, var.name, min_val, max_val);
            val = input(sprintf('Enter value for %s: ', var.name));
            if val < min_val || val > max_val
                fprintf(' Value %.2f is out of range!\n', val);
            else
                valid = true;
                input_values(i) = val;
            end
        end
    end

    % --- Input Memberships ---
    fprintf('\n+-----------------------------+----------+--------------------------+----------+\n');
    fprintf('|         Input Name          |  Value   |           Label          | Degree   |\n');
    fprintf('+-----------------------------+----------+--------------------------+----------+\n');
    fprintf(fid, '\n+-----------------------------+----------+--------------------------+----------+\n');
    fprintf(fid, '|         Input Name          |  Value   |           Label          | Degree   |\n');
    fprintf(fid, '+-----------------------------+----------+--------------------------+----------+\n');
    for i = 1:num_inputs
        var = fis.input(i);
        val = input_values(i);
        [lbl, deg] = get_best_label_legacy(val, var);
        input_labels{i} = lbl;
        input_degrees(i) = deg;
        fprintf('| %-27s | %8.2f | %-24s | %8.2f |\n', var.name, val, lbl, deg);
        fprintf(fid, '| %-27s | %8.2f | %-24s | %8.2f |\n', var.name, val, lbl, deg);
    end
    fprintf('+-----------------------------+----------+--------------------------+----------+\n');
    fprintf(fid, '+-----------------------------+----------+--------------------------+----------+\n');

    % Evaluate or override outputs
    is_fail = check_fail_safe(input_values);
    fail_safe_triggered = false;

    if is_fail
        output_values = [100, -20, 0, 1, 0, 1];
        output_labels = {'max', 'down', 'manual', 'warning', 'emergency_diversion', 'override_manual'};
        output_degrees = ones(1, length(output_values));
        fail_safe_triggered = true;
    else
        output_values = evalfis(input_values, fis);
        output_labels = cell(1, length(fis.output));
        output_degrees = zeros(1, length(fis.output));
        for i = 1:length(fis.output)
            [lbl, deg] = get_best_label_legacy(output_values(i), fis.output(i));
            output_labels{i} = lbl;
            output_degrees(i) = deg;
        end
    end

    % --- Output Memberships ---
    fprintf('\n+-----------------------------+----------+--------------------------+----------+\n');
    fprintf('|        Output Name          |  Value   |           Label          | Degree   |\n');
    fprintf('+-----------------------------+----------+--------------------------+----------+\n');
    fprintf(fid, '\n+-----------------------------+----------+--------------------------+----------+\n');
    fprintf(fid, '|        Output Name          |  Value   |           Label          | Degree   |\n');
    fprintf(fid, '+-----------------------------+----------+--------------------------+----------+\n');
    for i = 1:length(output_values)
        if i <= length(fis.output)
            name = fis.output(i).name;
        else
            name = sprintf('Output %d', i);
        end
        fprintf('| %-27s | %8.2f | %-24s | %8.2f |\n', name, output_values(i), output_labels{i}, output_degrees(i));
        fprintf(fid, '| %-27s | %8.2f | %-24s | %8.2f |\n', name, output_values(i), output_labels{i}, output_degrees(i));
    end
    fprintf('+-----------------------------+----------+--------------------------+----------+\n');
    fprintf(fid, '+-----------------------------+----------+--------------------------+----------+\n');

    % Prepare explanation
    in_indices = zeros(1, num_inputs);
    for j = 1:num_inputs
        idx = find(strcmp({fis.input(j).mf.name}, input_labels{j}));
        in_indices(j) = max(idx - 1, 0);
    end

    out_indices = zeros(1, length(output_labels));
    for j = 1:length(output_labels)
        if j <= length(fis.output)
            idx = find(strcmp({fis.output(j).mf.name}, output_labels{j}));
            out_indices(j) = max(idx - 1, 0);
        else
            out_indices(j) = 0;
        end
    end

    explanation_lines = explain_from_cleaned_file(in_indices, out_indices);
    if ~isempty(explanation_lines)
        fprintf('\n Explanation from expln_rules_cleaned_final.txt:\n');
        fprintf(' -------------------------------------------------\n');
        fprintf(fid, '\n Explanation from expln_rules_cleaned_final.txt:\n');
        fprintf(fid, ' -------------------------------------------------\n');
        for k = 1:length(explanation_lines)
            fprintf('  %s\n', explanation_lines{k});
            fprintf(fid, '  %s\n', explanation_lines{k});
        end
        fprintf(' -------------------------------------------------\n');
        fprintf(fid, ' -------------------------------------------------\n');
    else
        fprintf('\n No exact explanation match found.\n');
        fprintf(fid, '\n No exact explanation match found.\n');
    end

    % Contributing inputs
    fprintf('\n Main contributing factors (Degree >= 0.85):\n');
    fprintf(fid, '\n Main contributing factors (Degree >= 0.85):\n');
    for i = 1:num_inputs
        if input_degrees(i) >= 0.85
            fprintf(' - %-24s = %.2f (%s)\n', fis.input(i).name, input_values(i), input_labels{i});
            fprintf(fid, ' - %-24s = %.2f (%s)\n', fis.input(i).name, input_values(i), input_labels{i});
        end
    end

    % Fail-safe warning block
    if fail_safe_triggered
        block_lines = {
            '==========================================================='
            '|                   FAIL-SAFE MODE ACTIVATED              |'
            '|---------------------------------------------------------|'
            '| A critical condition was detected.                      |'
            '| Emergency control outputs were issued.                  |'
            '| Fuzzy logic system was overridden for safety response.  |'
            '==========================================================='
        };
        fprintf('\n'); fprintf(fid, '\n');
        for k = 1:length(block_lines)
            fprintf('%s\n', block_lines{k});
            fprintf(fid, '%s\n', block_lines{k});
        end
    end

    fprintf('\n Analysis complete.\n');
    fprintf(fid, '\n Analysis complete.\n');
    fclose(fid);
end

function [label, deg] = get_best_label_legacy(val, var)
    label = ''; deg = 0;
    for j = 1:length(var.mf)
        mf = var.mf(j);
        d = evalmf(val, mf.params, mf.type);
        if d > deg
            deg = d;
            label = mf.name;
        end
    end
end

function is_fail_safe = check_fail_safe(inputs)
    turb = inputs(1);
    airspeed = inputs(2);
    pitch = inputs(4);
    engine = inputs(6);
    fuel = inputs(7);
    proximity = inputs(8);
    tcas = inputs(9);

    cond1 = (airspeed < 100) && (pitch > 10);
    cond2 = (fuel < 10) && (engine < 1);
    cond3 = (proximity < 150) && (tcas >= 2);
    cond4 = (turb > 2.5);

    is_fail_safe = cond1 || cond2 || cond3 || cond4;
end
