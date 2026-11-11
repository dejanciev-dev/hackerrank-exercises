namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Help Mike — count the pairs 1 ≤ i &lt; j ≤ n with (i + j) divisible by k, for n, k up to 10^9.
/// Residue r occurs q = ⌊n / k⌋ times, plus once more when 1 ≤ r ≤ n mod k. Pairs come from
/// residues r and k − r, so sum cnt[r] · cnt[k − r] in closed form and fix up the self-paired
/// residues 0 and k / 2. O(1).
/// https://www.hackerrank.com/challenges/help-mike
/// </summary>
public static class HelpMike
{
    public static long Solve(long n, long k)
    {
        long q = n / k, rem = n % k;

        // Σ_{r=1}^{k-1} cnt[r] · cnt[k-r]: each factor is q plus an indicator; the indicators
        // are r ≤ rem and r ≥ k − rem, which overlap on max(0, 2·rem − k + 1) residues.
        long cross = (k - 1) * q * q + 2 * q * rem + Math.Max(0, 2 * rem - k + 1);

        long pairs = q * (q - 1) / 2;
        if (k % 2 == 0)
        {
            long half = q + (k / 2 <= rem ? 1 : 0);
            cross -= half * half;
            pairs += half * (half - 1) / 2;
        }

        return pairs + cross / 2;
    }
}
