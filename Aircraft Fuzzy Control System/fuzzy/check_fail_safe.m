function is_fail_safe = check_fail_safe(inputs)
% inputs = [turbulence, air_speed, altitude, pitch_angle, vertical_speed,
%           engine_health, fuel_status, proximity_to_obstacles, tcas_conflict_level]

turb        = inputs(1);
airspeed    = inputs(2);
pitch       = inputs(4);
engine      = inputs(6);
fuel        = inputs(7);
proximity   = inputs(8);
tcas        = inputs(9);

% Define fail-safe conditions
cond1 = (airspeed < 100) && (pitch > 10);   % Stall risk
cond2 = (fuel < 10) && (engine < 1);        % Engine + fuel failure
cond3 = (proximity < 150) && (tcas >= 2);   % Collision risk
cond4 = (turb > 2.5);                       % Severe turbulence

is_fail_safe = cond1 || cond2 || cond3 || cond4;
end
