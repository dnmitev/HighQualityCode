using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemCoutn = 0;
    private const int MaxProblemCount = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        
        private set
        {
            if (MinProblemCoutn < value && value < MaxProblemCount)
            {
                this.problemsSolved = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Problems count must be a number between {0} and {1}", MinProblemCoutn, MaxProblemCount));
            }
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}