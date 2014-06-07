namespace SchoolSystem
{
    using System;
    using System.Linq;

    public class Student
    {
        private string name;

        public Student(string studentsName)
        {
            this.Name = studentsName;
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
                    throw new ArgumentNullException("Student's name must not be null or empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("name: {0};", this.Name);
        }
    }
}