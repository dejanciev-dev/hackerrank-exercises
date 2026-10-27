using HackerRank.Solutions.Strings;

namespace HackerRank.Solutions.Tests;

public class StringsTests
{
    [Theory]
    [InlineData("saveChangesInTheEditor", 5)]
    [InlineData("one", 1)]
    public void CamelCase_CountsWords(string s, int expected) =>
        Assert.Equal(expected, CamelCase.Solve(s));

    [Theory]
    [InlineData("middle-Outz", 2, "okffng-Qwvb")]
    [InlineData("Always-Look-on-the-Bright-Side-of-Life", 5, "Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj")]
    [InlineData("www.abc.xy", 87, "fff.jkl.gh")]
    public void CaesarCipher_Samples(string s, int k, string expected) =>
        Assert.Equal(expected, CaesarCipher.Solve(s, k));

    [Theory]
    [InlineData("acxz", "Funny")]
    [InlineData("bcxz", "Not Funny")]
    public void FunnyString_Samples(string s, string expected) =>
        Assert.Equal(expected, FunnyString.Solve(s));

    [Theory]
    [InlineData("aaabbbb", "YES")]
    [InlineData("cdefghmnopqrstuvw", "NO")]
    [InlineData("cdcdcdcdeeeef", "YES")]
    public void GameOfThronesI_Samples(string s, string expected) =>
        Assert.Equal(expected, GameOfThronesI.Solve(s));

    [Fact]
    public void Gemstones_CountsCommonMinerals() =>
        Assert.Equal(2, Gemstones.Solve(["abcdde", "baccd", "eeabg"]));

    [Theory]
    [InlineData("hereiamstackerrank", "YES")]
    [InlineData("hackerworld", "NO")]
    [InlineData("hhaacckkekraraannk", "YES")]
    [InlineData("rhbaasdndfsdskgbfefdbrsdfhuyatrjtcrtyytktjjt", "NO")]
    public void HackerRankInAString_Samples(string s, string expected) =>
        Assert.Equal(expected, HackerRankInAString.Solve(s));

    [Theory]
    [InlineData("SOSSPSSQSSOR", 3)]
    [InlineData("SOSSOT", 1)]
    [InlineData("SOSSOSSOS", 0)]
    public void MarsExploration_Samples(string s, int expected) =>
        Assert.Equal(expected, MarsExploration.Solve(s));

    [Theory]
    [InlineData("We promptly judged antique ivory buckles for the next prize", "pangram")]
    [InlineData("We promptly judged antique ivory buckles for the prize", "not pangram")]
    public void Pangrams_Samples(string s, string expected) =>
        Assert.Equal(expected, Pangrams.Solve(s));

    [Theory]
    [InlineData("1234", "YES 1")]
    [InlineData("91011", "YES 9")]
    [InlineData("99100", "YES 99")]
    [InlineData("101103", "NO")]
    [InlineData("010203", "NO")]
    [InlineData("13", "NO")]
    [InlineData("1", "NO")]
    [InlineData("99910001001", "YES 999")]
    [InlineData("7891011", "YES 7")]
    [InlineData("9899100", "YES 98")]
    [InlineData("999100010001", "NO")]
    public void SeparateTheNumbers_Samples(string s, string expected) =>
        Assert.Equal(expected, SeparateTheNumbers.Solve(s));

    [Theory]
    [InlineData("abcd", 4)]
    [InlineData("abab", 2)]
    public void StringConstruction_Samples(string s, int expected) =>
        Assert.Equal(expected, StringConstruction.Solve(s));

    [Theory]
    [InlineData("Ab1", 3)]
    [InlineData("#HackerRank", 1)]
    [InlineData("2bbbb", 2)]
    [InlineData("2bb#A", 1)]
    public void StrongPassword_Samples(string password, int expected) =>
        Assert.Equal(expected, StrongPassword.Solve(password.Length, password));

    [Theory]
    [InlineData("aaabccddd", "abd")]
    [InlineData("aa", "Empty String")]
    [InlineData("baab", "Empty String")]
    public void SuperReducedString_Samples(string s, string expected) =>
        Assert.Equal(expected, SuperReducedString.Solve(s));

