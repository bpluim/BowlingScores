# Bowling Score Calculator

This is a simple C# program that calculates the total score for a given set of bowling frames.

## Usage

1. Clone the repository to your local machine:

```bash
git clone https://github.com/bpluim/BowlingScores.git
```

2. Open the project in your preferred C# development environment (e.g., Visual Studio, Visual Studio Code).

3. Run the program and enter bowling scores in JSON format when prompted.

# Input Format
The program expects input in JSON format, where each frame is represented by an array of integers:

```
{
  "frames": [
    {"bowls": [int, int]},  // Frame 1
    {"bowls": [int, int]},  // Frame 2
    // ... (repeat for all 10 frames)
    {"bowls": [int, int, int]}  // Frame 10 (for the 10th frame, up to 3 bowls are allowed)
  ]
}
```

Frames 1-9 can have 1 or 2 bowls. Frame 10 can have a maximum of 3 bowls.
The number of pins knocked down in each bowl should be represented by an integer.
Strikes are represented as a frame with a single bowl containing 10 pins.
Spares are represented as a frame with two bowls whose sum is 10.

# Example Input

```
{
  "frames": [
    {"bowls": [10]},  // Strike
    {"bowls": [7, 3]},  // Spare
    {"bowls": [9, 0]},  // Open frame
    {"bowls": [10]},  // Strike
    {"bowls": [0, 8]},  // Open frame
    {"bowls": [8, 2]},  // Spare
    {"bowls": [3, 6]},  // Open frame
    {"bowls": [6, 2]},  // Open frame
    {"bowls": [10]},  // Strike
    {"bowls": [9, 0, 10]}  // Spare with an extra bowl for the 10th frame
  ]
}
```

# Error Handling
The program includes error handling to ensure valid input. If an error occurs, an error message will be displayed.

Incomplete game (less than 10 frames)
Invalid number of bowls in a frame
Invalid number of pins knocked down

Feel free to contribute or report issues if you encounter any problems!
