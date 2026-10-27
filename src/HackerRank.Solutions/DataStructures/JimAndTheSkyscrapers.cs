namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Jim and the Skyscrapers — count ordered pairs of equal-height skyscrapers with no taller
/// one between them. A decreasing stack of (height, count): shorter buildings are popped
/// because they can never pair past a taller one, and each new building pairs with every
/// equal one still on the stack. O(n); doubled for both directions.
/// https://www.hackerrank.com/challenges/jim-and-the-skyscrapers
/// </summary>
public static class JimAndTheSkyscrapers
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        var stack = new Stack<(int Height, long Count)>();
        long pairs = 0;

        foreach (var height in arr)
        {
            while (stack.Count > 0 && stack.Peek().Height < height)
            {
                stack.Pop();
            }

            if (stack.Count > 0 && stack.Peek().Height == height)
            {
                var (_, count) = stack.Pop();
                pairs += count;
                stack.Push((height, count + 1));
            }
            else
            {
                stack.Push((height, 1));
            }
        }

        return pairs * 2;
    }
}
