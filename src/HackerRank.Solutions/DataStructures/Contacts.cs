namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Contacts — handle "add name" and "find partial" (how many names start with the prefix).
/// A trie storing, at every node, how many names pass through it answers each find in O(prefix length).
/// https://www.hackerrank.com/challenges/contacts
/// </summary>
public static class Contacts
{
    private sealed class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = [];

        public int Count { get; set; }
    }

    public static int[] Solve(IReadOnlyList<string> queries)
    {
        var root = new TrieNode();
        var results = new List<int>();

        foreach (var query in queries)
        {
            var parts = query.Split(' ');
            var word = parts[1];

            if (parts[0] == "add")
            {
                var node = root;
                foreach (var c in word)
                {
                    if (!node.Children.TryGetValue(c, out var child))
                    {
                        child = new TrieNode();
                        node.Children[c] = child;
                    }

                    node = child;
                    node.Count++;
                }
            }
            else
            {
                results.Add(CountWithPrefix(root, word));
            }
        }

        return results.ToArray();
    }

    private static int CountWithPrefix(TrieNode root, string prefix)
    {
        var node = root;
        foreach (var c in prefix)
        {
            if (!node.Children.TryGetValue(c, out node))
            {
                return 0;
            }
        }

        return node.Count;
    }
}
