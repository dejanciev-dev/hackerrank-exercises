namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Bowling Pins — players knock down one pin or two adjacent pins ('I' standing, 'X' down);
/// whoever takes the last pin wins. Each run of standing pins is an independent game, and
/// knocking pins out of a run of length L leaves two runs a and b with a + b = L - 1 or
/// L - 2. Sprague–Grundy: XOR the runs' Grundy numbers.
/// https://www.hackerrank.com/challenges/bowling-pins
/// </summary>
public static class BowlingPins
{
    private const int MaxPins = 300;
    private static readonly int[] Grundy = BuildGrundy(MaxPins);

    public static string Solve(string config)
    {
        int nimSum = 0;
        foreach (var run in config.Split('X', StringSplitOptions.RemoveEmptyEntries))
        {
            nimSum ^= Grundy[run.Length];
        }

        return nimSum != 0 ? "WIN" : "LOSE";
    }

    private static int[] BuildGrundy(int max)
    {
        var grundy = new int[max + 1];

        for (int length = 1; length <= max; length++)
        {
            var reachable = new HashSet<int>();
            for (int taken = 1; taken <= 2 && taken <= length; taken++)
            {
                for (int left = 0; left <= length - taken; left++)
                {
                    reachable.Add(grundy[left] ^ grundy[length - taken - left]);
                }
            }

            int mex = 0;
            while (reachable.Contains(mex))
            {
                mex++;
            }

            grundy[length] = mex;
        }

        return grundy;
    }
}