    [Theory]
    [InlineData("abc", 2)]
    [InlineData("abcba", 0)]
    [InlineData("abcd", 4)]
    [InlineData("cba", 2)]
    public void TheLoveLetterMystery_Samples(string s, int expected) =>
        Assert.Equal(expected, TheLoveLetterMystery.Solve(s));

    [Theory]
    [InlineData("hello", "world", "YES")]
    [InlineData("hi", "world", "NO")]
    public void TwoStrings_Samples(string s1, string s2, string expected) =>
        Assert.Equal(expected, TwoStrings.Solve(s1, s2));

    [Theory]
    [InlineData("AAAA", 3)]
    [InlineData("BBBBB", 4)]
    [InlineData("ABABABAB", 0)]
    [InlineData("BABABA", 0)]
    [InlineData("AAABBB", 4)]
    public void AlternatingCharacters_Samples(string s, int expected) =>
        Assert.Equal(expected, AlternatingCharacters.Solve(s));

    [Theory]
    [InlineData("0101010", 2)]
    [InlineData("01100", 0)]
    [InlineData("0100101010", 3)]
    public void BeautifulBinaryString_Samples(string b, int expected) =>
        Assert.Equal(expected, BeautifulBinaryString.Solve(b));

    [Fact]
    public void MakingAnagrams_CountsDeletions() =>
        Assert.Equal(4, MakingAnagrams.Solve("cde", "abc"));

    [Theory]
    [InlineData("aaabbb", 3)]
    [InlineData("ab", 1)]
    [InlineData("abc", -1)]
    [InlineData("mnop", 2)]
    [InlineData("xyyx", 0)]
    [InlineData("xaxbbbxx", 1)]
    public void Anagram_Samples(string s, int expected) =>
        Assert.Equal(expected, Anagram.Solve(s));

    [Theory]
    [InlineData("aaab", 3)]
    [InlineData("baa", 0)]
    [InlineData("aaa", -1)]
    public void PalindromeIndex_Samples(string s, int expected) =>
        Assert.Equal(expected, PalindromeIndex.Solve(s));

    [Fact]
    public void WeightedUniformStrings_AnswersQueries() =>
        Assert.Equal(
            ["Yes", "Yes", "Yes", "Yes", "No", "No"],
            WeightedUniformStrings.Solve("abccddde", [1, 3, 12, 5, 9, 10]));

    [Theory]
    [InlineData("aabbcd", "NO")]
    [InlineData("aabbccddeefghi", "NO")]
    [InlineData("abcdefghhgfedecba", "YES")]
    [InlineData("abc", "YES")]
    [InlineData("abcc", "YES")]
    [InlineData("aabbc", "YES")]
    [InlineData("aabbcccc", "NO")]
    public void SherlockAndTheValidString_Samples(string s, string expected) =>
        Assert.Equal(expected, SherlockAndTheValidString.Solve(s));

    [Theory]
    [InlineData("abba", 4)]
    [InlineData("abcd", 0)]
    [InlineData("ifailuhkqq", 3)]
    [InlineData("kkkk", 10)]
    [InlineData("cdcd", 5)]
    public void SherlockAndAnagrams_Samples(string s, int expected) =>
        Assert.Equal(expected, SherlockAndAnagrams.Solve(s));

    [Theory]
    [InlineData("HARRY", "SALLY", 2)]
    [InlineData("AA", "BB", 0)]
    [InlineData("SHINCHAN", "NOHARAAA", 3)]
    [InlineData("ABCDEF", "FBDAMN", 2)]
    public void CommonChild_Samples(string s1, string s2, int expected) =>
        Assert.Equal(expected, CommonChild.Solve(s1, s2));

    [Theory]
    [InlineData("beabeefeab", 5)]
    [InlineData("asdcbsdcagfsdbgdfanfghbsfdab", 8)]
    [InlineData("asvkugfiugsalddlasguifgukvsa", 0)]
    [InlineData("a", 0)]
    public void TwoCharacters_Samples(string s, int expected) =>
        Assert.Equal(expected, TwoCharacters.Solve(s));

