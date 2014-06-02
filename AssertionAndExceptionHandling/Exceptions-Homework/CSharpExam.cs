using System;

public class CSharpExam : Exam
{
    private const int MaxScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0 && value > MaxScore)
            {
                throw new ArgumentOutOfRangeException(string.Format("Score should be a number between 0 and {0}", MaxScore));
            }
            else
            {
                this.score = value;
            }
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}