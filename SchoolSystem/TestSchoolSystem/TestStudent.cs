namespace TestSchoolSystem
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        public void InitializeNewStudentTest()
        {
            var student = new Student("Dinko");
            Assert.AreEqual(student.Name, "Dinko", "Students name is not the one given in the constructor.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullNameToStudentTest()
        {
            var student = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEmptyNameToStudentTest()
        {
            var student = new Student(string.Empty);
        }
    }
}