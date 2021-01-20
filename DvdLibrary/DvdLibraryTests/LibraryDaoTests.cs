using System;
using System.Collections.Generic;
using System.IO;
using DvdLibrary.BLL.DAO;
using DvdLibrary.BLL.DTO;
using NUnit.Framework;

namespace DvdLibraryTests
{
    [TestFixture]
    public class LibraryDaoTests
    {
        private const string TestPath =
            @"C:\Users\naris\Documents\Work\TECHHIRE\REPOSITORY\C-Sharp-OOP\DvdLibrary\AppData\libraryTest.txt";

        private ILibraryDao dao;
        private DVD dvd1;
        private DVD dvd2;
        private DVD dvd3;

        [SetUp]
        public void Setup()
        {
            dao = new LibraryDaoImpl(TestPath);

            //scrub file
            var file = File.Create(TestPath);
            file.Close();

            //dvd's
            dvd1 = new DVD
            {
                Id = 1,
                Title = "Sholay",
                ReleaseDate = DateTime.Parse("08/15/1975"),
                Director = "Ramesh Sippy",
                Studio = "Sippy Films",
                MpaaRating = "NR",
                UserRating = "10/10"
            };

            dvd2 = new DVD
            {
                Id = 2,
                Title = "Zamaana Deewana",
                ReleaseDate = DateTime.Parse("07/28/1995"),
                Director = "Ramesh Sippy",
                Studio = "Sippy Films",
                MpaaRating = "NR",
                UserRating = "10/10"
            };

            dvd3 = new DVD
            {
                Id = 3,
                Title = "Trimurti",
                ReleaseDate = DateTime.Parse("12/22/1995"),
                Director = "Mukul Anand",
                Studio = "Mukhta Arts",
                MpaaRating = "NR",
                UserRating = "10/10"
            };
        }

        [Test]
        public void CreateReadByIdDVDTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD fromDao = dao.ReadDvdById(d1.Id);

            Assert.NotNull(d1);
            Assert.AreEqual(dvd1, fromDao);
            Assert.AreEqual(dvd1, d1);
            Assert.AreEqual(d1, fromDao);
        }

        [Test]
        public void CreateNullIdFail()
        {
            DVD bad = new DVD();

            try
            {
                DVD failed = dao.CreateDvd(bad);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByIdFail()
        {
            DVD d1 = dao.CreateDvd(dvd1);

            try
            {
                DVD fail = dao.ReadDvdById(dvd2.Id);
                Assert.Fail();
            }
            catch (LibraryDaoException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByTitleTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD fromDao = dao.ReadDvdByTitle(d1.Title);

            Assert.AreEqual(dvd1, fromDao);
            Assert.AreEqual(dvd1, d1);
            Assert.AreEqual(d1, fromDao);
        }

        [Test]
        public void ReadByTitleFail()
        {
            DVD d1 = dao.CreateDvd(dvd1);

            try
            {
                DVD fail = dao.ReadDvdByTitle("");
                Assert.Fail();
            }
            catch (LibraryDaoException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadAllTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD d2 = dao.CreateDvd(dvd2);
            DVD d3 = dao.CreateDvd(dvd3);

            List<DVD> all = dao.ReadAll();

            Assert.AreEqual(3, all.Count);
            Assert.IsTrue(all.Contains(d1));
            Assert.IsTrue(all.Contains(d2));
            Assert.IsTrue(all.Contains(d3));
        }

        [Test]
        public void ReadAllByDirectorTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD d2 = dao.CreateDvd(dvd2);
            DVD d3 = dao.CreateDvd(dvd3);

            List<DVD> sippyOnly = dao.ReadAllByDirector("Ramesh Sippy");

            Assert.AreEqual(2, sippyOnly.Count);
            Assert.IsTrue(sippyOnly.Contains(d1));
            Assert.IsTrue(sippyOnly.Contains(d2));
            Assert.IsFalse(sippyOnly.Contains(d3));
        }

        [Test]
        public void ReadAllByStudioTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD d2 = dao.CreateDvd(dvd2);
            DVD d3 = dao.CreateDvd(dvd3);

            List<DVD> sippyFilms = dao.ReadAllByStudio("Sippy Films");

            Assert.AreEqual(2, sippyFilms.Count);
            Assert.IsTrue(sippyFilms.Contains(d1));
            Assert.IsTrue(sippyFilms.Contains(d2));
            Assert.IsFalse(sippyFilms.Contains(d3));
        }

        [Test]
        public void ReadAllByReleaseYearTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD d2 = dao.CreateDvd(dvd2);
            DVD d3 = dao.CreateDvd(dvd3);

            List<DVD> in1995 = dao.ReadAllByReleaseYear(DateTime.Parse("01-01-1995"));

            Assert.AreEqual(2, in1995.Count);
            Assert.IsFalse(in1995.Contains(d1));
            Assert.IsTrue(in1995.Contains(d2));
            Assert.IsTrue(in1995.Contains(d3));
        }

        [Test]
        public void ReadAllByMpaaRating()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD d2 = dao.CreateDvd(dvd2);
            DVD d3 = dao.CreateDvd(dvd3);

            List<DVD> intlNotRated = dao.ReadAllByMpaaRating("NR");

            Assert.AreEqual(3, intlNotRated.Count);
            Assert.IsTrue(intlNotRated.Contains(d1));
            Assert.IsTrue(intlNotRated.Contains(d2));
            Assert.IsTrue(intlNotRated.Contains(d3));
        }

        [Test]
        public void UpdateDVDTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD original = dao.ReadDvdById(d1.Id);

            d1.Director = "Narish Singh";
            d1.UserRating = "Edited/10";

            DVD edit = dao.UpdateDvd(d1);
            List<DVD> all = dao.ReadAll();

            Assert.NotNull(edit);
            Assert.AreEqual(edit, d1);
            Assert.AreNotEqual(original, edit);
            Assert.AreNotEqual(original, d1);
            Assert.IsTrue(all.Contains(edit));
            Assert.IsFalse(all.Contains(original));
        }

        [Test]
        public void DeleteDvdTest()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            DVD d2 = dao.CreateDvd(dvd2);
            DVD d3 = dao.CreateDvd(dvd3);
            List<DVD> original = dao.ReadAll();

            bool deleted = dao.DeleteDvd(d1.Id);
            List<DVD> afterDel = dao.ReadAll();

            Assert.AreEqual(3, original.Count);
            Assert.IsTrue(deleted);
            Assert.AreNotEqual(original, afterDel);
            Assert.IsFalse(afterDel.Contains(d1));
            Assert.IsTrue(afterDel.Contains(d2));
            Assert.IsTrue(afterDel.Contains(d3));
        }

        [Test]
        public void DeleteNullIdFail()
        {
            DVD bad = new DVD();
            try
            {
                bool delFail = dao.DeleteDvd(bad.Id);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void DeleteBadIdFail()
        {
            DVD d1 = dao.CreateDvd(dvd1);
            try
            {
                bool delFail = dao.DeleteDvd(dvd2.Id);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}