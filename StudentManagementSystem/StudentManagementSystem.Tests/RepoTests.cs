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

            //scrub file, add header
            FileStream testFile = File.Create(TestPath);
            testFile.Close(); //have to close FileStream before StreamWriter can open
            using (StreamWriter w = new StreamWriter(TestPath))
            {
                w.WriteLine("FirstName,LastName,Major,GPA");
            }
            
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

        [Test]
        public void UpdateStudentTest()
        {
            repo.CreateStudent(student1);
            repo.CreateStudent(student2);
            List<Student> original = repo.ReadAllStudents();

            Student update = new Student
            {
                FirstName = "update",
                LastName = student1.LastName,
                Major = student1.Major,
                GPA = student1.GPA
            };
            repo.UpdateStudent(update, original.IndexOf(student1));
            List<Student> afterUpdate = repo.ReadAllStudents();
            
            Assert.AreEqual(2, original.Count);
            Assert.IsTrue(original.Contains(student1));
            Assert.IsFalse(original.Contains(update));
            Assert.IsTrue(original.Contains(student2));
            Assert.AreNotEqual(original, afterUpdate);
            Assert.IsFalse(afterUpdate.Contains(student1));
            Assert.IsTrue(afterUpdate.Contains(update));
            Assert.IsTrue(afterUpdate.Contains(student2));
        }

        [Test]
        public void DeleteStudentTest()
        {
            repo.CreateStudent(student1);
            repo.CreateStudent(student2);
            List<Student> original = repo.ReadAllStudents();
            
            repo.DeleteStudent(1);
            List<Student> afterDel = repo.ReadAllStudents();
            
            Assert.AreEqual(2, original.Count);
            Assert.IsTrue(original.Contains(student1));
            Assert.IsTrue(original.Contains(student2));
            Assert.AreNotEqual(original, afterDel);
            Assert.AreEqual(1, afterDel.Count);
            Assert.IsTrue(afterDel.Contains(student1));
            Assert.IsFalse(afterDel.Contains(student2));
        }
    }
}