namespace HackerRank.Solutions.Strings;

/// <summary>
/// Highest Value Palindrome — make the numeric string a palindrome with at most <c>k</c> digit
/// changes, maximizing its value; return "-1" if impossible. First spend the minimum changes on
/// mismatched pairs, then use what's left to upgrade pairs to 9s from the outside in.
/// https://www.hackerrank.com/challenges/richie-rich
/// </summary>
public static class HighestValuePalindrome
{
    public static string Solve(string s, int k)
    {
        var digits = s.ToCharArray();
        var changed = new bool[digits.Length];
        int n = digits.Length;

        // Pass 1: fix every mismatch with the larger digit of the pair.
        for (int left = 0, right = n - 1; left < right; left++, right--)
        {
            if (digits[left] != digits[right])
            {
                char larger = (char)Math.Max(digits[left], digits[right]);
                digits[left] = digits[right] = larger;
                changed[left] = true;
                k--;
            }
        }

        if (k < 0)
        {
            return "-1";
        }

        // Pass 2: upgrade to 9s. A pair already changed once costs only one more change.
        for (int left = 0, right = n - 1; left <= right; left++, right--)
        {
            if (left == right)
            {
                if (k > 0) digits[left] = '9';
                break;
            }

            if (digits[left] == '9')
            {
                continue;
            }

            int cost = changed[left] ? 1 : 2;
            if (k >= cost)
            {
                digits[left] = digits[right] = '9';
                k -= cost;
            }
        }

        return new string(digits);
    }
}
