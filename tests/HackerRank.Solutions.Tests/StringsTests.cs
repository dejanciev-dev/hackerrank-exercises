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

    [Fact]
    public void MaximumPalindromes_CountsArrangementsOfPairs() =>
        // aabbcc -> 3!/(1!1!1!) = 6 left halves; the extra d is the only possible middle.
        Assert.Equal([6L], MaximumPalindromes.Solve("aabbccd", [[1, 7]]));
}
