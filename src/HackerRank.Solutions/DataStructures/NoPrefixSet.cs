namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// No Prefix Set — report "GOOD SET", or "BAD SET" plus the first word that is a prefix of an
/// earlier word or has an earlier word as its prefix. Insert into a trie: passing an existing
/// word's end, or ending on a node that already exists, means a prefix clash. O(total length).
/// https://www.hackerrank.com/challenges/no-prefix-set
/// </summary>
public static class NoPrefixSet
{
    private sealed class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = [];

        public bool IsWord { get; set; }
    }

    public static string[] Solve(IReadOnlyList<string> words)
    {
        var root = new TrieNode();

        foreach (var word in words)
        {
            if (!TryInsert(root, word))
            {
                return ["BAD SET", word];
            }
        }

        return ["GOOD SET"];
    }

    private static bool TryInsert(TrieNode root, string word)
    {
        var node = root;

        foreach (var c in word)
        {
            if (node.IsWord)
            {
                return false;
            }

            if (!node.Children.TryGetValue(c, out var child))
            {
                child = new TrieNode();
                node.Children[c] = child;
            }

            node = child;
        }

        if (node.IsWord || node.Children.Count > 0)
        {
            return false;
        }

        node.IsWord = true;
        return true;
    }
}
