namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Plus Minus — ratios of positive, negative and zero elements, each with six decimal places.
/// https://www.hackerrank.com/challenges/plus-minus
/// </summary>
public static class PlusMinus
{
    public static string[] Solve(IReadOnlyList<int> arr)
    {
        int positive = 0, negative = 0, zero = 0;

        foreach (var value in arr)
        {
            if (value > 0) positive++;
            else if (value < 0) negative++;
            else zero++;
        }

        double n = arr.Count;
        return
        [
            Format(positive / n),
            Format(negative / n),
            Format(zero / n),
        ];
    }

    private static string Format(double ratio) =>
        ratio.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
}
