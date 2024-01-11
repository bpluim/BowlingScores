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
