namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Maximum Element — handle "1 x" (push), "2" (pop) and "3" (print the maximum) on a stack.
/// Storing the running maximum alongside each element makes every operation O(1).
/// https://www.hackerrank.com/challenges/maximum-element
/// </summary>
public static class MaximumElement
{
    public static int[] Solve(IReadOnlyList<string> operations)
    {
        var maxima = new Stack<int>();
        var printed = new List<int>();

        foreach (var operation in operations)
        {
            var parts = operation.Split(' ');

            switch (parts[0])
            {
                case "1":
                    int value = int.Parse(parts[1]);
                    maxima.Push(maxima.Count == 0 ? value : Math.Max(value, maxima.Peek()));
                    break;
                case "2":
                    maxima.Pop();
                    break;
                case "3":
                    printed.Add(maxima.Peek());
                    break;
            }
        }

        return printed.ToArray();
    }
}
