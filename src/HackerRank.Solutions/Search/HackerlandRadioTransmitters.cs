namespace HackerRank.Solutions.Search;

/// <summary>
/// Hackerland Radio Transmitters — minimum transmitters of range <c>k</c>, placed on houses, to
/// cover every house. Greedy: for the leftmost uncovered house, place the transmitter on the
/// furthest house still within k of it, then skip everything that transmitter covers.
/// https://www.hackerrank.com/challenges/hackerland-radio-transmitters
/// </summary>
public static class HackerlandRadioTransmitters
{
    public static int Solve(int k, IReadOnlyList<int> x)
    {
        var houses = x.Order().ToArray();
        int transmitters = 0;
        int i = 0;

        while (i < houses.Length)
        {
            transmitters++;

            int reach = houses[i] + k;
            while (i < houses.Length && houses[i] <= reach) i++;

            int coverage = houses[i - 1] + k;
            while (i < houses.Length && houses[i] <= coverage) i++;
        }

        return transmitters;
    }
}
