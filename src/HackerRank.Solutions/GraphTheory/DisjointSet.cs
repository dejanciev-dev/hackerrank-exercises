namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Union-find with path halving and union by size, shared by the connectivity problems.
/// </summary>
internal sealed class DisjointSet
{
    private readonly int[] _parent;
    private readonly int[] _size;

    public DisjointSet(int count)
    {
        _parent = new int[count];
        _size = new int[count];

        for (int i = 0; i < count; i++)
        {
            _parent[i] = i;
            _size[i] = 1;
        }
    }

    public int Find(int x)
    {
        while (_parent[x] != x)
        {
            _parent[x] = _parent[_parent[x]];
            x = _parent[x];
        }

        return x;
    }

    /// <summary>Merges the sets of <paramref name="a"/> and <paramref name="b"/>; false if already joined.</summary>
    public bool Union(int a, int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);

        if (rootA == rootB)
        {
            return false;
        }

        if (_size[rootA] < _size[rootB])
        {
            (rootA, rootB) = (rootB, rootA);
        }

        _parent[rootB] = rootA;
        _size[rootA] += _size[rootB];
        return true;
    }

    public int SizeOf(int x) => _size[Find(x)];
}
