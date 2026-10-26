namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Designer PDF Viewer — area of the highlight rectangle: tallest letter times word length.
/// <c>h</c> holds the heights of 'a' through 'z'.
/// https://www.hackerrank.com/challenges/designer-pdf-viewer
/// </summary>
public static class DesignerPdfViewer
{
    public static int Solve(IReadOnlyList<int> h, string word)
    {
        int tallest = 0;
        foreach (var letter in word)
        {
            tallest = Math.Max(tallest, h[letter - 'a']);
        }

        return tallest * word.Length;
    }
}
