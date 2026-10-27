namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Winning Lottery Ticket — count pairs of tickets that together contain every digit 0–9.
/// Each ticket reduces to a 10-bit mask of its digits, so bucket the tickets by mask and
/// check the 1024² mask pairs instead of n² ticket pairs.
/// https://www.hackerrank.com/challenges/winning-lottery-ticket
/// </summary>
public static class WinningLotteryTicket
{
    private const int AllDigits = (1 << 10) - 1;

    public static long Solve(IReadOnlyList<string> tickets)
    {
        var counts = new long[AllDigits + 1];

        foreach (var ticket in tickets)
        {
            int mask = 0;
            foreach (var digit in ticket)
            {
                mask |= 1 << (digit - '0');
            }

            counts[mask]++;
        }

        long pairs = 0;

        for (int a = 0; a <= AllDigits; a++)
        {
            if (counts[a] == 0)
            {
                continue;
            }

            for (int b = a + 1; b <= AllDigits; b++)
            {
                if ((a | b) == AllDigits)
                {
                    pairs += counts[a] * counts[b];
                }
            }
        }

        // Two tickets with the same mask only win if that mask already has every digit.
        pairs += counts[AllDigits] * (counts[AllDigits] - 1) / 2;
        return pairs;
    }
}
