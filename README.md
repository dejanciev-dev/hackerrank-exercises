# HackerRank Exercises in C#

[![build](https://github.com/dejanciev-dev/hackerrank-exercises/actions/workflows/build.yml/badge.svg)](https://github.com/dejanciev-dev/hackerrank-exercises/actions/workflows/build.yml)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-latest-239120?logo=csharp)
![Solutions](https://img.shields.io/badge/solutions-116-blue)
![Tests](https://img.shields.io/badge/tests-312-brightgreen)

My solutions to [HackerRank](https://www.hackerrank.com/) problems, written in modern C# (.NET 10).
Every solution has unit tests built from the problem's sample cases, and GitHub Actions runs them on each push.

## Highlights

- **116 problems** in seven categories: Warmup, Implementation, Strings, Data Structures, Sorting, Search and Greedy
- **312 xUnit tests** covering the official samples and extra edge cases (overflow, empty results, off-by-one boundaries)
- **Focus on complexity**: sliding windows, two pointers, monotonic stacks, hashing, dynamic programming and closed-form math, so most solutions run in O(n) or O(n log n)
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
│   └── Greedy/
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

### Implementation (56)

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

### Strings (24)

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

### Data Structures (11)

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

### Sorting (5)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Big Sorting](https://www.hackerrank.com/challenges/big-sorting) | Easy | Length, then ordinal compare | [BigSorting.cs](src/HackerRank.Solutions/Sorting/BigSorting.cs) |
| [Mark and Toys](https://www.hackerrank.com/challenges/mark-and-toys) | Easy | Sort + greedy | [MarkAndToys.cs](src/HackerRank.Solutions/Sorting/MarkAndToys.cs) |
| [Find the Median](https://www.hackerrank.com/challenges/find-the-median) | Easy | Sort | [FindTheMedian.cs](src/HackerRank.Solutions/Sorting/FindTheMedian.cs) |
| [Closest Numbers](https://www.hackerrank.com/challenges/closest-numbers) | Easy | Sort + adjacent pairs | [ClosestNumbers.cs](src/HackerRank.Solutions/Sorting/ClosestNumbers.cs) |
| [Fraudulent Activity Notifications](https://www.hackerrank.com/challenges/fraudulent-activity-notifications) | Medium | Counting-sort sliding window | [FraudulentActivityNotifications.cs](src/HackerRank.Solutions/Sorting/FraudulentActivityNotifications.cs) |

### Search (4)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Ice Cream Parlor](https://www.hackerrank.com/challenges/icecream-parlor) | Easy | Two-sum with a dictionary | [IceCreamParlor.cs](src/HackerRank.Solutions/Search/IceCreamParlor.cs) |
| [Missing Numbers](https://www.hackerrank.com/challenges/missing-numbers) | Easy | Frequency balance | [MissingNumbers.cs](src/HackerRank.Solutions/Search/MissingNumbers.cs) |
| [Sherlock and Array](https://www.hackerrank.com/challenges/sherlock-and-array) | Easy | Prefix sums | [SherlockAndArray.cs](src/HackerRank.Solutions/Search/SherlockAndArray.cs) |
| [Pairs](https://www.hackerrank.com/challenges/pairs) | Medium | HashSet lookup, O(n) | [Pairs.cs](src/HackerRank.Solutions/Search/Pairs.cs) |

### Greedy (6)

| Problem | Difficulty | Approach | Solution |
|---|---|---|---|
| [Minimum Absolute Difference in an Array](https://www.hackerrank.com/challenges/minimum-absolute-difference-in-an-array) | Easy | Sort + adjacent scan | [MinimumAbsoluteDifference.cs](src/HackerRank.Solutions/Greedy/MinimumAbsoluteDifference.cs) |
| [Luck Balance](https://www.hackerrank.com/challenges/luck-balance) | Easy | Lose the k luckiest important contests | [LuckBalance.cs](src/HackerRank.Solutions/Greedy/LuckBalance.cs) |
| [Grid Challenge](https://www.hackerrank.com/challenges/grid-challenge) | Easy | Sort rows, check columns | [GridChallenge.cs](src/HackerRank.Solutions/Greedy/GridChallenge.cs) |
| [Jim and the Orders](https://www.hackerrank.com/challenges/jim-and-the-orders) | Easy | Sort by completion time | [JimAndTheOrders.cs](src/HackerRank.Solutions/Greedy/JimAndTheOrders.cs) |
| [Max Min](https://www.hackerrank.com/challenges/angry-children) | Medium | Sort + sliding window | [MaxMin.cs](src/HackerRank.Solutions/Greedy/MaxMin.cs) |
| [Greedy Florist](https://www.hackerrank.com/challenges/greedy-florist) | Medium | Most expensive first, round-robin | [GreedyFlorist.cs](src/HackerRank.Solutions/Greedy/GreedyFlorist.cs) |

## Adding a new solution

1. Add a static class under the matching category folder in `src/HackerRank.Solutions/`, with a `<summary>` that describes the problem and links to it.
2. Add tests with the problem's sample cases to the matching `*Tests.cs` file.
3. Run `dotnet test` and add a row to the table above.

## License

Solutions are my own work. Problem statements belong to [HackerRank](https://www.hackerrank.com/).
