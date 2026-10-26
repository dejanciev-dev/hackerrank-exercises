namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Strange Counter — counts down from 3; after reaching 1 it restarts at double the previous
/// start. Return the displayed value at time <c>t</c> by skipping whole cycles (O(log t)).
/// https://www.hackerrank.com/challenges/strange-code
/// </summary>
public static class StrangeCounter
{
    public static long Solve(long t)
    {
        long cycleStart = 1;
        long cycleLength = 3;

        while (t >= cycleStart + cycleLength)
        {
            cycleStart += cycleLength;
            cycleLength *= 2;
        }

        return cycleLength - (t - cycleStart);
    }
}
