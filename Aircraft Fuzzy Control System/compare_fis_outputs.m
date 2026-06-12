% compare_fis_outputs.m
clear; clc;

% ????? ????? ???
inputs = [2, 150, 5000, 10, 500, 1, 50, 200, 1];

% ??? ??????? ? ?????? ?????
fis_files = {
    'plane_takeoff.fis', ...
    'plane_climb.fis', ...
    'plane_cruise.fis', ...
    'plane_approach.fis', ...
    'plane_landing.fis'};

flight_phases = {
    'Takeoff', ...
    'Climb', ...
    'Cruise', ...
    'Approach', ...
    'Landing'};

fprintf('Input Vector:\n');
disp(inputs);

fprintf('\nComparing FIS Outputs Across Flight Phases:\n');
fprintf('--------------------------------------------\n');

for i = 1:length(fis_files)
    % ??????? ????
    fisObj = readfis(fis_files{i});

    % ??? object-based ???? ?? struct ????? ??
    if isa(fisObj, 'mamfis') || isa(fisObj, 'sugfis')
        fis = convertToLegacyFIS(fisObj);
    else
        fis = fisObj;
    end

    % ?????? ?????
    output = evalfis(fis, inputs);

    fprintf('\n--- %s Phase ---\n', flight_phases{i});
    for j = 1:length(output)
        fprintf('Output %d: %.3f\n', j, output(j));
    end
end
