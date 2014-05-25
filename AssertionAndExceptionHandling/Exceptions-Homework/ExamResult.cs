using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value > 0)
            {
                this.grade = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Grade cannot be negative number.");
            }
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value > 0)
            {
                this.minGrade = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Minimal grade cannot be negative number.");
            }
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value > this.MinGrade)
            {
                this.maxGrade = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Max grade cannot be less than minimal grade.");
            }
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.comments = value;
            }
            else
            {
                throw new ArgumentNullException("Comments cannot be null or empty.");
            }
        }
    }
}