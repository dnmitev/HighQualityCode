namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private const int MinimalIdNumber = 10000;
        private const int MaximalIdNumber = 99999;

        private readonly List<Course> courses;
        private readonly Dictionary<Student, int> students;

        public School()
        {
            this.courses = new List<Course>();
            this.students = new Dictionary<Student, int>();
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public Dictionary<Student, int> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.Students.Count > MaximalIdNumber - MinimalIdNumber)
            {
                throw new ArgumentOutOfRangeException("School is full. Cannot add more students");
            }

            for (int i = MinimalIdNumber; i < MaximalIdNumber; i++)
            {
                if (this.students.ContainsValue(i))
                {
                    continue;
                }
                else
                {
                    this.students.Add(student, i);
                    break;
                }
            }
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.ContainsKey(student))
            {
                throw new ArgumentException(string.Format("{0} is not presented in the school", student));
            }
            else
            {
                this.students.Remove(student);
            }
        }

        public void AddCourse(Course course)
        {
            if (this.Courses.Contains(course))
            {
                throw new ArgumentException("Course already exists in the school.");
            }
            else
            {
                this.courses.Add(course);
            }
        }

        public void RemoveCourse(Course course)
        {
            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("Course doesn't exist in the school.");
            }
            else
            {
                this.courses.Remove(course);
            }
        }

        public int? GetID(Student student)
        {
            if (!this.students.ContainsKey(student))
            {
                throw new ArgumentException("Student was not found in this school.");
            }

            return this.students[student];
        }
    }
}