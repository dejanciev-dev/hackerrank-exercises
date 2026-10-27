namespace HackerRank.Solutions.Strings;

/// <summary>
/// Determining DNA Health — each strand may only use the genes with indices first..last;
/// its health is the total health of every occurrence of those genes in it. Return the
/// smallest and largest strand health. All genes go into one Aho–Corasick automaton, built
/// once. Each distinct gene keeps its sorted indices and a prefix sum of health, so a match
/// adds the health of the allowed indices with two binary searches.
/// O((Σ genes + Σ strands) · log n), plus the number of matches.
/// https://www.hackerrank.com/challenges/determining-dna-health
/// </summary>
public static class DeterminingDnaHealth
{
    private sealed class State
    {
        public Dictionary<char, int> Next { get; } = [];

        public int Fail { get; set; }

        /// <summary>Distinct-gene id ending exactly here, or -1.</summary>
        public int Gene { get; set; } = -1;

        /// <summary>Nearest state along the fail chain that ends a gene, or 0 for none.</summary>
        public int Output { get; set; }
    }

    /// <param name="genes">Gene strings, by index.</param>
    /// <param name="health">The health of each gene index.</param>
    /// <param name="strands">Each strand as <c>"first last d"</c>.</param>
    public static long[] Solve(IReadOnlyList<string> genes, IReadOnlyList<int> health, IReadOnlyList<string> strands)
    {
        var geneIds = new Dictionary<string, int>();
        var indices = new List<List<int>>();
        var prefix = new List<List<long>>();

        for (int i = 0; i < genes.Count; i++)
        {
            if (!geneIds.TryGetValue(genes[i], out int id))
            {
                id = geneIds.Count;
                geneIds[genes[i]] = id;
                indices.Add([]);
                prefix.Add([0]);
            }

            indices[id].Add(i);
            prefix[id].Add(prefix[id][^1] + health[i]);
        }

        var states = BuildAutomaton(geneIds);
        long min = long.MaxValue;
        long max = long.MinValue;

        foreach (var line in strands)
        {
            var parts = line.Split(' ');
            int first = int.Parse(parts[0]);
            int last = int.Parse(parts[1]);
            long total = 0;
            int state = 0;

            foreach (var c in parts[2])
            {
                state = Step(states, state, c);

                for (int match = states[state].Gene >= 0 ? state : states[state].Output; match != 0; match = states[match].Output)
                {
                    int id = states[match].Gene;
                    int from = LowerBound(indices[id], first);
                    int to = LowerBound(indices[id], last + 1);
                    total += prefix[id][to] - prefix[id][from];
                }
            }

            min = Math.Min(min, total);
            max = Math.Max(max, total);
        }

        return [min, max];
    }

    private static List<State> BuildAutomaton(Dictionary<string, int> geneIds)
    {
        var states = new List<State> { new() };

        foreach (var (gene, id) in geneIds)
        {
            int state = 0;
            foreach (var c in gene)
            {
                if (!states[state].Next.TryGetValue(c, out int next))
                {
                    next = states.Count;
                    states.Add(new State());
                    states[state].Next[c] = next;
                }

                state = next;
            }

            states[state].Gene = id;
        }

        // Breadth-first, so every fail target is finished before it's needed.
        var queue = new Queue<int>();
        foreach (var child in states[0].Next.Values)
        {
            queue.Enqueue(child);
        }

        while (queue.Count > 0)
        {
            int state = queue.Dequeue();
            foreach (var (c, child) in states[state].Next)
            {
                int fail = Step(states, states[state].Fail, c);
                states[child].Fail = fail;
                states[child].Output = states[fail].Gene >= 0 ? fail : states[fail].Output;
                queue.Enqueue(child);
            }
        }

        return states;
    }

    private static int Step(List<State> states, int state, char c)
    {
        while (true)
        {
            if (states[state].Next.TryGetValue(c, out int next))
            {
                return next;
            }

            if (state == 0)
            {
                return 0;
            }

            state = states[state].Fail;
        }
    }

    private static int LowerBound(List<int> sorted, int value)
    {
        int low = 0;
        int high = sorted.Count;
        while (low < high)
        {
            int mid = (low + high) / 2;
            if (sorted[mid] < value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}
