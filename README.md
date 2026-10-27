# HackerRank Exercises in C#

[![build](https://github.com/dejanciev-dev/hackerrank-exercises/actions/workflows/build.yml/badge.svg)](https://github.com/dejanciev-dev/hackerrank-exercises/actions/workflows/build.yml)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-latest-239120?logo=csharp)
![Solutions](https://img.shields.io/badge/solutions-293-blue)
![Tests](https://img.shields.io/badge/tests-830-brightgreen)

My solutions to [HackerRank](https://www.hackerrank.com/) problems, written in modern C# (.NET 10).
Every solution has unit tests built from the problem's sample cases, and GitHub Actions runs them on each push.

## Highlights

- **293 problems** in thirteen categories: Warmup, Implementation, Strings, Data Structures, Sorting, Search, Greedy, Dynamic Programming, Recursion, Bit Manipulation, Graph Theory, Mathematics and Game Theory
- **830 xUnit tests** covering the official samples and extra edge cases (overflow, empty results, off-by-one boundaries). Closed-form answers, such as the game theory patterns, are also checked against brute-force solvers
- **Classic techniques**: sliding windows, two pointers, monotonic stacks and deques, heaps, tries, linked lists, BSTs, difference arrays, dynamic programming, backtracking, BFS, Dijkstra, Floyd–Warshall, union-find, minimum spanning trees, Sprague–Grundy, modular arithmetic, bit tricks and closed-form math. Most solutions run in O(n) or O(n log n)
- **Every solution has a doc comment** with the problem statement and a link to the original challenge

## Project structure

```
hackerrank-exercises/
├── src/HackerRank.Solutions/          # Class library: one static class per problem
│   ├── Warmup/
│   ├── Implementation/
│   ├── Strings/
│   ├── DataStructures/
│   ├── Sorting/
│   ├── Search/
│   ├── Greedy/
│   ├── DynamicProgramming/
│   ├── Recursion/
│   ├── BitManipulation/
│   ├── GraphTheory/
│   ├── Mathematics/
│   └── GameTheory/
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

### Implementation (66)

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
| [Circular Array Rotation](https://www.hackerrank.com/challenges/circular-array-rotation) | Easy | Index arithmetic, no rotation | [CircularArrayRotation.cs](src/HackerRank.Solutions/Implementation/CircularArrayRotation.cs) |
| [Sequence Equation](https://www.hackerrank.com/challenges/permutation-equation) | Easy | Inverse permutation | [SequenceEquation.cs](src/HackerRank.Solutions/Implementation/SequenceEquation.cs) |
| [Jumping on the Clouds: Revisited](https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited) | Easy | Circular simulation | [JumpingOnTheCloudsRevisited.cs](src/HackerRank.Solutions/Implementation/JumpingOnTheCloudsRevisited.cs) |
| [Cut the Sticks](https://www.hackerrank.com/challenges/cut-the-sticks) | Easy | Sort + distinct boundaries | [CutTheSticks.cs](src/HackerRank.Solutions/Implementation/CutTheSticks.cs) |
| [Non-Divisible Subset](https://www.hackerrank.com/challenges/non-divisible-subset) | Medium | Remainder classes | [NonDivisibleSubset.cs](src/HackerRank.Solutions/Implementation/NonDivisibleSubset.cs) |
| [ACM ICPC Team](https://www.hackerrank.com/challenges/acm-icpc-team) | Easy | Pairwise bitwise OR | [AcmIcpcTeam.cs](src/HackerRank.Solutions/Implementation/AcmIcpcTeam.cs) |
| [Taum and B'day](https://www.hackerrank.com/challenges/taum-and-bday) | Easy | Cheapest of buy vs. convert | [TaumAndBday.cs](src/HackerRank.Solutions/Implementation/TaumAndBday.cs) |
| [Modified Kaprekar Numbers](https://www.hackerrank.com/challenges/kaprekar-numbers) | Easy | Split the square | [ModifiedKaprekarNumbers.cs](src/HackerRank.Solutions/Implementation/ModifiedKaprekarNumbers.cs) |
| [Beautiful Triplets](https://www.hackerrank.com/challenges/beautiful-triplets) | Easy | Frequency product, O(n) | [BeautifulTriplets.cs](src/HackerRank.Solutions/Implementation/BeautifulTriplets.cs) |
| [Minimum Distances](https://www.hackerrank.com/challenges/minimum-distances) | Easy | Last-seen index map | [MinimumDistances.cs](src/HackerRank.Solutions/Implementation/MinimumDistances.cs) |
| [Halloween Sale](https://www.hackerrank.com/challenges/halloween-sale) | Easy | Simulation | [HalloweenSale.cs](src/HackerRank.Solutions/Implementation/HalloweenSale.cs) |
| [Chocolate Feast](https://www.hackerrank.com/challenges/chocolate-feast) | Easy | Wrapper exchange loop | [ChocolateFeast.cs](src/HackerRank.Solutions/Implementation/ChocolateFeast.cs) |
| [Service Lane](https://www.hackerrank.com/challenges/service-lane) | Easy | Range minimum | [ServiceLane.cs](src/HackerRank.Solutions/Implementation/ServiceLane.cs) |
| [Lisa's Workbook](https://www.hackerrank.com/challenges/lisa-workbook) | Easy | Page simulation | [LisasWorkbook.cs](src/HackerRank.Solutions/Implementation/LisasWorkbook.cs) |
| [Flatland Space Stations](https://www.hackerrank.com/challenges/flatland-space-stations) | Easy | Gaps between sorted stations | [FlatlandSpaceStations.cs](src/HackerRank.Solutions/Implementation/FlatlandSpaceStations.cs) |
| [Fair Rations](https://www.hackerrank.com/challenges/fair-rations) | Easy | Greedy parity fix | [FairRations.cs](src/HackerRank.Solutions/Implementation/FairRations.cs) |
| [Cavity Map](https://www.hackerrank.com/challenges/cavity-map) | Easy | Neighbor comparison | [CavityMap.cs](src/HackerRank.Solutions/Implementation/CavityMap.cs) |
| [Manasa and Stones](https://www.hackerrank.com/challenges/manasa-and-stones) | Easy | Count the b-steps | [ManasaAndStones.cs](src/HackerRank.Solutions/Implementation/ManasaAndStones.cs) |
| [Happy Ladybugs](https://www.hackerrank.com/challenges/happy-ladybugs) | Easy | Case analysis + counting | [HappyLadybugs.cs](src/HackerRank.Solutions/Implementation/HappyLadybugs.cs) |
| [Strange Counter](https://www.hackerrank.com/challenges/strange-code) | Easy | Skip whole cycles, O(log t) | [StrangeCounter.cs](src/HackerRank.Solutions/Implementation/StrangeCounter.cs) |
| [Library Fine](https://www.hackerrank.com/challenges/library-fine) | Easy | Date comparison | [LibraryFine.cs](src/HackerRank.Solutions/Implementation/LibraryFine.cs) |
| [Extra Long Factorials](https://www.hackerrank.com/challenges/extra-long-factorials) | Medium | BigInteger | [ExtraLongFactorials.cs](src/HackerRank.Solutions/Implementation/ExtraLongFactorials.cs) |
| [Bigger is Greater](https://www.hackerrank.com/challenges/bigger-is-greater) | Medium | Next permutation | [BiggerIsGreater.cs](src/HackerRank.Solutions/Implementation/BiggerIsGreater.cs) |
| [Organizing Containers of Balls](https://www.hackerrank.com/challenges/organizing-containers-of-balls) | Medium | Compare sorted row / column sums | [OrganizingContainers.cs](src/HackerRank.Solutions/Implementation/OrganizingContainers.cs) |
| [Encryption](https://www.hackerrank.com/challenges/encryption) | Medium | Column-wise grid read | [Encryption.cs](src/HackerRank.Solutions/Implementation/Encryption.cs) |
| [Queen's Attack II](https://www.hackerrank.com/challenges/queens-attack-2) | Medium | Nearest obstacle per direction, O(k) | [QueensAttackII.cs](src/HackerRank.Solutions/Implementation/QueensAttackII.cs) |
| [Forming a Magic Square](https://www.hackerrank.com/challenges/magic-square-forming) | Medium | Compare against all 8 magic squares | [FormingAMagicSquare.cs](src/HackerRank.Solutions/Implementation/FormingAMagicSquare.cs) |
| [Drawing Book](https://www.hackerrank.com/challenges/drawing-book) | Easy | Turns from front vs. back | [DrawingBook.cs](src/HackerRank.Solutions/Implementation/DrawingBook.cs) |
| [3D Surface Area](https://www.hackerrank.com/challenges/3d-surface-area) | Medium | Exposed faces per stack | [SurfaceArea3D.cs](src/HackerRank.Solutions/Implementation/SurfaceArea3D.cs) |
| [Almost Sorted](https://www.hackerrank.com/challenges/almost-sorted) | Medium | Diff against sorted, try swap then reverse | [AlmostSorted.cs](src/HackerRank.Solutions/Implementation/AlmostSorted.cs) |
| [Absolute Permutation](https://www.hackerrank.com/challenges/absolute-permutation) | Medium | Blocks of size k | [AbsolutePermutation.cs](src/HackerRank.Solutions/Implementation/AbsolutePermutation.cs) |
| [The Grid Search](https://www.hackerrank.com/challenges/the-grid-search) | Medium | 2D pattern matching | [TheGridSearch.cs](src/HackerRank.Solutions/Implementation/TheGridSearch.cs) |
| [Larry's Array](https://www.hackerrank.com/challenges/larrys-array) | Medium | Inversion parity | [LarrysArray.cs](src/HackerRank.Solutions/Implementation/LarrysArray.cs) |
| [The Time in Words](https://www.hackerrank.com/challenges/the-time-in-words) | Medium | Pattern matching on minutes | [TheTimeInWords.cs](src/HackerRank.Solutions/Implementation/TheTimeInWords.cs) |
| [The Bomberman Game](https://www.hackerrank.com/challenges/bomber-man) | Medium | Period-4 states, at most two detonations | [TheBombermanGame.cs](src/HackerRank.Solutions/Implementation/TheBombermanGame.cs) |
| [Ema's Supercomputer](https://www.hackerrank.com/challenges/two-pluses) | Medium | Enumerate pluses, try every pair | [EmasSupercomputer.cs](src/HackerRank.Solutions/Implementation/EmasSupercomputer.cs) |
| [Matrix Layer Rotation](https://www.hackerrank.com/challenges/matrix-rotation-algo) | Hard | Rotate each ring by r mod length | [MatrixLayerRotation.cs](src/HackerRank.Solutions/Implementation/MatrixLayerRotation.cs) |

### Strings (31)

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
| [Two Characters](https://www.hackerrank.com/challenges/two-characters) | Easy | Try every letter pair | [TwoCharacters.cs](src/HackerRank.Solutions/Strings/TwoCharacters.cs) |
| [Sherlock and the Valid String](https://www.hackerrank.com/challenges/sherlock-and-valid-string) | Medium | Frequency of frequencies | [SherlockAndTheValidString.cs](src/HackerRank.Solutions/Strings/SherlockAndTheValidString.cs) |
| [Sherlock and Anagrams](https://www.hackerrank.com/challenges/sherlock-and-anagrams) | Medium | Substring signatures + C(n, 2) | [SherlockAndAnagrams.cs](src/HackerRank.Solutions/Strings/SherlockAndAnagrams.cs) |
| [Common Child](https://www.hackerrank.com/challenges/common-child) | Medium | LCS dynamic programming, O(m) memory | [CommonChild.cs](src/HackerRank.Solutions/Strings/CommonChild.cs) |
| [Highest Value Palindrome](https://www.hackerrank.com/challenges/richie-rich) | Medium | Two-pass greedy with change tracking | [HighestValuePalindrome.cs](src/HackerRank.Solutions/Strings/HighestValuePalindrome.cs) |
| [Special String Again](https://www.hackerrank.com/challenges/special-palindrome-again) | Medium | Run-length encoding, O(n) | [SpecialStringAgain.cs](src/HackerRank.Solutions/Strings/SpecialStringAgain.cs) |
| [Bear and Steady Gene](https://www.hackerrank.com/challenges/bear-and-steady-gene) | Medium | Sliding window | [BearAndSteadyGene.cs](src/HackerRank.Solutions/Strings/BearAndSteadyGene.cs) |
| [Maximum Palindromes](https://www.hackerrank.com/challenges/maximum-palindromes) | Medium | Prefix counts + modular inverse factorials | [MaximumPalindromes.cs](src/HackerRank.Solutions/Strings/MaximumPalindromes.cs) |
| [String Similarity](https://www.hackerrank.com/challenges/string-similarity) | Advanced | Z-algorithm, O(n) | [StringSimilarity.cs](src/HackerRank.Solutions/Strings/StringSimilarity.cs) |
| [Morgan and a String](https://www.hackerrank.com/challenges/morgan-and-a-string) | Expert | Suffix comparison with a sentinel | [MorganAndAString.cs](src/HackerRank.Solutions/Strings/MorganAndAString.cs) |
| [Short Palindrome](https://www.hackerrank.com/challenges/short-palindrome) | Medium | Counts of "x", "xy", "xyy" per letter pair | [ShortPalindrome.cs](src/HackerRank.Solutions/Strings/ShortPalindrome.cs) |

### Data Structures (49)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Arrays - DS](https://www.hackerrank.com/challenges/arrays-ds) | Easy | Two-pointer reversal | [ArraysDS.cs](src/HackerRank.Solutions/DataStructures/ArraysDS.cs) |
| [2D Array - DS](https://www.hackerrank.com/challenges/2d-array) | Easy | Grid scan | [HourglassSum.cs](src/HackerRank.Solutions/DataStructures/HourglassSum.cs) |
| [Left Rotation](https://www.hackerrank.com/challenges/array-left-rotation) | Easy | Index arithmetic | [LeftRotation.cs](src/HackerRank.Solutions/DataStructures/LeftRotation.cs) |
| [Sparse Arrays](https://www.hackerrank.com/challenges/sparse-arrays) | Medium | Frequency dictionary | [SparseArrays.cs](src/HackerRank.Solutions/DataStructures/SparseArrays.cs) |
| [Balanced Brackets](https://www.hackerrank.com/challenges/balanced-brackets) | Medium | Stack | [BalancedBrackets.cs](src/HackerRank.Solutions/DataStructures/BalancedBrackets.cs) |
| [Dynamic Array](https://www.hackerrank.com/challenges/dynamic-array) | Easy | List of lists + XOR indexing | [DynamicArray.cs](src/HackerRank.Solutions/DataStructures/DynamicArray.cs) |
| [Maximum Element](https://www.hackerrank.com/challenges/maximum-element) | Easy | Stack of running maxima, O(1) ops | [MaximumElement.cs](src/HackerRank.Solutions/DataStructures/MaximumElement.cs) |
| [Equal Stacks](https://www.hackerrank.com/challenges/equal-stacks) | Easy | Shrink the tallest | [EqualStacks.cs](src/HackerRank.Solutions/DataStructures/EqualStacks.cs) |
| [Queue using Two Stacks](https://www.hackerrank.com/challenges/queue-using-two-stacks) | Medium | Lazy inbox / outbox, amortized O(1) | [QueueUsingTwoStacks.cs](src/HackerRank.Solutions/DataStructures/QueueUsingTwoStacks.cs) |
| [Game of Two Stacks](https://www.hackerrank.com/challenges/game-of-two-stacks) | Medium | Greedy + sliding exchange | [GameOfTwoStacks.cs](src/HackerRank.Solutions/DataStructures/GameOfTwoStacks.cs) |
| [Largest Rectangle](https://www.hackerrank.com/challenges/largest-rectangle) | Medium | Monotonic stack, O(n) | [LargestRectangle.cs](src/HackerRank.Solutions/DataStructures/LargestRectangle.cs) |
| [Simple Text Editor](https://www.hackerrank.com/challenges/simple-text-editor) | Medium | Undo stack of inverse operations | [SimpleTextEditor.cs](src/HackerRank.Solutions/DataStructures/SimpleTextEditor.cs) |
| [Jesse and Cookies](https://www.hackerrank.com/challenges/jesse-and-cookies) | Easy | Min-heap (PriorityQueue) | [JesseAndCookies.cs](src/HackerRank.Solutions/DataStructures/JesseAndCookies.cs) |
| [QHEAP1](https://www.hackerrank.com/challenges/qheap1) | Easy | SortedSet as a deletable heap | [Qheap1.cs](src/HackerRank.Solutions/DataStructures/Qheap1.cs) |
| [Truck Tour](https://www.hackerrank.com/challenges/truck-tour) | Medium | Single pass with restart | [TruckTour.cs](src/HackerRank.Solutions/DataStructures/TruckTour.cs) |
| [Contacts](https://www.hackerrank.com/challenges/contacts) | Medium | Trie with prefix counts | [Contacts.cs](src/HackerRank.Solutions/DataStructures/Contacts.cs) |
| [Array Manipulation](https://www.hackerrank.com/challenges/crush) | Hard | Difference array, O(n + m) | [ArrayManipulation.cs](src/HackerRank.Solutions/DataStructures/ArrayManipulation.cs) |
| [Reverse a Linked List](https://www.hackerrank.com/challenges/reverse-a-linked-list) | Easy | Pointer reversal | [ReverseLinkedList.cs](src/HackerRank.Solutions/DataStructures/ReverseLinkedList.cs) |
| [Merge Two Sorted Linked Lists](https://www.hackerrank.com/challenges/merge-two-sorted-linked-lists) | Easy | Dummy head splice | [MergeTwoSortedLists.cs](src/HackerRank.Solutions/DataStructures/MergeTwoSortedLists.cs) |
| [Insert a Node at a Specific Position](https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list) | Easy | Walk to predecessor | [InsertNodeAtPosition.cs](src/HackerRank.Solutions/DataStructures/InsertNodeAtPosition.cs) |
| [Delete Duplicate-Value Nodes](https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list) | Easy | Unlink adjacent duplicates | [DeleteDuplicateValueNodes.cs](src/HackerRank.Solutions/DataStructures/DeleteDuplicateValueNodes.cs) |
| [Find Merge Point of Two Lists](https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists) | Easy | Pointer switching, O(1) memory | [FindMergePoint.cs](src/HackerRank.Solutions/DataStructures/FindMergePoint.cs) |
| [Cycle Detection](https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle) | Medium | Floyd's tortoise and hare | [CycleDetection.cs](src/HackerRank.Solutions/DataStructures/CycleDetection.cs) |
| [Tree: Preorder Traversal](https://www.hackerrank.com/challenges/tree-preorder-traversal) | Easy | Recursive DFS | [TreeTraversals.cs](src/HackerRank.Solutions/DataStructures/TreeTraversals.cs) |
| [Tree: Inorder Traversal](https://www.hackerrank.com/challenges/tree-inorder-traversal) | Easy | Recursive DFS | [TreeTraversals.cs](src/HackerRank.Solutions/DataStructures/TreeTraversals.cs) |
| [Tree: Postorder Traversal](https://www.hackerrank.com/challenges/tree-postorder-traversal) | Easy | Recursive DFS | [TreeTraversals.cs](src/HackerRank.Solutions/DataStructures/TreeTraversals.cs) |
| [Tree: Height of a Binary Tree](https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree) | Easy | Recursion | [TreeHeight.cs](src/HackerRank.Solutions/DataStructures/TreeHeight.cs) |
| [Tree: Level Order Traversal](https://www.hackerrank.com/challenges/tree-level-order-traversal) | Easy | BFS with a queue | [LevelOrderTraversal.cs](src/HackerRank.Solutions/DataStructures/LevelOrderTraversal.cs) |
| [Binary Search Tree: Insertion](https://www.hackerrank.com/challenges/binary-search-tree-insertion) | Medium | Iterative descent | [BstInsertion.cs](src/HackerRank.Solutions/DataStructures/BstInsertion.cs) |
| [Binary Search Tree: Lowest Common Ancestor](https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor) | Easy | Split point, O(height) | [BstLowestCommonAncestor.cs](src/HackerRank.Solutions/DataStructures/BstLowestCommonAncestor.cs) |
| [Is This a Binary Search Tree?](https://www.hackerrank.com/challenges/is-binary-search-tree) | Medium | Ancestor bounds | [IsBinarySearchTree.cs](src/HackerRank.Solutions/DataStructures/IsBinarySearchTree.cs) |
| [Get Node Value](https://www.hackerrank.com/challenges/get-the-value-of-the-node-at-a-specific-position-from-the-tail) | Easy | Lead and trail pointers | [GetNodeValue.cs](src/HackerRank.Solutions/DataStructures/GetNodeValue.cs) |
| [Compare two linked lists](https://www.hackerrank.com/challenges/compare-two-linked-lists) | Easy | Walk in lockstep | [CompareTwoLinkedLists.cs](src/HackerRank.Solutions/DataStructures/CompareTwoLinkedLists.cs) |
| [Delete a Node](https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list) | Easy | Relink the predecessor | [DeleteNode.cs](src/HackerRank.Solutions/DataStructures/DeleteNode.cs) |
| [Tree: Top View](https://www.hackerrank.com/challenges/tree-top-view) | Easy | Level order with column offsets | [TopView.cs](src/HackerRank.Solutions/DataStructures/TopView.cs) |
| [Swap Nodes [Algo]](https://www.hackerrank.com/challenges/swap-nodes-algo) | Medium | Child arrays, iterative in-order | [SwapNodes.cs](src/HackerRank.Solutions/DataStructures/SwapNodes.cs) |
| [Waiter](https://www.hackerrank.com/challenges/waiter) | Medium | Stack simulation | [Waiter.cs](src/HackerRank.Solutions/DataStructures/Waiter.cs) |
| [Down to Zero II](https://www.hackerrank.com/challenges/down-to-zero-ii) | Medium | Forward DP over factor pairs | [DownToZeroII.cs](src/HackerRank.Solutions/DataStructures/DownToZeroII.cs) |
| [Castle on the Grid](https://www.hackerrank.com/challenges/castle-on-the-grid) | Medium | BFS with sliding moves | [CastleOnTheGrid.cs](src/HackerRank.Solutions/DataStructures/CastleOnTheGrid.cs) |
| [Poisonous Plants](https://www.hackerrank.com/challenges/poisonous-plants) | Hard | Monotonic stack of death days | [PoisonousPlants.cs](src/HackerRank.Solutions/DataStructures/PoisonousPlants.cs) |
| [AND xor OR](https://www.hackerrank.com/challenges/and-xor-or) | Hard | Simplifies to XOR; monotonic stack | [AndXorOr.cs](src/HackerRank.Solutions/DataStructures/AndXorOr.cs) |
| [Find the Running Median](https://www.hackerrank.com/challenges/find-the-running-median) | Hard | Two heaps | [FindTheRunningMedian.cs](src/HackerRank.Solutions/DataStructures/FindTheRunningMedian.cs) |
| [Minimum Average Waiting Time](https://www.hackerrank.com/challenges/minimum-average-waiting-time) | Hard | Shortest job first with a heap | [MinimumAverageWaitingTime.cs](src/HackerRank.Solutions/DataStructures/MinimumAverageWaitingTime.cs) |
| [No Prefix Set](https://www.hackerrank.com/challenges/no-prefix-set) | Hard | Trie insertion | [NoPrefixSet.cs](src/HackerRank.Solutions/DataStructures/NoPrefixSet.cs) |
| [Reverse a doubly linked list](https://www.hackerrank.com/challenges/reverse-a-doubly-linked-list) | Easy | Swap Next and Prev | [ReverseDoublyLinkedList.cs](src/HackerRank.Solutions/DataStructures/ReverseDoublyLinkedList.cs) |
| [Inserting a Node Into a Sorted Doubly Linked List](https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list) | Easy | Find predecessor, relink both ways | [SortedInsertDoublyLinkedList.cs](src/HackerRank.Solutions/DataStructures/SortedInsertDoublyLinkedList.cs) |
| [Merging Communities](https://www.hackerrank.com/challenges/merging-communities) | Hard | Union-find with sizes | [MergingCommunities.cs](src/HackerRank.Solutions/DataStructures/MergingCommunities.cs) |
| [Jim and the Skyscrapers](https://www.hackerrank.com/challenges/jim-and-the-skyscrapers) | Medium | Decreasing stack of (height, count) | [JimAndTheSkyscrapers.cs](src/HackerRank.Solutions/DataStructures/JimAndTheSkyscrapers.cs) |
| [Queries with Fixed Length](https://www.hackerrank.com/challenges/queries-with-fixed-length) | Hard | Monotonic deque per query | [QueriesWithFixedLength.cs](src/HackerRank.Solutions/DataStructures/QueriesWithFixedLength.cs) |

### Sorting (15)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Big Sorting](https://www.hackerrank.com/challenges/big-sorting) | Easy | Length, then ordinal compare | [BigSorting.cs](src/HackerRank.Solutions/Sorting/BigSorting.cs) |
| [Mark and Toys](https://www.hackerrank.com/challenges/mark-and-toys) | Easy | Sort + greedy | [MarkAndToys.cs](src/HackerRank.Solutions/Sorting/MarkAndToys.cs) |
| [Find the Median](https://www.hackerrank.com/challenges/find-the-median) | Easy | Sort | [FindTheMedian.cs](src/HackerRank.Solutions/Sorting/FindTheMedian.cs) |
| [Closest Numbers](https://www.hackerrank.com/challenges/closest-numbers) | Easy | Sort + adjacent pairs | [ClosestNumbers.cs](src/HackerRank.Solutions/Sorting/ClosestNumbers.cs) |
| [Fraudulent Activity Notifications](https://www.hackerrank.com/challenges/fraudulent-activity-notifications) | Medium | Counting-sort sliding window | [FraudulentActivityNotifications.cs](src/HackerRank.Solutions/Sorting/FraudulentActivityNotifications.cs) |
| [Intro to Tutorial Challenges](https://www.hackerrank.com/challenges/tutorial-intro) | Easy | Binary search | [IntroToTutorialChallenges.cs](src/HackerRank.Solutions/Sorting/IntroToTutorialChallenges.cs) |
| [Running Time of Algorithms](https://www.hackerrank.com/challenges/runningtime) | Easy | Count insertion-sort shifts | [RunningTimeOfAlgorithms.cs](src/HackerRank.Solutions/Sorting/RunningTimeOfAlgorithms.cs) |
| [Quicksort 1 - Partition](https://www.hackerrank.com/challenges/quicksort1) | Easy | Stable three-way partition | [QuicksortPartition.cs](src/HackerRank.Solutions/Sorting/QuicksortPartition.cs) |
| [Counting Sort 1](https://www.hackerrank.com/challenges/countingsort1) | Easy | Frequency array | [CountingSort1.cs](src/HackerRank.Solutions/Sorting/CountingSort1.cs) |
| [Lily's Homework](https://www.hackerrank.com/challenges/lilys-homework) | Medium | Minimum swaps, both orders | [LilysHomework.cs](src/HackerRank.Solutions/Sorting/LilysHomework.cs) |
| [Insertion Sort - Part 1](https://www.hackerrank.com/challenges/insertionsort1) | Easy | Shift right, print each step | [InsertionSort1.cs](src/HackerRank.Solutions/Sorting/InsertionSort1.cs) |
| [Insertion Sort - Part 2](https://www.hackerrank.com/challenges/insertionsort2) | Easy | Full insertion sort | [InsertionSort2.cs](src/HackerRank.Solutions/Sorting/InsertionSort2.cs) |
| [Counting Sort 2](https://www.hackerrank.com/challenges/countingsort2) | Easy | Frequency array | [CountingSort2.cs](src/HackerRank.Solutions/Sorting/CountingSort2.cs) |
| [The Full Counting Sort](https://www.hackerrank.com/challenges/countingsort4) | Medium | Stable buckets | [TheFullCountingSort.cs](src/HackerRank.Solutions/Sorting/TheFullCountingSort.cs) |
| [Insertion Sort Advanced Analysis](https://www.hackerrank.com/challenges/insertion-sort) | Advanced | Inversions via merge sort | [InsertionSortAdvancedAnalysis.cs](src/HackerRank.Solutions/Sorting/InsertionSortAdvancedAnalysis.cs) |

### Search (14)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Ice Cream Parlor](https://www.hackerrank.com/challenges/icecream-parlor) | Easy | Two-sum with a dictionary | [IceCreamParlor.cs](src/HackerRank.Solutions/Search/IceCreamParlor.cs) |
| [Missing Numbers](https://www.hackerrank.com/challenges/missing-numbers) | Easy | Frequency balance | [MissingNumbers.cs](src/HackerRank.Solutions/Search/MissingNumbers.cs) |
| [Sherlock and Array](https://www.hackerrank.com/challenges/sherlock-and-array) | Easy | Prefix sums | [SherlockAndArray.cs](src/HackerRank.Solutions/Search/SherlockAndArray.cs) |
| [Pairs](https://www.hackerrank.com/challenges/pairs) | Medium | HashSet lookup, O(n) | [Pairs.cs](src/HackerRank.Solutions/Search/Pairs.cs) |
| [Minimum Loss](https://www.hackerrank.com/challenges/minimum-loss) | Medium | Sort, check adjacent pairs | [MinimumLoss.cs](src/HackerRank.Solutions/Search/MinimumLoss.cs) |
| [Connected Cells in a Grid](https://www.hackerrank.com/challenges/connected-cell-in-a-grid) | Medium | Iterative flood fill | [ConnectedCellsInAGrid.cs](src/HackerRank.Solutions/Search/ConnectedCellsInAGrid.cs) |
| [Hackerland Radio Transmitters](https://www.hackerrank.com/challenges/hackerland-radio-transmitters) | Medium | Greedy placement | [HackerlandRadioTransmitters.cs](src/HackerRank.Solutions/Search/HackerlandRadioTransmitters.cs) |
| [Count Triplets](https://www.hackerrank.com/challenges/count-triplets-1) | Medium | Left / right counts per middle term | [CountTriplets.cs](src/HackerRank.Solutions/Search/CountTriplets.cs) |
| [Gridland Metro](https://www.hackerrank.com/challenges/gridland-metro) | Medium | Merge intervals per row | [GridlandMetro.cs](src/HackerRank.Solutions/Search/GridlandMetro.cs) |
| [KnightL on a Chessboard](https://www.hackerrank.com/challenges/knightl-on-chessboard) | Medium | BFS per move pair | [KnightLOnAChessboard.cs](src/HackerRank.Solutions/Search/KnightLOnAChessboard.cs) |
| [Count Luck](https://www.hackerrank.com/challenges/count-luck) | Medium | BFS parents, count forks on the path | [CountLuck.cs](src/HackerRank.Solutions/Search/CountLuck.cs) |
| [Cut the Tree](https://www.hackerrank.com/challenges/cut-the-tree) | Medium | Subtree sums | [CutTheTree.cs](src/HackerRank.Solutions/Search/CutTheTree.cs) |
| [Maximum Subarray Sum](https://www.hackerrank.com/challenges/maximum-subarray-sum) | Hard | Prefix sums in a sorted set | [MaximumSubarraySum.cs](src/HackerRank.Solutions/Search/MaximumSubarraySum.cs) |
| [Red Knight's Shortest Path](https://www.hackerrank.com/challenges/red-knights-shortest-path) | Medium | BFS from target, greedy walk by priority | [RedKnightsShortestPath.cs](src/HackerRank.Solutions/Search/RedKnightsShortestPath.cs) |

### Greedy (20)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Minimum Absolute Difference in an Array](https://www.hackerrank.com/challenges/minimum-absolute-difference-in-an-array) | Easy | Sort + adjacent scan | [MinimumAbsoluteDifference.cs](src/HackerRank.Solutions/Greedy/MinimumAbsoluteDifference.cs) |
| [Luck Balance](https://www.hackerrank.com/challenges/luck-balance) | Easy | Lose the k luckiest important contests | [LuckBalance.cs](src/HackerRank.Solutions/Greedy/LuckBalance.cs) |
| [Grid Challenge](https://www.hackerrank.com/challenges/grid-challenge) | Easy | Sort rows, check columns | [GridChallenge.cs](src/HackerRank.Solutions/Greedy/GridChallenge.cs) |
| [Jim and the Orders](https://www.hackerrank.com/challenges/jim-and-the-orders) | Easy | Sort by completion time | [JimAndTheOrders.cs](src/HackerRank.Solutions/Greedy/JimAndTheOrders.cs) |
| [Max Min](https://www.hackerrank.com/challenges/angry-children) | Medium | Sort + sliding window | [MaxMin.cs](src/HackerRank.Solutions/Greedy/MaxMin.cs) |
| [Greedy Florist](https://www.hackerrank.com/challenges/greedy-florist) | Medium | Most expensive first, round-robin | [GreedyFlorist.cs](src/HackerRank.Solutions/Greedy/GreedyFlorist.cs) |
| [Marc's Cakewalk](https://www.hackerrank.com/challenges/marcs-cakewalk) | Easy | Largest calories first | [MarcsCakewalk.cs](src/HackerRank.Solutions/Greedy/MarcsCakewalk.cs) |
| [Sherlock and The Beast](https://www.hackerrank.com/challenges/sherlock-and-the-beast) | Easy | Maximize leading 5s | [SherlockAndTheBeast.cs](src/HackerRank.Solutions/Greedy/SherlockAndTheBeast.cs) |
| [Priyanka and Toys](https://www.hackerrank.com/challenges/priyanka-and-toys) | Easy | Sort + interval cover | [PriyankaAndToys.cs](src/HackerRank.Solutions/Greedy/PriyankaAndToys.cs) |
| [Permuting Two Arrays](https://www.hackerrank.com/challenges/two-arrays) | Easy | Opposite-order pairing | [PermutingTwoArrays.cs](src/HackerRank.Solutions/Greedy/PermutingTwoArrays.cs) |
| [Beautiful Pairs](https://www.hackerrank.com/challenges/beautiful-pairs) | Easy | Multiset matching | [BeautifulPairs.cs](src/HackerRank.Solutions/Greedy/BeautifulPairs.cs) |
| [Largest Permutation](https://www.hackerrank.com/challenges/largest-permutation) | Easy | Position index, O(n) swaps | [LargestPermutation.cs](src/HackerRank.Solutions/Greedy/LargestPermutation.cs) |
| [Chief Hopper](https://www.hackerrank.com/challenges/chief-hopper) | Hard | Work backwards, O(n) | [ChiefHopper.cs](src/HackerRank.Solutions/Greedy/ChiefHopper.cs) |
| [Maximum Perimeter Triangle](https://www.hackerrank.com/challenges/maximum-perimeter-triangle) | Easy | Sort descending, first valid triple | [MaximumPerimeterTriangle.cs](src/HackerRank.Solutions/Greedy/MaximumPerimeterTriangle.cs) |
| [Flipping the Matrix](https://www.hackerrank.com/challenges/flipping-the-matrix) | Medium | Max of each mirror quartet | [FlippingTheMatrix.cs](src/HackerRank.Solutions/Greedy/FlippingTheMatrix.cs) |
| [Goodland Electricity](https://www.hackerrank.com/challenges/pylons) | Medium | Rightmost plant that covers | [GoodlandElectricity.cs](src/HackerRank.Solutions/Greedy/GoodlandElectricity.cs) |
| [Cutting Boards](https://www.hackerrank.com/challenges/board-cutting) | Hard | Most expensive cut first | [CuttingBoards.cs](src/HackerRank.Solutions/Greedy/CuttingBoards.cs) |
| [Reverse Shuffle Merge](https://www.hackerrank.com/challenges/reverse-shuffle-merge) | Advanced | Monotonic stack with skip budget | [ReverseShuffleMerge.cs](src/HackerRank.Solutions/Greedy/ReverseShuffleMerge.cs) |
| [Sherlock and MiniMax](https://www.hackerrank.com/challenges/sherlock-and-minimax) | Hard | Range ends + adjacent midpoints | [SherlockAndMinimax.cs](src/HackerRank.Solutions/Greedy/SherlockAndMinimax.cs) |
| [Making Candies](https://www.hackerrank.com/challenges/making-candies) | Hard | Buy balanced, track "wait from here" | [MakingCandies.cs](src/HackerRank.Solutions/Greedy/MakingCandies.cs) |

### Dynamic Programming (20)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [The Coin Change Problem](https://www.hackerrank.com/challenges/coin-change) | Medium | Combinations DP, O(n · coins) | [CoinChange.cs](src/HackerRank.Solutions/DynamicProgramming/CoinChange.cs) |
| [Fibonacci Modified](https://www.hackerrank.com/challenges/fibonacci-modified) | Medium | Iterative BigInteger | [FibonacciModified.cs](src/HackerRank.Solutions/DynamicProgramming/FibonacciModified.cs) |
| [Equal](https://www.hackerrank.com/challenges/equal) | Medium | Reverse the operation + 5/2/1 greedy | [Equal.cs](src/HackerRank.Solutions/DynamicProgramming/Equal.cs) |
| [Sam and Substrings](https://www.hackerrank.com/challenges/sam-and-substrings) | Medium | Running suffix sum, mod 10⁹+7 | [SamAndSubstrings.cs](src/HackerRank.Solutions/DynamicProgramming/SamAndSubstrings.cs) |
| [Stock Maximize](https://www.hackerrank.com/challenges/stockmax) | Medium | Backward scan of future maximum | [StockMaximize.cs](src/HackerRank.Solutions/DynamicProgramming/StockMaximize.cs) |
| [Max Array Sum](https://www.hackerrank.com/challenges/max-array-sum) | Medium | Non-adjacent DP, O(1) memory | [MaxArraySum.cs](src/HackerRank.Solutions/DynamicProgramming/MaxArraySum.cs) |
| [Candies](https://www.hackerrank.com/challenges/candies) | Medium | Two directional passes | [Candies.cs](src/HackerRank.Solutions/DynamicProgramming/Candies.cs) |
| [Sherlock and Cost](https://www.hackerrank.com/challenges/sherlock-and-cost) | Medium | Two-state DP (low / high) | [SherlockAndCost.cs](src/HackerRank.Solutions/DynamicProgramming/SherlockAndCost.cs) |
| [Abbreviation](https://www.hackerrank.com/challenges/abbr) | Medium | 2D reachability DP | [Abbreviation.cs](src/HackerRank.Solutions/DynamicProgramming/Abbreviation.cs) |
| [Knapsack](https://www.hackerrank.com/challenges/unbounded-knapsack) | Medium | Unbounded subset-sum DP | [Knapsack.cs](src/HackerRank.Solutions/DynamicProgramming/Knapsack.cs) |
| [The Longest Increasing Subsequence](https://www.hackerrank.com/challenges/longest-increasing-subsequent) | Advanced | Patience sorting, O(n log n) | [LongestIncreasingSubsequence.cs](src/HackerRank.Solutions/DynamicProgramming/LongestIncreasingSubsequence.cs) |
| [The Maximum Subarray](https://www.hackerrank.com/challenges/maxsubarray) | Medium | Kadane + sum of positives | [MaximumSubarray.cs](src/HackerRank.Solutions/DynamicProgramming/MaximumSubarray.cs) |
| [Red John is Back](https://www.hackerrank.com/challenges/red-john-is-back) | Medium | Tiling recurrence + sieve | [RedJohnIsBack.cs](src/HackerRank.Solutions/DynamicProgramming/RedJohnIsBack.cs) |
| [Construct the Array](https://www.hackerrank.com/challenges/construct-the-array) | Medium | Two-state DP by symmetry | [ConstructTheArray.cs](src/HackerRank.Solutions/DynamicProgramming/ConstructTheArray.cs) |
| [The Mandragora Forest](https://www.hackerrank.com/challenges/mandragora) | Medium | Sort + suffix sums | [MandragoraForest.cs](src/HackerRank.Solutions/DynamicProgramming/MandragoraForest.cs) |
| [Lego Blocks](https://www.hackerrank.com/challenges/lego-blocks) | Medium | All walls minus walls with a first break | [LegoBlocks.cs](src/HackerRank.Solutions/DynamicProgramming/LegoBlocks.cs) |
| [The Longest Common Subsequence](https://www.hackerrank.com/challenges/dynamic-programming-classics-the-longest-common-subsequence) | Medium | LCS table + backtrack | [LongestCommonSubsequence.cs](src/HackerRank.Solutions/DynamicProgramming/LongestCommonSubsequence.cs) |
| [Bricks Game](https://www.hackerrank.com/challenges/play-game) | Medium | Suffix sum minus opponent's best | [BricksGame.cs](src/HackerRank.Solutions/DynamicProgramming/BricksGame.cs) |
| [Summing Pieces](https://www.hackerrank.com/challenges/summing-pieces) | Medium | Per-element coefficients, O(n) | [SummingPieces.cs](src/HackerRank.Solutions/DynamicProgramming/SummingPieces.cs) |
| [Play with words](https://www.hackerrank.com/challenges/strplay) | Medium | LPS table + best split | [PlayWithWords.cs](src/HackerRank.Solutions/DynamicProgramming/PlayWithWords.cs) |

### Recursion (7)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Recursive Digit Sum](https://www.hackerrank.com/challenges/recursive-digit-sum) | Medium | Sum once, multiply by k | [RecursiveDigitSum.cs](src/HackerRank.Solutions/Recursion/RecursiveDigitSum.cs) |
| [The Power Sum](https://www.hackerrank.com/challenges/the-power-sum) | Medium | Include / exclude recursion | [ThePowerSum.cs](src/HackerRank.Solutions/Recursion/ThePowerSum.cs) |
| [Recursion: Fibonacci Numbers](https://www.hackerrank.com/challenges/ctci-fibonacci-numbers) | Easy | Memoized recursion | [FibonacciNumbers.cs](src/HackerRank.Solutions/Recursion/FibonacciNumbers.cs) |
| [Recursion: Davis' Staircase](https://www.hackerrank.com/challenges/ctci-recursive-staircase) | Medium | Memoized three-way recursion | [DavisStaircase.cs](src/HackerRank.Solutions/Recursion/DavisStaircase.cs) |
| [Password Cracker](https://www.hackerrank.com/challenges/password-cracker) | Medium | DFS with dead-end memo | [PasswordCracker.cs](src/HackerRank.Solutions/Recursion/PasswordCracker.cs) |
| [Crossword Puzzle](https://www.hackerrank.com/challenges/crossword-puzzle) | Medium | Backtracking over slots | [CrosswordPuzzle.cs](src/HackerRank.Solutions/Recursion/CrosswordPuzzle.cs) |
| [Nikita and the Game](https://www.hackerrank.com/challenges/array-splitting) | Medium | Binary-search the half-sum split | [NikitaAndTheGame.cs](src/HackerRank.Solutions/Recursion/NikitaAndTheGame.cs) |

### Bit Manipulation (13)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Lonely Integer](https://www.hackerrank.com/challenges/lonely-integer) | Easy | XOR cancellation | [LonelyInteger.cs](src/HackerRank.Solutions/BitManipulation/LonelyInteger.cs) |
| [Maximizing XOR](https://www.hackerrank.com/challenges/maximizing-xor) | Easy | Highest differing bit, O(1) | [MaximizingXor.cs](src/HackerRank.Solutions/BitManipulation/MaximizingXor.cs) |
| [Sum vs XOR](https://www.hackerrank.com/challenges/sum-vs-xor) | Easy | 2^(zero bits) | [SumVsXor.cs](src/HackerRank.Solutions/BitManipulation/SumVsXor.cs) |
| [Flipping Bits](https://www.hackerrank.com/challenges/flipping-bits) | Easy | 32-bit complement | [FlippingBits.cs](src/HackerRank.Solutions/BitManipulation/FlippingBits.cs) |
| [Counter Game](https://www.hackerrank.com/challenges/counter-game) | Medium | popcount(n - 1) parity | [CounterGame.cs](src/HackerRank.Solutions/BitManipulation/CounterGame.cs) |
| [The Great XOR](https://www.hackerrank.com/challenges/the-great-xor) | Medium | All-ones mask XOR x | [TheGreatXor.cs](src/HackerRank.Solutions/BitManipulation/TheGreatXor.cs) |
| [Sansa and XOR](https://www.hackerrank.com/challenges/sansa-and-xor) | Medium | Occurrence-count parity | [SansaAndXor.cs](src/HackerRank.Solutions/BitManipulation/SansaAndXor.cs) |
| [AND Product](https://www.hackerrank.com/challenges/and-product) | Medium | Common bit prefix | [AndProduct.cs](src/HackerRank.Solutions/BitManipulation/AndProduct.cs) |
| [Xor-sequence](https://www.hackerrank.com/challenges/xor-se) | Medium | Period-8 prefix XOR, O(1) | [XorSequence.cs](src/HackerRank.Solutions/BitManipulation/XorSequence.cs) |
| [Cipher](https://www.hackerrank.com/challenges/cipher) | Medium | Adjacent XOR undoes the shifts | [Cipher.cs](src/HackerRank.Solutions/BitManipulation/Cipher.cs) |
| [Yet Another Minimax Problem](https://www.hackerrank.com/challenges/yet-another-minimax-problem) | Medium | Split on highest differing bit | [YetAnotherMinimax.cs](src/HackerRank.Solutions/BitManipulation/YetAnotherMinimax.cs) |
| [Winning Lottery Ticket](https://www.hackerrank.com/challenges/winning-lottery-ticket) | Medium | Digit masks, 1024² pairs | [WinningLotteryTicket.cs](src/HackerRank.Solutions/BitManipulation/WinningLotteryTicket.cs) |
| [Xoring Ninja](https://www.hackerrank.com/challenges/xoring-ninja) | Medium | OR of all · 2^(n-1) | [XoringNinja.cs](src/HackerRank.Solutions/BitManipulation/XoringNinja.cs) |

### Graph Theory (16)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Breadth First Search: Shortest Reach](https://www.hackerrank.com/challenges/bfsshortreach) | Medium | BFS | [BfsShortestReach.cs](src/HackerRank.Solutions/GraphTheory/BfsShortestReach.cs) |
| [Roads and Libraries](https://www.hackerrank.com/challenges/torque-and-development) | Medium | Union-find components | [RoadsAndLibraries.cs](src/HackerRank.Solutions/GraphTheory/RoadsAndLibraries.cs) |
| [Journey to the Moon](https://www.hackerrank.com/challenges/journey-to-the-moon) | Medium | All pairs minus same-country pairs | [JourneyToTheMoon.cs](src/HackerRank.Solutions/GraphTheory/JourneyToTheMoon.cs) |
| [Even Tree](https://www.hackerrank.com/challenges/even-tree) | Medium | Count even subtrees | [EvenTree.cs](src/HackerRank.Solutions/GraphTheory/EvenTree.cs) |
| [Components in a graph](https://www.hackerrank.com/challenges/components-in-graph) | Medium | Union-find sizes | [ComponentsInAGraph.cs](src/HackerRank.Solutions/GraphTheory/ComponentsInAGraph.cs) |
| [Snakes and Ladders: The Quickest Way Up](https://www.hackerrank.com/challenges/the-quickest-way-up) | Medium | BFS over squares | [SnakesAndLadders.cs](src/HackerRank.Solutions/GraphTheory/SnakesAndLadders.cs) |
| [Kruskal (MST): Really Special Subtree](https://www.hackerrank.com/challenges/kruskalmstrsub) | Medium | Kruskal with union-find | [KruskalMst.cs](src/HackerRank.Solutions/GraphTheory/KruskalMst.cs) |
| [Prim's (MST): Special Subtree](https://www.hackerrank.com/challenges/primsmstsub) | Medium | Lazy Prim's with a heap | [PrimsMst.cs](src/HackerRank.Solutions/GraphTheory/PrimsMst.cs) |
| [Dijkstra: Shortest Reach 2](https://www.hackerrank.com/challenges/dijkstrashortreach) | Hard | Dijkstra with a binary heap | [DijkstraShortestReach.cs](src/HackerRank.Solutions/GraphTheory/DijkstraShortestReach.cs) |
| [Floyd : City of Blinding Lights](https://www.hackerrank.com/challenges/floyd-city-of-blinding-lights) | Hard | Floyd–Warshall | [FloydCityOfBlindingLights.cs](src/HackerRank.Solutions/GraphTheory/FloydCityOfBlindingLights.cs) |
| [Jack goes to Rapture](https://www.hackerrank.com/challenges/jack-goes-to-rapture) | Medium | Kruskal until 1 and n connect | [JackGoesToRapture.cs](src/HackerRank.Solutions/GraphTheory/JackGoesToRapture.cs) |
| [Find the nearest clone](https://www.hackerrank.com/challenges/find-the-nearest-clone) | Medium | Multi-source BFS | [FindTheNearestClone.cs](src/HackerRank.Solutions/GraphTheory/FindTheNearestClone.cs) |
| [Minimum Penalty Path](https://www.hackerrank.com/challenges/beautiful-path) | Medium | BFS over (node, OR) states | [MinimumPenaltyPath.cs](src/HackerRank.Solutions/GraphTheory/MinimumPenaltyPath.cs) |
| [Matrix](https://www.hackerrank.com/challenges/matrix) | Hard | Reverse Kruskal with machine flags | [MatrixMachines.cs](src/HackerRank.Solutions/GraphTheory/MatrixMachines.cs) |
| [Rust & Murderer](https://www.hackerrank.com/challenges/rust-murderer) | Hard | BFS on the complement graph | [RustAndMurderer.cs](src/HackerRank.Solutions/GraphTheory/RustAndMurderer.cs) |
| [Roads in HackerLand](https://www.hackerrank.com/challenges/johnland) | Hard | MST edge contributions, binary carry | [RoadsInHackerland.cs](src/HackerRank.Solutions/GraphTheory/RoadsInHackerland.cs) |

### Mathematics (22)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Find the Point](https://www.hackerrank.com/challenges/find-point) | Easy | Reflection: 2q - p | [FindThePoint.cs](src/HackerRank.Solutions/Mathematics/FindThePoint.cs) |
| [Maximum Draws](https://www.hackerrank.com/challenges/maximum-draws) | Easy | Pigeonhole | [MaximumDraws.cs](src/HackerRank.Solutions/Mathematics/MaximumDraws.cs) |
| [Handshake](https://www.hackerrank.com/challenges/handshake) | Easy | n choose 2 | [Handshake.cs](src/HackerRank.Solutions/Mathematics/Handshake.cs) |
| [Minimum Height Triangle](https://www.hackerrank.com/challenges/lowest-triangle) | Easy | Integer ceiling | [MinimumHeightTriangle.cs](src/HackerRank.Solutions/Mathematics/MinimumHeightTriangle.cs) |
| [Army Game](https://www.hackerrank.com/challenges/game-with-cells) | Easy | ⌈n/2⌉ · ⌈m/2⌉ | [ArmyGame.cs](src/HackerRank.Solutions/Mathematics/ArmyGame.cs) |
| [Connecting Towns](https://www.hackerrank.com/challenges/connecting-towns) | Easy | Product mod 1234567 | [ConnectingTowns.cs](src/HackerRank.Solutions/Mathematics/ConnectingTowns.cs) |
| [Halloween Party](https://www.hackerrank.com/challenges/halloween-party) | Easy | Split cuts evenly | [HalloweenParty.cs](src/HackerRank.Solutions/Mathematics/HalloweenParty.cs) |
| [Leonardo's Prime Factors](https://www.hackerrank.com/challenges/leonardo-and-prime) | Easy | Primorials, overflow-safe | [LeonardosPrimeFactors.cs](src/HackerRank.Solutions/Mathematics/LeonardosPrimeFactors.cs) |
| [Summing the N series](https://www.hackerrank.com/challenges/summing-the-n-series) | Easy | Telescopes to n² | [SummingTheNSeries.cs](src/HackerRank.Solutions/Mathematics/SummingTheNSeries.cs) |
| [Best Divisor](https://www.hackerrank.com/challenges/best-divisor) | Easy | Divisor pairs up to √n | [BestDivisor.cs](src/HackerRank.Solutions/Mathematics/BestDivisor.cs) |
| [Restaurant](https://www.hackerrank.com/challenges/restaurant) | Easy | GCD-sized squares | [Restaurant.cs](src/HackerRank.Solutions/Mathematics/Restaurant.cs) |
| [Reverse Game](https://www.hackerrank.com/challenges/reverse-game) | Easy | Alternating final order, O(1) | [ReverseGame.cs](src/HackerRank.Solutions/Mathematics/ReverseGame.cs) |
| [Strange Grid Again](https://www.hackerrank.com/challenges/strange-grid) | Easy | Closed form | [StrangeGrid.cs](src/HackerRank.Solutions/Mathematics/StrangeGrid.cs) |
| [Cutting Paper Squares](https://www.hackerrank.com/challenges/p1-paper-cutting) | Easy | Each cut adds one piece | [CuttingPaperSquares.cs](src/HackerRank.Solutions/Mathematics/CuttingPaperSquares.cs) |
| [Diwali Lights](https://www.hackerrank.com/challenges/diwali-lights) | Easy | 2^n - 1, fast exponentiation | [DiwaliLights.cs](src/HackerRank.Solutions/Mathematics/DiwaliLights.cs) |
| [Constructing a Number](https://www.hackerrank.com/challenges/constructing-a-number) | Easy | Digit sum mod 3 | [ConstructingANumber.cs](src/HackerRank.Solutions/Mathematics/ConstructingANumber.cs) |
| [Sherlock and Divisors](https://www.hackerrank.com/challenges/sherlock-and-divisors) | Easy | Divisors of n / 2 | [SherlockAndDivisors.cs](src/HackerRank.Solutions/Mathematics/SherlockAndDivisors.cs) |
| [Filling Jars](https://www.hackerrank.com/challenges/filling-jars) | Easy | Only the total matters | [FillingJars.cs](src/HackerRank.Solutions/Mathematics/FillingJars.cs) |
| [Special Multiple](https://www.hackerrank.com/challenges/special-multiple) | Medium | BFS over remainders | [SpecialMultiple.cs](src/HackerRank.Solutions/Mathematics/SpecialMultiple.cs) |
| [Is Fibo](https://www.hackerrank.com/challenges/is-fibo) | Medium | Walk the sequence | [IsFibo.cs](src/HackerRank.Solutions/Mathematics/IsFibo.cs) |
| [Possible Path](https://www.hackerrank.com/challenges/possible-path) | Medium | Moves preserve the GCD | [PossiblePath.cs](src/HackerRank.Solutions/Mathematics/PossiblePath.cs) |
| [Fibonacci Finding (easy)](https://www.hackerrank.com/challenges/fibonacci-finding-easy) | Medium | Fast doubling, O(log n) | [FibonacciFinding.cs](src/HackerRank.Solutions/Mathematics/FibonacciFinding.cs) |

### Game Theory (10)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Game of Stones](https://www.hackerrank.com/challenges/game-of-stones-1) | Easy | Losing positions: n mod 7 ∈ {0, 1} | [GameOfStones.cs](src/HackerRank.Solutions/GameTheory/GameOfStones.cs) |
| [Tower Breakers](https://www.hackerrank.com/challenges/tower-breakers-1) | Easy | Mirror strategy | [TowerBreakers.cs](src/HackerRank.Solutions/GameTheory/TowerBreakers.cs) |
| [A Chessboard Game](https://www.hackerrank.com/challenges/a-chessboard-game-1) | Easy | Period-4 losing squares | [ChessboardGame.cs](src/HackerRank.Solutions/GameTheory/ChessboardGame.cs) |
| [Introduction to Nim Game](https://www.hackerrank.com/challenges/nim-game-1) | Easy | Nim-sum | [IntroductionToNim.cs](src/HackerRank.Solutions/GameTheory/IntroductionToNim.cs) |
| [Misère Nim](https://www.hackerrank.com/challenges/misere-nim-1) | Medium | Nim-sum, all-ones special case | [MisereNim.cs](src/HackerRank.Solutions/GameTheory/MisereNim.cs) |
| [Nimble Game](https://www.hackerrank.com/challenges/nimble-game-1) | Medium | XOR of odd-count indices | [NimbleGame.cs](src/HackerRank.Solutions/GameTheory/NimbleGame.cs) |
| [Poker Nim](https://www.hackerrank.com/challenges/poker-nim-1) | Easy | Additions are reversible: plain Nim | [PokerNim.cs](src/HackerRank.Solutions/GameTheory/PokerNim.cs) |
| [Tower Breakers, Revisited!](https://www.hackerrank.com/challenges/tower-breakers-revisited-1) | Medium | Grundy = prime factor count | [TowerBreakersRevisited.cs](src/HackerRank.Solutions/GameTheory/TowerBreakersRevisited.cs) |
| [Alice and Bob's Silly Game](https://www.hackerrank.com/challenges/alice-and-bobs-silly-game) | Medium | Parity of the prime count | [AliceAndBobsSillyGame.cs](src/HackerRank.Solutions/GameTheory/AliceAndBobsSillyGame.cs) |
| [Zero-Move Nim](https://www.hackerrank.com/challenges/zero-move-nim) | Medium | Grundy n ± 1 by parity | [ZeroMoveNim.cs](src/HackerRank.Solutions/GameTheory/ZeroMoveNim.cs) |

## Adding a new solution

1. Add a static class under the matching category folder in `src/HackerRank.Solutions/`, with a `<summary>` that describes the problem and links to it.
2. Add tests with the problem's sample cases to the matching `*Tests.cs` file.
3. Run `dotnet test` and add a row to the table above.

## License

Solutions are my own work. Problem statements belong to [HackerRank](https://www.hackerrank.com/).
