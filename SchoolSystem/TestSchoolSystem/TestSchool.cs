namespace TestSchoolSystem
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestSchool
    {
        private readonly string defaultCourseName = "Math";
        private readonly string defaultStudentName = "Pesho";

        [TestMethod]
        public void AddStudentTest()
        {
            var school = new School();
            var student = new Student(defaultStudentName);

            school.AddStudent(student);

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        public void NewlyAddedStudentHasIdTest()
        {
            var school = new School();
            var student = new Student(defaultStudentName);
            var newStudent = new Student("Gosho");

            school.AddStudent(student);
            school.AddStudent(newStudent);

            Assert.AreEqual(school.GetID(student), 10000, "Does not get proper initial id");
            Assert.AreEqual(school.GetID(newStudent), 10001, "Does not get new initial id");
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            var school = new School();
            var student = new Student(defaultStudentName);
            var newStudent = new Student("Gosho");

            school.AddStudent(student);
            school.AddStudent(newStudent);

            school.RemoveStudent(student);

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentTest()
        {
            var school = new School();

            school.RemoveStudent(new Student(defaultStudentName));
        }

        [TestMethod]
        public void AddCourseTest()
        {
            var school = new School();
            var course = new Course(defaultCourseName);

            school.AddCourse(course);

            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSameCourseTwiceTest()
        {
            var school = new School();
            var course = new Course(defaultCourseName);

            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void RemoveCourseTest()
        {
            var school = new School();
            var course = new Course(defaultCourseName);

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingCourseTest()
        {
            var school = new School();
            var course = new Course(defaultCourseName);

            school.AddCourse(course);
            school.RemoveCourse(new Course("C#"));
        }
    }
}