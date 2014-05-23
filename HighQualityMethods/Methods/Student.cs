﻿namespace Methods
{
    using System;

    internal class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthYear { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (this.BirthYear == null || other.BirthYear == null)
            {
                throw new ArgumentNullException("Age is not set in both students!");
            }

            bool result = this.BirthYear < other.BirthYear;

            return result;
        }
    }
}