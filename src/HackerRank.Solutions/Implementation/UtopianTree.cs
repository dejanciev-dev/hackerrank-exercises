namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Utopian Tree — the tree doubles every spring and grows 1 meter every summer.
/// Return its height after <c>n</c> growth cycles, starting at 1 meter.
/// https://www.hackerrank.com/challenges/utopian-tree
/// </summary>
public static class UtopianTree
{
    public static int Solve(int n)
    {
        int height = 1;
        for (int cycle = 1; cycle <= n; cycle++)
        {
            height = cycle % 2 == 1 ? height * 2 : height + 1;
        }

        return height;
    }
}
