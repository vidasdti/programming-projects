
function test_explain_from_cleaned_file()
    input_vector = [0 2 2 2 2 1 0 0 2 0];
    output_vector = [3 2 1 1 0 1];

    explanation = explain_from_cleaned_file(input_vector, output_vector);

    if isempty(explanation)
        fprintf('â?Œ No explanation found for the given rule.\n');
    else
        fprintf('âœ… Explanation found:\n');
        for i = 1:length(explanation)
            fprintf('%s\n', explanation{i});
        end
    end
end
