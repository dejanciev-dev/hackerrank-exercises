using System.Text;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Tree: Huffman Decoding — decode a bit string by walking from the root ('0' left, '1'
/// right); each leaf reached emits its symbol and the walk restarts at the root. O(bits).
/// https://www.hackerrank.com/challenges/tree-huffman-decoding
/// </summary>
public static class HuffmanDecoding
{
    public static string Solve(HuffmanNode root, string bits)
    {
        var decoded = new StringBuilder();
        var node = root;

        foreach (var bit in bits)
        {
            node = bit == '0' ? node.Left! : node.Right!;
            if (node.Symbol is char symbol)
            {
                decoded.Append(symbol);
                node = root;
            }
        }

        return decoded.ToString();
    }
}
