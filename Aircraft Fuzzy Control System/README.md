# ✈️ Aircraft Fuzzy Control System

A MATLAB-based fuzzy logic control system designed to simulate aircraft decision-making across different phases of flight.

The project uses multiple Mamdani Fuzzy Inference Systems (FIS) to evaluate flight conditions and generate control actions using expert-defined fuzzy rules. The system also includes an explanation engine, automatic logging, membership function visualization, and emergency fail-safe logic for safety-critical situations.

---

## Features

- Five dedicated flight-phase fuzzy controllers
  - Takeoff
  - Climb
  - Cruise
  - Approach
  - Landing
- Mamdani Fuzzy Inference System (FIS)
- Explainable decision-making engine
- Automatic simulation logging
- Membership function visualization
- Emergency fail-safe override mechanism
- Flight-phase output comparison utility
- Modular MATLAB implementation

---

## Main Components

### Fuzzy Controllers

Each flight phase is modeled using a dedicated fuzzy controller:

```text
plane_takeoff.fis
plane_climb.fis
plane_cruise.fis
plane_approach.fis
plane_landing.fis
```

### Main Application

The primary entry point of the project is:

```text
interactive_fuzzy_explainer.m
```

This script allows users to:

- Select a flight phase
- Enter flight parameters interactively
- Execute the fuzzy controller
- Generate human-readable explanations
- Trigger fail-safe protection when required
- Store simulation results in log files

---

## Input Variables

The controllers evaluate the following flight parameters:

- Turbulence
- Air Speed
- Altitude
- Pitch Angle
- Vertical Speed
- Engine Health
- Fuel Status
- Proximity to Obstacles
- TCAS Conflict Level

---

## Output Variables

The system generates the following control recommendations:

- Thrust Command
- Elevator Deflection
- Autopilot Mode Suggestion
- Stall Warning
- Fuel Reserve Command
- Stress Reduction Aid

---

## Logging System

Every simulation run automatically generates a detailed log file containing:

- Flight phase information
- Input values and fuzzy labels
- Membership degrees
- Output decisions
- Rule explanations
- Main contributing factors
- Fail-safe activation status

Generated logs are stored in:

```text
logs/
```

---

## Membership Function Visualization

Plots for all membership functions are available in:

```text
mf_plots/
```

These visualizations provide insight into the fuzzy partitions and linguistic variables used throughout the controllers.

---

## Fail-Safe Logic

For safety-critical situations, the system can bypass normal fuzzy inference and activate predefined emergency responses.

Examples include:

- Stall risk detection
- Severe turbulence
- Low fuel with engine degradation
- Potential collision scenarios

When triggered, emergency control commands are issued immediately to ensure aircraft safety.

---

## Additional Utilities

### Compare FIS Outputs

```text
compare_fis_outputs.m
```

Evaluates the same input vector across all five flight-phase controllers and compares their outputs.

### Fail-Safe Detection

```text
check_fail_safe.m
```

Monitors critical flight conditions and determines whether emergency override actions should be activated.

---

## Project Structure

```text
Aircraft-Fuzzy-Control-System/
│
├── plane_takeoff.fis
├── plane_climb.fis
├── plane_cruise.fis
├── plane_approach.fis
├── plane_landing.fis
│
├── interactive_fuzzy_explainer.m
├── explain_from_cleaned_file.m
├── compare_fis_outputs.m
├── check_fail_safe.m
│
├── expln_rules_cleaned_final.txt
│
├── logs/
├── mf_plots/
│
└── Aircraft Fuzzy Control System.pdf
```

---

## Requirements

- MATLAB
- Fuzzy Logic Toolbox

---

## Documentation

For a complete description of the system architecture, fuzzy variables, membership functions, rule base, fail-safe logic, implementation details, and example scenarios, please refer to:

📄 **Aircraft Fuzzy Control System.pdf**

---

## License

This project is licensed under the MIT License.

