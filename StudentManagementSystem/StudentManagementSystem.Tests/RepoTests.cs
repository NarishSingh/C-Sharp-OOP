using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using StudentManagementSystem.BLL.DAO;
using StudentManagementSystem.BLL.DTO;

namespace StudentManagementSystem.Tests
{
    [TestFixture]
    public class RepoTests
    {
        private const string TestPath = @"C:\Users\naris\Documents\Work\TECHHIRE\REPOSITORY\C-Sharp-OOP\StudentManagementSystem\AppData\StudentsTest.txt";
        private StudentRepository repo;
        private Student student1;
        private Student student2;
        
        [SetUp]
        public void Setup()
        {
            repo = new StudentRepository(TestPath);
            student1 = new Student
            {
                FirstName = "Testing",
                LastName = "Test",
                Major = "Unit Testing",
                GPA = 1.0M
            };
            student2 = new Student
            {
                FirstName = "Testing2",
                LastName = "Test2",
                Major = "Unit Testing",
                GPA = 2.0M
            };
        }

        [TearDown]
        public void TearDown()
        {
            FileStream testFile = File.Create(TestPath); //scrub file for new test
            testFile.Close();
        }
        
        [Test]
        public void CreateStudentTest()
        {
            repo.CreateStudent(student1);
            
            List<Student> all = repo.ReadAllStudents();
            Student added = all[0];
            
            Assert.AreEqual(1, all.Count);
            Assert.AreEqual(student1.FirstName, added.FirstName);
            Assert.AreEqual(student1.LastName, added.LastName);
            Assert.AreEqual(student1.Major, added.Major);
            Assert.AreEqual(student1.GPA, added.GPA);
        }

        [Test]
        public void ReadAllStudentsTest()
        {
            repo.CreateStudent(student1);
            repo.CreateStudent(student2);
            
            List<Student> all = repo.ReadAllStudents();
            Student s1 = all[0];
            Student s2 = all[1];
            
            Assert.AreEqual(2, all.Count);
            Assert.AreEqual(student1.FirstName, s1.FirstName);
            Assert.AreEqual(student1.LastName, s1.LastName);
            Assert.AreEqual(student1.Major, s1.Major);
            Assert.AreEqual(student1.GPA, s1.GPA);
            Assert.AreEqual(student2.FirstName, s2.FirstName);
            Assert.AreEqual(student2.LastName, s2.LastName);
            Assert.AreEqual(student2.Major, s2.Major);
            Assert.AreEqual(student2.GPA, s2.GPA);
        }
    }
}