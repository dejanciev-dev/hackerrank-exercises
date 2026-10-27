namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Team Formation — split the contestants into teams of consecutive skill levels (each level
/// at most once per team) so the smallest team is as large as possible. Go through the
/// skills in sorted order and add each contestant to the smallest team that ends at
/// skill - 1; that keeps every team growing evenly. Otherwise start a new team. Min-heaps of
/// team sizes, keyed by the skill each team ends at. O(n log n).
/// https://www.hackerrank.com/challenges/team-formation
/// </summary>
public static class TeamFormation
{
    public static int Solve(IReadOnlyList<int> skills)
    {
        if (skills.Count == 0)
        {
            return 0;
        }

        var endingAt = new Dictionary<int, PriorityQueue<int, int>>();

        foreach (var skill in skills.Order())
        {
            int size = 1;
            if (endingAt.TryGetValue(skill - 1, out var previous) && previous.Count > 0)
            {
                size = previous.Dequeue() + 1;
            }

            if (!endingAt.TryGetValue(skill, out var current))
            {
                current = new PriorityQueue<int, int>();
                endingAt[skill] = current;
            }

            current.Enqueue(size, size);
        }

        return endingAt.Values.Where(q => q.Count > 0).Min(q => q.Peek());
    }
}
