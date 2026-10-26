namespace HackerRank.Solutions.Strings;

/// <summary>
/// Bear and Steady Gene — a gene is steady when each of A, C, G, T appears exactly n/4 times.
/// Return the length of the shortest substring to replace to make it steady. A sliding
/// window works because a window is valid once no letter outside it exceeds n/4. O(n).
/// https://www.hackerrank.com/challenges/bear-and-steady-gene
/// </summary>
public static class BearAndSteadyGene
{
    public static int Solve(string gene)
    {
        int target = gene.Length / 4;
        var outside = new Dictionary<char, int> { ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };
        foreach (var c in gene)
        {
            outside[c]++;
        }

        if (outside.Values.All(count => count <= target))
        {
            return 0;
        }

        int best = gene.Length;
        int left = 0;

        for (int right = 0; right < gene.Length; right++)
        {
            outside[gene[right]]--;

            while (left <= right && outside.Values.All(count => count <= target))
            {
                best = Math.Min(best, right - left + 1);
                outside[gene[left]]++;
                left++;
            }
        }

        return best;
    }
}