    [Theory]
    [InlineData("3943", 1, "3993")]
    [InlineData("092282", 3, "992299")]
    [InlineData("0011", 1, "-1")]
    [InlineData("1231", 3, "9339")]
    [InlineData("777", 0, "777")]
    [InlineData("5", 1, "9")]
    [InlineData("12321", 1, "12921")]
    public void HighestValuePalindrome_Samples(string s, int k, string expected) =>
        Assert.Equal(expected, HighestValuePalindrome.Solve(s, k));

    [Theory]
    [InlineData("asasd", 7L)]
    [InlineData("abcbaba", 10L)]
    [InlineData("aaaa", 10L)]
    [InlineData("mnonopoo", 12L)]
    public void SpecialStringAgain_Samples(string s, long expected) =>
        Assert.Equal(expected, SpecialStringAgain.Solve(s));

    [Theory]
    [InlineData("GAAATAAA", 5)]
    [InlineData("ACTGAAAG", 2)]
    [InlineData("ACGT", 0)]
    [InlineData("AAAAAAAA", 6)]
    public void BearAndSteadyGene_Samples(string gene, int expected) =>
        Assert.Equal(expected, BearAndSteadyGene.Solve(gene));

    [Theory]
    [InlineData("JACK", "DANIEL", "DAJACKNIEL")]
    [InlineData("ABACABA", "ABACABA", "AABABACABACABA")]
    [InlineData("BA", "B", "BAB")]
    [InlineData("A", "", "A")]
    public void MorganAndAString_Samples(string a, string b, string expected) =>
        Assert.Equal(expected, MorganAndAString.Solve(a, b));

    [Theory]
    [InlineData("ababaa", 11L)]
    [InlineData("aa", 3L)]
    [InlineData("abc", 3L)]
    public void StringSimilarity_Samples(string s, long expected) =>
        Assert.Equal(expected, StringSimilarity.Solve(s));

    [Fact]
    public void MaximumPalindromes_Samples()
    {
        Assert.Equal([2L, 1L], MaximumPalindromes.Solve("week", [[1, 4], [2, 3]]));
        Assert.Equal([2L], MaximumPalindromes.Solve("abab", [[1, 4]]));
        Assert.Equal([2L], MaximumPalindromes.Solve("madamimadam", [[4, 7]]));
    }

    [Theory]
    [InlineData("kkkkkkz", 15L)]
    [InlineData("ghhggh", 4L)]
    [InlineData("abbaab", 4L)]
    [InlineData("akakak", 2L)]
    public void ShortPalindrome_Samples(string s, long expected) =>
        Assert.Equal(expected, ShortPalindrome.Solve(s));

    [Fact]
    public void ShortPalindrome_MatchesBruteForce()
    {
        var random = new Random(11);
        for (int trial = 0; trial < 50; trial++)
        {
            string s = new(Enumerable.Range(0, random.Next(4, 14)).Select(_ => (char)('a' + random.Next(3))).ToArray());
            long expected = 0;

            for (int a = 0; a < s.Length; a++)
                for (int b = a + 1; b < s.Length; b++)
                    for (int c = b + 1; c < s.Length; c++)
                        for (int d = c + 1; d < s.Length; d++)
                            if (s[a] == s[d] && s[b] == s[c])
                                expected++;

            Assert.Equal(expected, ShortPalindrome.Solve(s));
        }
    }

    [Theory]
    [InlineData("aaabbbb", 3L)]
    [InlineData("cdcdcdcdeeeef", 90L)]
    [InlineData("a", 1L)]
    public void GameOfThronesII_Samples(string s, long expected) =>
        Assert.Equal(expected, GameOfThronesII.Solve(s));

    [Fact]
    public void DeterminingDnaHealth_Sample() =>
        Assert.Equal(
            [0L, 19L],
            DeterminingDnaHealth.Solve(["a", "b", "c", "aa", "d", "b"], [1, 2, 3, 4, 5, 6], ["1 5 caaab", "0 4 xyz", "2 4 bcdybc"]));

