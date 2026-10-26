namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Grading Students — round a grade up to the next multiple of 5 when the difference is
/// less than 3, unless the grade is below 38 (still failing after rounding).
/// https://www.hackerrank.com/challenges/grading
/// </summary>
public static class GradingStudents
{
    public static int[] Solve(IReadOnlyList<int> grades)
    {
        var result = new int[grades.Count];

        for (int i = 0; i < grades.Count; i++)
        {
            int grade = grades[i];
            int nextMultipleOfFive = (grade / 5 + 1) * 5;

            result[i] = grade >= 38 && nextMultipleOfFive - grade < 3
                ? nextMultipleOfFive
                : grade;
        }

        return result;
    }
}
