using System.Text;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Simple Text Editor — support "1 W" (append), "2 k" (delete last k), "3 k" (print k-th
/// character) and "4" (undo the last append or delete). Each edit pushes its inverse onto an
/// undo stack, so no full snapshots of the text are kept. Returns the printed characters.
/// https://www.hackerrank.com/challenges/simple-text-editor
/// </summary>
public static class SimpleTextEditor
{
    public static string[] Solve(IReadOnlyList<string> operations)
    {
        var text = new StringBuilder();
        var undo = new Stack<(bool WasAppend, string Payload)>();
        var printed = new List<string>();

        foreach (var operation in operations)
        {
            var parts = operation.Split(' ', 2);

            switch (parts[0])
            {
                case "1":
                    text.Append(parts[1]);
                    undo.Push((true, parts[1]));
                    break;
                case "2":
                    int count = int.Parse(parts[1]);
                    string removed = text.ToString(text.Length - count, count);
                    text.Length -= count;
                    undo.Push((false, removed));
                    break;
                case "3":
                    printed.Add(text[int.Parse(parts[1]) - 1].ToString());
                    break;
                case "4":
                    var (wasAppend, payload) = undo.Pop();
                    if (wasAppend)
                    {
                        text.Length -= payload.Length;
                    }
                    else
                    {
                        text.Append(payload);
                    }

                    break;
            }
        }

        return printed.ToArray();
    }
}
