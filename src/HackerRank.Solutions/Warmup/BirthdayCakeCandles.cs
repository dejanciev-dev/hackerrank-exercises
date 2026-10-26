namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Birthday Cake Candles — count how many candles are the tallest.
/// https://www.hackerrank.com/challenges/birthday-cake-candles
/// </summary>
public static class BirthdayCakeCandles
{
    public static int Solve(IReadOnlyList<int> candles)
    {
        int tallest = 0;
        int count = 0;

        foreach (var candle in candles)
        {
            if (candle > tallest)
            {
                tallest = candle;
                count = 1;
            }
            else if (candle == tallest)
            {
                count++;
            }
        }

        return count;
    }
}