    [Fact]
    public void DeterminingDnaHealth_MatchesBruteForce()
    {
        var random = new Random(23);
        string[] genes = ["a", "ab", "b", "ba", "aba", "bb", "a", "ab", "c"];
        int[] health = [3, 1, 4, 1, 5, 9, 2, 6, 5];
        var strands = new List<string>();
        var expected = new List<long>();

        for (int trial = 0; trial < 40; trial++)
        {
            int first = random.Next(genes.Length);
            int last = random.Next(first, genes.Length);
            string d = new(Enumerable.Range(0, random.Next(1, 12)).Select(_ => "abc"[random.Next(3)]).ToArray());
            strands.Add($"{first} {last} {d}");

            long total = 0;
            for (int i = first; i <= last; i++)
            {
                for (int at = d.IndexOf(genes[i], StringComparison.Ordinal); at >= 0; at = d.IndexOf(genes[i], at + 1, StringComparison.Ordinal))
                {
                    total += health[i];
                }
            }

            expected.Add(total);
        }

        Assert.Equal([expected.Min(), expected.Max()], DeterminingDnaHealth.Solve(genes, health, strands));
    }

    [Fact]
    public void AshtonAndString_Sample() =>
        Assert.Equal('c', AshtonAndString.Solve("dbac", 3));

    [Fact]
    public void AshtonAndString_MatchesBruteForce()
    {
        var random = new Random(29);
        for (int trial = 0; trial < 40; trial++)
        {
            string s = new(Enumerable.Range(0, random.Next(1, 9)).Select(_ => "abc"[random.Next(3)]).ToArray());
            string concatenation = string.Concat(
                Enumerable.Range(0, s.Length)
                    .SelectMany(i => Enumerable.Range(1, s.Length - i).Select(l => s.Substring(i, l)))
                    .Distinct()
                    .Order(StringComparer.Ordinal));

            for (int k = 1; k <= concatenation.Length; k++)
            {
                Assert.Equal(concatenation[k - 1], AshtonAndString.Solve(s, k));
            }
        }
    }

    [Theory]
    [InlineData("aaaaaa", 12L)]
    [InlineData("abcabcddd", 9L)]
    [InlineData("z", 1L)]
    public void StringFunctionCalculation_Samples(string t, long expected) =>
        Assert.Equal(expected, StringFunctionCalculation.Solve(t));

    [Fact]
    public void StringFunctionCalculation_MatchesBruteForce()
    {
        var random = new Random(31);
        for (int trial = 0; trial < 60; trial++)
        {
            string t = new(Enumerable.Range(0, random.Next(1, 12)).Select(_ => "ab"[random.Next(2)]).ToArray());
            long expected = 0;

            for (int i = 0; i < t.Length; i++)
            {
                for (int length = 1; i + length <= t.Length; length++)
                {
                    string sub = t.Substring(i, length);
                    int occurrences = Enumerable.Range(0, t.Length - length + 1)
                        .Count(j => string.CompareOrdinal(t, j, sub, 0, length) == 0);
                    expected = Math.Max(expected, (long)length * occurrences);
                }
            }

            Assert.Equal(expected, StringFunctionCalculation.Solve(t));
        }
    }

    [Theory]
    [InlineData("2222222", 7L)]
    [InlineData("24256", 4L)]
    [InlineData("65536", 1L)]
    [InlineData("023223", 4L)]
    public void TwoTwo_Samples(string a, long expected) =>
        Assert.Equal(expected, TwoTwo.Solve(a));

    [Fact]
    public void TwoTwo_MatchesBruteForce()
    {
        var powers = Enumerable.Range(0, 801).Select(e => System.Numerics.BigInteger.Pow(2, e).ToString()).ToHashSet();
        var random = new Random(37);

        for (int trial = 0; trial < 50; trial++)
        {
            string a = new(Enumerable.Range(0, random.Next(1, 25)).Select(_ => "0124568"[random.Next(7)]).ToArray());
            long expected = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int length = 1; i + length <= a.Length; length++)
                {
                    if (powers.Contains(a.Substring(i, length)))
                    {
                        expected++;
                    }
                }
            }

            Assert.Equal(expected, TwoTwo.Solve(a));
        }
    }

    [Fact]
    public void MaximumPalindromes_CountsArrangementsOfPairs() =>
        // aabbcc -> 3!/(1!1!1!) = 6 left halves; the extra d is the only possible middle.
        Assert.Equal([6L], MaximumPalindromes.Solve("aabbccd", [[1, 7]]));
}
