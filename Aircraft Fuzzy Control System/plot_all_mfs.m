% plot_all_mfs_full.m
% This script loads a FIS file, and plots all membership functions (MFs)
% for both inputs and outputs. Each plot is saved as a PNG image.

% Load the fuzzy inference system (FIS)
fis = readfis('plane_approach.fis');

% Create output folder for plots if it doesn't exist
outputFolder = 'mf_plots';
if ~exist(outputFolder, 'dir')
    mkdir(outputFolder);
end

% Helper function to beautify variable/membership function names
% Converts underscore to space and capitalizes first letter of each word
beautify = @(s) regexprep(regexprep(strrep(s, '_', ' '), '(^| )([a-z])', '${upper($2)}'), '\s+', ' ');

% --------------------------- INPUT MEMBERSHIP FUNCTIONS ---------------------------
for i = 1:length(fis.input)
    % Create a new (invisible) figure for each input variable
    fig = figure('Visible', 'off');

    % Get x and y values of all MFs for input i
    [x, y] = plotmf(fis, 'input', i);

    % Plot all membership functions with thick lines
    plot(x, y, 'LineWidth', 2); hold on;

    % Adjust y-axis limit to add some vertical space for labels
    ymax = max(y(:));
    ylim([0, ymax + 0.2]);

    % Extract MF names and beautify them
    mfs = fis.input(i).mf;
    mf_names = cell(1, length(mfs));
    for j = 1:length(mfs)
        if isfield(mfs(j), 'label')
            mf_names{j} = beautify(mfs(j).label);
        elseif isfield(mfs(j), 'name')
            mf_names{j} = beautify(mfs(j).name);
        else
            mf_names{j} = ['MF ' num2str(j)];
        end
    end

    % Assign distinct colors for each MF
    colors = lines(length(mf_names));

    % Annotate each MF curve with its name at the peak point
    for j = 1:length(mf_names)
        [peak_val, idx] = max(y(:,j));
        x_peak = x(idx);
        y_peak = peak_val;
        text(x_peak, y_peak + 0.07, mf_names{j}, ...
            'HorizontalAlignment', 'center', ...
            'FontWeight', 'normal', ...
            'FontSize', 10, ...
            'Color', colors(j,:));
    end

    % Set title and axis labels using beautified input name
    varName = beautify(fis.input(i).name);
    title(['Input ' num2str(i) ': ' varName], 'FontWeight', 'bold', 'FontSize', 14);
    xlabel(varName, 'FontWeight', 'bold', 'FontSize', 12);
    ylabel('Degree of Membership', 'FontWeight', 'bold', 'FontSize', 12);
    set(gca, 'FontSize', 10, 'FontWeight', 'bold');

    % Save the figure as PNG in the output folder
    saveas(fig, fullfile(outputFolder, ['input' num2str(i) '_' fis.input(i).name '.png']));

    % Close the figure to avoid clutter
    close(fig);
end

% --------------------------- OUTPUT MEMBERSHIP FUNCTIONS ---------------------------
for i = 1:length(fis.output)
    % Create a new (invisible) figure for each output variable
    fig = figure('Visible', 'off');

    % Get x and y values of all MFs for output i
    [x, y] = plotmf(fis, 'output', i);

    % Plot all membership functions with thick lines
    plot(x, y, 'LineWidth', 2); hold on;

    % Adjust y-axis limit to add vertical space for labels
    ymax = max(y(:));
    ylim([0, ymax + 0.2]);

    % Extract MF names and beautify them
    mfs = fis.output(i).mf;
    mf_names = cell(1, length(mfs));
    for j = 1:length(mfs)
        if isfield(mfs(j), 'label')
            mf_names{j} = beautify(mfs(j).label);
        elseif isfield(mfs(j), 'name')
            mf_names{j} = beautify(mfs(j).name);
        else
            mf_names{j} = ['MF ' num2str(j)];
        end
    end

    % Assign distinct colors for each MF
    colors = lines(length(mf_names));

    % Annotate each MF curve with its name at the peak point
    for j = 1:length(mf_names)
        [peak_val, idx] = max(y(:,j));
        x_peak = x(idx);
        y_peak = peak_val;
        text(x_peak, y_peak + 0.07, mf_names{j}, ...
            'HorizontalAlignment', 'center', ...
            'FontWeight', 'normal', ...
            'FontSize', 10, ...
            'Color', colors(j,:));
    end

    % Set title and axis labels using beautified output name
    varName = beautify(fis.output(i).name);
    title(['Output ' num2str(i) ': ' varName], 'FontWeight', 'bold', 'FontSize', 14);
    xlabel(varName, 'FontWeight', 'bold', 'FontSize', 12);
    ylabel('Degree of Membership', 'FontWeight', 'bold', 'FontSize', 12);
    set(gca, 'FontSize', 10, 'FontWeight', 'bold');

    % Save the figure as PNG in the output folder
    saveas(fig, fullfile(outputFolder, ['output' num2str(i) '_' fis.output(i).name '.png']));

    % Close the figure to free memory
    close(fig);
end
