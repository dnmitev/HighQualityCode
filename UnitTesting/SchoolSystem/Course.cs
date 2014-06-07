namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private const int MaxStudentsInCourse = 30;

        private string name;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.Students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public List<Student> Students { get; private set; }

        public void AddStudent(Student student)
        {
            if (this.Students.Count >= MaxStudentsInCourse)
            {
                throw new ArgumentOutOfRangeException(string.Format("Students in a course cannot be more than {0}", MaxStudentsInCourse));
            }
            else
            {
                this.Students.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (!this.Students.Contains(student))
            {
                throw new ArgumentException(string.Format("{0} has not joined the course.", student.ToString()));
            }
            else
            {
                this.Students.Remove(student);
            }
        }

        public override string ToString()
        {
            return string.Format("Course: {0}; Students joined: {1}", this.Name, this.Students.Count);
        }
    }
}