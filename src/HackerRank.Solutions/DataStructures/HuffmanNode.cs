namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// A Huffman tree node: leaves carry a symbol, internal nodes don't.
/// </summary>
public sealed class HuffmanNode(char? symbol = null)
{
    public char? Symbol { get; } = symbol;

    public HuffmanNode? Left { get; init; }

    public HuffmanNode? Right { get; init; }
}
