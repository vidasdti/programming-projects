function output = fuzzy_phase_selector(input)
% input: 1x10 vector representing system inputs
% output: 1x6 vector representing system outputs

% Round the 7th input to identify the flight phase
phase = round(input(7));

% Select the correct FIS file
switch phase
    case 0
        fisFile = 'C:\Users\Hp\Desktop\MATLAB2\plane_takeoff.fis';
    case 1
        fisFile = 'C:\Users\Hp\Desktop\MATLAB2\plane_climb.fis';
    case 2
        fisFile = 'C:\Users\Hp\Desktop\MATLAB2\plane_cruise.fis';
    case 3
        fisFile = 'C:\Users\Hp\Desktop\MATLAB2\plane_approach.fis';
    case 4
        fisFile = 'C:\Users\Hp\Desktop\MATLAB2\plane_landing.fis';
    otherwise
        error('Invalid flight phase. Must be 0–4.');
end

if exist(fisFile, 'file') ~= 2
    error(['FIS file not found: ' fisFile]);
end
% Load the selected FIS
fis = readfis(fisFile);

% Evaluate the fuzzy system
output = evalfis(input, fis);

% Display the output
disp(['Selected FIS: ' fisFile]);
disp('Input:');
disp(input);
disp('Output:');
disp(output);
end
