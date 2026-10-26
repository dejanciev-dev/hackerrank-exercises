# HackerRank Exercises in C#

[![build](https://github.com/dejanciev-dev/hackerrank-exercises/actions/workflows/build.yml/badge.svg)](https://github.com/dejanciev-dev/hackerrank-exercises/actions/workflows/build.yml)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-latest-239120?logo=csharp)
![Solutions](https://img.shields.io/badge/solutions-64-blue)

My solutions to [HackerRank](https://www.hackerrank.com/) problems, written in modern C# (.NET 10).
Every solution has unit tests built from the problem's sample cases, and GitHub Actions runs them on each push.

## Highlights

- **64 problems** in four categories: Warmup, Implementation, Strings and Data Structures
- **159 xUnit tests** covering the official samples and extra edge cases (overflow, empty results, off-by-one boundaries)
- **Focus on complexity**: sliding windows, two pointers, stacks, hashing and closed-form math, so most solutions run in O(n) or better
- **Every solution has a doc comment** with the problem statement and a link to the original challenge

## Project structure

```
hackerrank-exercises/
├── src/HackerRank.Solutions/          # Class library: one static class per problem
│   ├── Warmup/
│   ├── Implementation/
│   ├── Strings/
│   └── DataStructures/
├── tests/HackerRank.Solutions.Tests/  # xUnit tests, one file per category
├── .github/workflows/build.yml        # CI: build and test on every push / PR
└── HackerRank.sln
```

Each problem is a static class with a single `Solve` method:

```csharp
// src/HackerRank.Solutions/Strings/SuperReducedString.cs
public static class SuperReducedString
{
    public static string Solve(string s)
    {
        var stack = new StringBuilder(s.Length);

        foreach (var c in s)
        {
            if (stack.Length > 0 && stack[^1] == c)
                stack.Length--;
            else
                stack.Append(c);
        }

        return stack.Length > 0 ? stack.ToString() : "Empty String";
    }
}
```

## Getting started

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/dejanciev-dev/hackerrank-exercises.git
cd hackerrank-exercises
dotnet test
```

To run the tests for one category or one problem:

```bash
dotnet test --filter "FullyQualifiedName~StringsTests"
dotnet test --filter "FullyQualifiedName~ClimbingTheLeaderboard"
```

## Solutions

### Warmup (10)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Solve Me First](https://www.hackerrank.com/challenges/solve-me-first) | Easy | Arithmetic | [SolveMeFirst.cs](src/HackerRank.Solutions/Warmup/SolveMeFirst.cs) |
| [Simple Array Sum](https://www.hackerrank.com/challenges/simple-array-sum) | Easy | Linear scan | [SimpleArraySum.cs](src/HackerRank.Solutions/Warmup/SimpleArraySum.cs) |
| [Compare the Triplets](https://www.hackerrank.com/challenges/compare-the-triplets) | Easy | Pairwise comparison | [CompareTheTriplets.cs](src/HackerRank.Solutions/Warmup/CompareTheTriplets.cs) |
| [A Very Big Sum](https://www.hackerrank.com/challenges/a-very-big-sum) | Easy | 64-bit accumulation | [AVeryBigSum.cs](src/HackerRank.Solutions/Warmup/AVeryBigSum.cs) |
| [Diagonal Difference](https://www.hackerrank.com/challenges/diagonal-difference) | Easy | Single pass over both diagonals | [DiagonalDifference.cs](src/HackerRank.Solutions/Warmup/DiagonalDifference.cs) |
| [Plus Minus](https://www.hackerrank.com/challenges/plus-minus) | Easy | Counting, invariant formatting | [PlusMinus.cs](src/HackerRank.Solutions/Warmup/PlusMinus.cs) |
| [Staircase](https://www.hackerrank.com/challenges/staircase) | Easy | String building | [Staircase.cs](src/HackerRank.Solutions/Warmup/Staircase.cs) |
| [Mini-Max Sum](https://www.hackerrank.com/challenges/mini-max-sum) | Easy | Total minus max / min | [MiniMaxSum.cs](src/HackerRank.Solutions/Warmup/MiniMaxSum.cs) |
| [Birthday Cake Candles](https://www.hackerrank.com/challenges/birthday-cake-candles) | Easy | Single pass max-count | [BirthdayCakeCandles.cs](src/HackerRank.Solutions/Warmup/BirthdayCakeCandles.cs) |
| [Time Conversion](https://www.hackerrank.com/challenges/time-conversion) | Easy | String parsing | [TimeConversion.cs](src/HackerRank.Solutions/Warmup/TimeConversion.cs) |

### Implementation (29)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Grading Students](https://www.hackerrank.com/challenges/grading) | Easy | Rounding rules | [GradingStudents.cs](src/HackerRank.Solutions/Implementation/GradingStudents.cs) |
| [Apple and Orange](https://www.hackerrank.com/challenges/apple-and-orange) | Easy | Range check | [AppleAndOrange.cs](src/HackerRank.Solutions/Implementation/AppleAndOrange.cs) |
| [Number Line Jumps](https://www.hackerrank.com/challenges/kangaroo) | Easy | Closed-form math, O(1) | [NumberLineJumps.cs](src/HackerRank.Solutions/Implementation/NumberLineJumps.cs) |
| [Between Two Sets](https://www.hackerrank.com/challenges/between-two-sets) | Easy | LCM / GCD | [BetweenTwoSets.cs](src/HackerRank.Solutions/Implementation/BetweenTwoSets.cs) |
| [Breaking the Records](https://www.hackerrank.com/challenges/breaking-best-and-worst-records) | Easy | Running min / max | [BreakingTheRecords.cs](src/HackerRank.Solutions/Implementation/BreakingTheRecords.cs) |
| [Subarray Division](https://www.hackerrank.com/challenges/the-birthday-bar) | Easy | Sliding window | [SubarrayDivision.cs](src/HackerRank.Solutions/Implementation/SubarrayDivision.cs) |
| [Divisible Sum Pairs](https://www.hackerrank.com/challenges/divisible-sum-pairs) | Easy | Remainder buckets, O(n + k) | [DivisibleSumPairs.cs](src/HackerRank.Solutions/Implementation/DivisibleSumPairs.cs) |
| [Migratory Birds](https://www.hackerrank.com/challenges/migratory-birds) | Easy | Frequency map | [MigratoryBirds.cs](src/HackerRank.Solutions/Implementation/MigratoryBirds.cs) |
| [Day of the Programmer](https://www.hackerrank.com/challenges/day-of-the-programmer) | Easy | Julian / Gregorian calendars | [DayOfTheProgrammer.cs](src/HackerRank.Solutions/Implementation/DayOfTheProgrammer.cs) |
| [Bill Division](https://www.hackerrank.com/challenges/bon-appetit) | Easy | Arithmetic | [BillDivision.cs](src/HackerRank.Solutions/Implementation/BillDivision.cs) |
| [Sales by Match](https://www.hackerrank.com/challenges/sock-merchant) | Easy | HashSet pairing | [SalesByMatch.cs](src/HackerRank.Solutions/Implementation/SalesByMatch.cs) |
| [Counting Valleys](https://www.hackerrank.com/challenges/counting-valleys) | Easy | Altitude tracking | [CountingValleys.cs](src/HackerRank.Solutions/Implementation/CountingValleys.cs) |
| [Electronics Shop](https://www.hackerrank.com/challenges/electronics-shop) | Easy | Sort + two pointers | [ElectronicsShop.cs](src/HackerRank.Solutions/Implementation/ElectronicsShop.cs) |
| [Cats and a Mouse](https://www.hackerrank.com/challenges/cats-and-a-mouse) | Easy | Distance comparison | [CatsAndAMouse.cs](src/HackerRank.Solutions/Implementation/CatsAndAMouse.cs) |
| [Picking Numbers](https://www.hackerrank.com/challenges/picking-numbers) | Easy | Frequency of adjacent values | [PickingNumbers.cs](src/HackerRank.Solutions/Implementation/PickingNumbers.cs) |
| [Climbing the Leaderboard](https://www.hackerrank.com/challenges/climbing-the-leaderboard) | Medium | Dense ranking, single pointer O(n + m) | [ClimbingTheLeaderboard.cs](src/HackerRank.Solutions/Implementation/ClimbingTheLeaderboard.cs) |
| [The Hurdle Race](https://www.hackerrank.com/challenges/the-hurdle-race) | Easy | Max | [TheHurdleRace.cs](src/HackerRank.Solutions/Implementation/TheHurdleRace.cs) |
| [Designer PDF Viewer](https://www.hackerrank.com/challenges/designer-pdf-viewer) | Easy | Lookup table | [DesignerPdfViewer.cs](src/HackerRank.Solutions/Implementation/DesignerPdfViewer.cs) |
| [Utopian Tree](https://www.hackerrank.com/challenges/utopian-tree) | Easy | Simulation | [UtopianTree.cs](src/HackerRank.Solutions/Implementation/UtopianTree.cs) |
| [Angry Professor](https://www.hackerrank.com/challenges/angry-professor) | Easy | Counting | [AngryProfessor.cs](src/HackerRank.Solutions/Implementation/AngryProfessor.cs) |
| [Beautiful Days at the Movies](https://www.hackerrank.com/challenges/beautiful-days-at-the-movies) | Easy | Arithmetic digit reversal | [BeautifulDaysAtTheMovies.cs](src/HackerRank.Solutions/Implementation/BeautifulDaysAtTheMovies.cs) |
| [Viral Advertising](https://www.hackerrank.com/challenges/strange-advertising) | Easy | Simulation | [ViralAdvertising.cs](src/HackerRank.Solutions/Implementation/ViralAdvertising.cs) |
| [Save the Prisoner!](https://www.hackerrank.com/challenges/save-the-prisoner) | Easy | Modular arithmetic, overflow-safe | [SaveThePrisoner.cs](src/HackerRank.Solutions/Implementation/SaveThePrisoner.cs) |
| [Find Digits](https://www.hackerrank.com/challenges/find-digits) | Easy | Digit extraction | [FindDigits.cs](src/HackerRank.Solutions/Implementation/FindDigits.cs) |
| [Append and Delete](https://www.hackerrank.com/challenges/append-and-delete) | Easy | Common prefix + parity | [AppendAndDelete.cs](src/HackerRank.Solutions/Implementation/AppendAndDelete.cs) |
| [Sherlock and Squares](https://www.hackerrank.com/challenges/sherlock-and-squares) | Easy | Integer square root, O(1) | [SherlockAndSquares.cs](src/HackerRank.Solutions/Implementation/SherlockAndSquares.cs) |
| [Repeated String](https://www.hackerrank.com/challenges/repeated-string) | Easy | Math, no string building | [RepeatedString.cs](src/HackerRank.Solutions/Implementation/RepeatedString.cs) |
| [Jumping on the Clouds](https://www.hackerrank.com/challenges/jumping-on-the-clouds) | Easy | Greedy | [JumpingOnTheClouds.cs](src/HackerRank.Solutions/Implementation/JumpingOnTheClouds.cs) |
| [Equalize the Array](https://www.hackerrank.com/challenges/equality-in-a-array) | Easy | Most frequent value | [EqualizeTheArray.cs](src/HackerRank.Solutions/Implementation/EqualizeTheArray.cs) |

### Strings (20)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Super Reduced String](https://www.hackerrank.com/challenges/reduced-string) | Easy | Stack, single pass | [SuperReducedString.cs](src/HackerRank.Solutions/Strings/SuperReducedString.cs) |
| [CamelCase](https://www.hackerrank.com/challenges/camelcase) | Easy | Count uppercase | [CamelCase.cs](src/HackerRank.Solutions/Strings/CamelCase.cs) |
| [Strong Password](https://www.hackerrank.com/challenges/strong-password) | Easy | Character classes | [StrongPassword.cs](src/HackerRank.Solutions/Strings/StrongPassword.cs) |
| [Caesar Cipher](https://www.hackerrank.com/challenges/caesar-cipher-1) | Easy | Modular rotation | [CaesarCipher.cs](src/HackerRank.Solutions/Strings/CaesarCipher.cs) |
| [Mars Exploration](https://www.hackerrank.com/challenges/mars-exploration) | Easy | Pattern comparison | [MarsExploration.cs](src/HackerRank.Solutions/Strings/MarsExploration.cs) |
| [HackerRank in a String!](https://www.hackerrank.com/challenges/hackerrank-in-a-string) | Easy | Subsequence matching | [HackerRankInAString.cs](src/HackerRank.Solutions/Strings/HackerRankInAString.cs) |
| [Pangrams](https://www.hackerrank.com/challenges/pangrams) | Easy | HashSet | [Pangrams.cs](src/HackerRank.Solutions/Strings/Pangrams.cs) |
| [Weighted Uniform Strings](https://www.hackerrank.com/challenges/weighted-uniform-string) | Easy | Run-length weights + HashSet | [WeightedUniformStrings.cs](src/HackerRank.Solutions/Strings/WeightedUniformStrings.cs) |
| [Separate the Numbers](https://www.hackerrank.com/challenges/separate-the-numbers) | Easy | Try every first-number length | [SeparateTheNumbers.cs](src/HackerRank.Solutions/Strings/SeparateTheNumbers.cs) |
| [Funny String](https://www.hackerrank.com/challenges/funny-string) | Easy | Two-direction diff | [FunnyString.cs](src/HackerRank.Solutions/Strings/FunnyString.cs) |
| [Gemstones](https://www.hackerrank.com/challenges/gem-stones) | Easy | Set intersection | [Gemstones.cs](src/HackerRank.Solutions/Strings/Gemstones.cs) |
| [Alternating Characters](https://www.hackerrank.com/challenges/alternating-characters) | Easy | Adjacent comparison | [AlternatingCharacters.cs](src/HackerRank.Solutions/Strings/AlternatingCharacters.cs) |
| [Beautiful Binary String](https://www.hackerrank.com/challenges/beautiful-binary-string) | Easy | Greedy scan | [BeautifulBinaryString.cs](src/HackerRank.Solutions/Strings/BeautifulBinaryString.cs) |
| [The Love-Letter Mystery](https://www.hackerrank.com/challenges/the-love-letter-mystery) | Easy | Two pointers | [TheLoveLetterMystery.cs](src/HackerRank.Solutions/Strings/TheLoveLetterMystery.cs) |
| [Palindrome Index](https://www.hackerrank.com/challenges/palindrome-index) | Easy | Two pointers, O(n) | [PalindromeIndex.cs](src/HackerRank.Solutions/Strings/PalindromeIndex.cs) |
| [Anagram](https://www.hackerrank.com/challenges/anagram) | Easy | Letter counts | [Anagram.cs](src/HackerRank.Solutions/Strings/Anagram.cs) |
| [Making Anagrams](https://www.hackerrank.com/challenges/making-anagrams) | Easy | Letter counts | [MakingAnagrams.cs](src/HackerRank.Solutions/Strings/MakingAnagrams.cs) |
| [Game of Thrones - I](https://www.hackerrank.com/challenges/game-of-thrones) | Easy | Odd-count parity | [GameOfThronesI.cs](src/HackerRank.Solutions/Strings/GameOfThronesI.cs) |
| [Two Strings](https://www.hackerrank.com/challenges/two-strings) | Easy | Shared character | [TwoStrings.cs](src/HackerRank.Solutions/Strings/TwoStrings.cs) |
| [String Construction](https://www.hackerrank.com/challenges/string-construction) | Easy | Distinct characters | [StringConstruction.cs](src/HackerRank.Solutions/Strings/StringConstruction.cs) |

### Data Structures (5)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Arrays - DS](https://www.hackerrank.com/challenges/arrays-ds) | Easy | Two-pointer reversal | [ArraysDS.cs](src/HackerRank.Solutions/DataStructures/ArraysDS.cs) |
| [2D Array - DS](https://www.hackerrank.com/challenges/2d-array) | Easy | Grid scan | [HourglassSum.cs](src/HackerRank.Solutions/DataStructures/HourglassSum.cs) |
| [Left Rotation](https://www.hackerrank.com/challenges/array-left-rotation) | Easy | Index arithmetic | [LeftRotation.cs](src/HackerRank.Solutions/DataStructures/LeftRotation.cs) |
| [Sparse Arrays](https://www.hackerrank.com/challenges/sparse-arrays) | Medium | Frequency dictionary | [SparseArrays.cs](src/HackerRank.Solutions/DataStructures/SparseArrays.cs) |
| [Balanced Brackets](https://www.hackerrank.com/challenges/balanced-brackets) | Medium | Stack | [BalancedBrackets.cs](src/HackerRank.Solutions/DataStructures/BalancedBrackets.cs) |

## Adding a new solution

1. Add a static class under the matching category folder in `src/HackerRank.Solutions/`, with a `<summary>` that describes the problem and links to it.
2. Add tests with the problem's sample cases to the matching `*Tests.cs` file.
3. Run `dotnet test` and add a row to the table above.

## License

Solutions are my own work. Problem statements belong to [HackerRank](https://www.hackerrank.com/).
