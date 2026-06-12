function explanation_lines = explain_from_cleaned_file(input_indices, output_indices)
    explanation_lines = {};
    txt_file = 'expln_rules_cleaned_final.txt';
    if ~exist(txt_file, 'file')
        return;
    end

    fid = fopen(txt_file, 'r');
    lines = textscan(fid, '%s', 'Delimiter', '\n');
    fclose(fid);
    lines = lines{1};

    best_score = 0;
    best_explanation = {};

    for i = 1:length(lines)
        line = strtrim(lines{i});
        if ~isempty(strfind(line, '->'))
            parts = strsplit(line, '->');
            if length(parts) ~= 2
                continue;
            end
            rule_in = strtrim(parts{1});
            rule_out = strtrim(parts{2});
            rule_in_vec = sscanf(rule_in, '%d')';
            rule_out_vec = sscanf(rule_out, '%d')';

            if length(rule_in_vec) ~= length(input_indices) || length(rule_out_vec) ~= length(output_indices)
                continue;
            end

            in_match = sum(rule_in_vec == input_indices);
            out_match = sum(rule_out_vec == output_indices);
            score = in_match + out_match;

            if score > best_score
                best_score = score;
                best_explanation = {};
                j = i + 1;
                while j <= length(lines)
                    l = strtrim(lines{j});
                    if ~isempty(strfind(l, '->')) || strncmpi(l, 'rule', 4)
                        break;
                    end
                    best_explanation{end+1} = l;
                    j = j + 1;
                end
            end
        end
    end

    explanation_lines = best_explanation;
end
