namespace HackerRank.Solutions.Strings;

/// <summary>
/// Palindrome Index — index of the character whose removal makes <c>s</c> a palindrome,
/// or -1 if it already is one. Two pointers find the first mismatch in O(n).
/// https://www.hackerrank.com/challenges/palindrome-index
/// </summary>
public static class PalindromeIndex
{
    public static int Solve(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                if (IsPalindrome(s, left + 1, right)) return left;
                if (IsPalindrome(s, left, right - 1)) return right;
                return -1;
            }

            left++;
            right--;
        }

        return -1;
    }

    private static bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left++] != s[right--])
            {
                return false;
            }
        }

        return true;
    }
}
