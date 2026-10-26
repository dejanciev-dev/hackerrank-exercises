namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Dynamic Array — process "1 x y" (append y to list (x XOR lastAnswer) mod n) and
/// "2 x y" (lastAnswer = that list's element y mod size) queries; return every lastAnswer.
/// https://www.hackerrank.com/challenges/dynamic-array
/// </summary>
public static class DynamicArray
{
    public static int[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var lists = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var answers = new List<int>();
        int lastAnswer = 0;

        foreach (var query in queries)
        {
            var list = lists[(query[1] ^ lastAnswer) % n];

            if (query[0] == 1)
            {
                list.Add(query[2]);
            }
            else
            {
                lastAnswer = list[query[2] % list.Count];
                answers.Add(lastAnswer);
            }
        }

        return answers.ToArray();
    }
}
