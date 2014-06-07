namespace TestSchoolSystem
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestCourse
    {
        private readonly string defaultCourseName = "Math";
        private readonly string defaultStudentName = "Pesho";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullNameToCourseTest()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEmptyNameToCourseTest()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        public void SetNameToCourseTest()
        {
            var course = new Course(this.defaultCourseName);
            Assert.AreEqual(course.Name, this.defaultCourseName);
        }

        [TestMethod]
        public void AddStudentToCourseTest()
        {
            var course = new Course(this.defaultCourseName);
            var student = new Student(this.defaultStudentName);

            course.AddStudent(student);

            Assert.IsTrue(course.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddMoreThanMaxStudentCountToCourseTest()
        {
            var course = new Course("Math");

            for (int i = 0; i < 35; i++)
            {
                var student = new Student(string.Format("Student#{0}", i + 1));

                course.AddStudent(student);
            }
        }

        [TestMethod]
        public void AddMaxStudentCountToCourseTest()
        {
            var course = new Course(this.defaultCourseName);

            for (int i = 0; i < 30; i++)
            {
                var student = new Student(string.Format("Student#{0}", i + 1));

                course.AddStudent(student);
            }

            Assert.AreEqual(30, course.Students.Count);
        }

        [TestMethod]
        public void RemoveStudentFromCourseTest()
        {
            var course = new Course(this.defaultCourseName);
            var student = new Student(this.defaultStudentName);

            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToRemoveNonExistingStudentFromCourseTest()
        {
            var course = new Course(this.defaultCourseName);

            course.AddStudent(new Student(this.defaultStudentName));

            course.RemoveStudent(new Student("John Dole"));
        }

        [TestMethod]
        public void CourseToStringTest()
        {
            var course = new Course(this.defaultCourseName);
            var student = new Student(this.defaultStudentName);

            course.AddStudent(student);

            Assert.AreEqual(string.Format("Course: {0}; Students joined: {1}", this.defaultCourseName, 1), course.ToString());
        }
    }
}