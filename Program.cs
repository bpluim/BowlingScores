using Newtonsoft.Json.Linq;

class BowlingScoreCalculator
{
    static void Main()
    {
        Console.WriteLine("Enter bowling scores in JSON format. Enter an empty line to exit.");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break; // Exit the program if an empty line is entered
            }

            try
            {
                JToken jsonData = JToken.Parse(input);
                ValidateInput(jsonData);
                int totalScore = CalculateTotalScore(jsonData);
                Console.WriteLine($"Total Score: {totalScore}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void ValidateInput(JToken jsonData)
    {
        if (jsonData["frames"] == null)
        {
            throw new ArgumentException("Invalid input. Missing 'frames' property.");
        }

        var frames = jsonData["frames"].Select(frame => frame["bowls"].ToObject<int[]>());

        if (frames.Count() < 10)
        {
            throw new ArgumentException("Invalid input. Incomplete game. There should be 10 frames.");
        }

        foreach (var frame in frames)
        {
            if (frame.Length < 1 || frame.Length > 3)
            {
                throw new ArgumentException($"Invalid input. Frame has an invalid number of bowls. Frame: {string.Join(", ", frame)}");
            }

            if (frame.Any(pins => pins < 0 || pins > 10))
            {
                throw new ArgumentException($"Invalid input. Frame contains an invalid number of pins. Frame: {string.Join(", ", frame)}");
            }

            if (frame.Length == 1 && frame[0] != 10)
            {
                throw new ArgumentException($"Invalid input. Frame has an invalid number of bowls. Frame: {string.Join(", ", frame)}");
            }

            if (frame.Length == 3 && frame[0] != 10 && frame[0] + frame[1] != 10)
            {
                throw new ArgumentException($"Invalid input. Frame has an invalid number of bowls. Frame: {string.Join(", ", frame)}");
            }
        }
    }

    static int CalculateTotalScore(JToken jsonData)
    {
        if (jsonData["frames"] == null)
        {
            throw new ArgumentException("Invalid input. Missing 'frames' property.");
        }

        var frames = jsonData["frames"].Select(frame => frame["bowls"].ToObject<int[]>());

        int totalScore = 0;
        int frameIndex = 0;

        foreach (var frame in frames)
        {
            totalScore += CalculateFrameScore(frame, frames, frameIndex);
            frameIndex++;
        }

        return totalScore;
    }

    static int CalculateFrameScore(int[] frame, IEnumerable<int[]> frames, int frameIndex)
    {
        int frameScore = frame.Sum();

        if (IsStrike(frame))
        {
            frameScore += GetStrikeBonus(frames, frameIndex);
        }
        else if (IsSpare(frame))
        {
            frameScore += GetSpareBonus(frames, frameIndex);
        }

        return frameScore;
    }

    static bool IsStrike(int[] frame) => frame.Length == 1 && frame[0] == 10;

    static bool IsSpare(int[] frame) => frame.Length == 2 && frame.Sum() == 10;

    static int GetStrikeBonus(IEnumerable<int[]> frames, int frameIndex)
    {
        var nextFrame = frames.ElementAt(frameIndex + 1);

        // If the next frame is the last frame, only add its own value
        if (frameIndex == 8)
        {
            return nextFrame.Take(2).Sum();
        }

        return 10 + nextFrame.Sum();
    }

    static int GetSpareBonus(IEnumerable<int[]> frames, int frameIndex)
    {
        var nextFrame = frames.ElementAt(frameIndex + 1);

        // If the next frame is the last frame, only add its own value
        if (frameIndex == 8)
        {
            return nextFrame[0];
        }

        return nextFrame[0];
    }
}
