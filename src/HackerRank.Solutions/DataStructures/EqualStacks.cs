namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Equal Stacks — remove cylinders from the tops of three stacks (index 0 is the top) until
/// all have the same height; return that maximum common height.
/// https://www.hackerrank.com/challenges/equal-stacks
/// </summary>
public static class EqualStacks
{
    public static int Solve(IReadOnlyList<int> h1, IReadOnlyList<int> h2, IReadOnlyList<int> h3)
    {
        IReadOnlyList<int>[] stacks = [h1, h2, h3];
        var heights = stacks.Select(stack => stack.Sum()).ToArray();
        var tops = new int[3];

        while (heights[0] != heights[1] || heights[1] != heights[2])
        {
            // Always shrink the tallest stack.
            int tallest = Array.IndexOf(heights, heights.Max());
            heights[tallest] -= stacks[tallest][tops[tallest]++];
        }

        return heights[0];
    }
}
