using System;
using System.Collections.Generic;
using System.IO;
using DvdLibrary.BLL.DAO;
using DvdLibrary.BLL.DTO;
using DvdLibrary.BLL.Service;
using NUnit.Framework;

namespace DvdLibraryTests
{
    [TestFixture]
    public class ServiceTests
    {
        private Service serv;

        private const string TestPath =
            @"C:\Users\naris\Documents\Work\TECHHIRE\REPOSITORY\C-Sharp-OOP\DvdLibrary\AppData\libraryTest.txt";

        private DVD dvd1;
        private DVD badDvd1;
        private DVD dvd2;
        private DVD dvd3;

        [SetUp]
        public void Init()
        {
            serv = new Service(new LibraryDaoImpl(TestPath));

            //scrub file
            var file = File.Create(TestPath);
            file.Close();

            //dvds
            dvd1 = new DVD
            {
                Title = "Sholay",
                ReleaseDate = DateTime.Parse("08/15/1975"),
                Director = "Ramesh Sippy",
                Studio = "Sippy Films",
                MpaaRating = "NR",
                UserRating = "10/10"
            };

            badDvd1 = new DVD
            {
                Id = 1
            };

            dvd2 = new DVD
            {
                Title = "Zamaana Deewana",
                ReleaseDate = DateTime.Parse("07/28/1995"),
                Director = "Ramesh Sippy",
                Studio = "Sippy Films",
                MpaaRating = "NR",
                UserRating = "10/10"
            };

            dvd3 = new DVD
            {
                Title = "Trimurti",
                ReleaseDate = DateTime.Parse("12/22/1995"),
                Director = "Mukul Anand",
                Studio = "Mukhta Arts",
                MpaaRating = "NR",
                UserRating = "10/10"
            };
        }

        [Test]
        public void ValidateDvdTest()
        {
            DVD d1 = serv.ValidateDvd(dvd1);
            serv.CreateDvd(d1);
            DVD d2 = serv.ValidateDvd(dvd2);
            serv.CreateDvd(d2);

            Assert.AreEqual(1, d1.Id);
            Assert.AreEqual(2, d2.Id);
        }

        [Test]
        public void CreateReadyByIdTest()
        {
            try
            {
                dvd1 = serv.ValidateDvd(dvd1);
                DVD d1 = serv.CreateDvd(dvd1);
                DVD fromDao = serv.ReadDvdById(d1.Id);

                Assert.NotNull(d1);
                Assert.NotNull(fromDao);
                Assert.AreEqual(d1, fromDao);
            }
            catch (PersistenceFailedException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CreateIdFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                DVD fail = serv.CreateDvd(badDvd1);
                Assert.Fail();
            }
            catch (PersistenceFailedException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByIdFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                DVD fail = serv.ReadDvdById(99);
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByTitleTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                DVD fromDao = serv.ReadDvdByTitle(d1.Title);

                Assert.NotNull(fromDao);
                Assert.AreEqual(d1, fromDao);
            }
            catch (NoRecordException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReadByTitleEmptyStringFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                DVD fromDao = serv.ReadDvdByTitle("");
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByTitleBadTitleFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                DVD fromDao = serv.ReadDvdByTitle("None");
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadAllTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> all = serv.ReadAll();

                Assert.AreEqual(3, all.Count);
                Assert.IsTrue(all.Contains(d1));
                Assert.IsTrue(all.Contains(d2));
                Assert.IsTrue(all.Contains(d3));
            }
            catch (NoRecordException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReadAllFail()
        {
            try
            {
                List<DVD> fail = serv.ReadAll();
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByDirectorTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> sippy = serv.ReadAllByDirector(d1.Director);

                Assert.AreEqual(2, sippy.Count);
                Assert.IsTrue(sippy.Contains(d1));
                Assert.IsTrue(sippy.Contains(d2));
                Assert.IsFalse(sippy.Contains(d3));
            }
            catch (NoRecordException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReadByDirectorEmptyStringFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> fail = serv.ReadAllByDirector("");
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByDirectorBadDirectorFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> fail = serv.ReadAllByDirector("Singham");
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadAllByStudioTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> sippyFilms = serv.ReadAllByStudio(d1.Studio);

                Assert.AreEqual(2, sippyFilms.Count);
                Assert.IsTrue(sippyFilms.Contains(d1));
                Assert.IsTrue(sippyFilms.Contains(d2));
                Assert.IsFalse(sippyFilms.Contains(d3));
            }
            catch (NoRecordException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReadByStudioEmptyStringFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> fail = serv.ReadAllByStudio("");
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadByStudioBadStudioFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> fail = serv.ReadAllByStudio("No Studios, LLC");
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadAllByReleaseYrTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> in1995 = serv.ReadAllByReleaseYear(DateTime.Parse("01-01-1995"));

                Assert.AreEqual(2, in1995.Count);
                Assert.IsFalse(in1995.Contains(d1));
                Assert.IsTrue(in1995.Contains(d2));
                Assert.IsTrue(in1995.Contains(d3));
            }
            catch (NoRecordException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReadAllByReleaseYrBadPastYearFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> badYear = serv.ReadAllByReleaseYear(DateTime.MinValue);
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void ReadAllByReleaseYrBadFutureYearFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> badYear = serv.ReadAllByReleaseYear(DateTime.Today.AddYears(3));
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void ReadAllByReleaseYrNoneForYearFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> badYear = serv.ReadAllByReleaseYear(DateTime.Parse("01-01-1932"));
                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ReadAllByMpaaTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> nrFilms = serv.ReadAllByMpaaRating(d1.MpaaRating);

                Assert.AreEqual(3, nrFilms.Count);
                Assert.IsTrue(nrFilms.Contains(d1));
                Assert.IsTrue(nrFilms.Contains(d2));
                Assert.IsTrue(nrFilms.Contains(d3));
            }
            catch (NoRecordException e)
            {
                Assert.Fail();
            }
        }
        
        [Test]
        public void ReadAllByMpaaEmptyStringFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> badRating = serv.ReadAllByMpaaRating("");

                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void ReadAllByMpaaBadRatingFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            try
            {
                List<DVD> badRating = serv.ReadAllByMpaaRating("R");

                Assert.Fail();
            }
            catch (NoRecordException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void UpdateDvdTest()
        {
            const string newTitle = "Edit";
            const string newDir = "EditedSingh";

            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            DVD original = serv.ReadDvdById(d1.Id);

            d1.Title = newTitle;
            d1.Director = newDir;

            try
            {
                DVD d1Edit = serv.UpdateDvd(d1);
                DVD edited = serv.ReadDvdById(d1.Id);
                List<DVD> all = serv.ReadAll();
                
                Assert.NotNull(d1Edit);
                Assert.NotNull(edited);
                Assert.AreEqual(d1Edit.Title, newTitle);
                Assert.AreEqual(d1Edit.Director, newDir);
                Assert.AreNotEqual(original, d1Edit);
                Assert.AreNotEqual(original, edited);
                Assert.AreEqual(d1Edit, edited);
                Assert.IsTrue(all.Contains(d1Edit));
                Assert.IsFalse(all.Contains(original));
            }
            catch (PersistenceFailedException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void UpdateFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            DVD badDvd = new DVD();

            try
            {
                DVD fail = serv.UpdateDvd(badDvd);
                Assert.Fail();
            }
            catch (PersistenceFailedException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void DeleteDvdTest()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);
            dvd2 = serv.ValidateDvd(dvd2);
            DVD d2 = serv.CreateDvd(dvd2);
            dvd3 = serv.ValidateDvd(dvd3);
            DVD d3 = serv.CreateDvd(dvd3);

            List<DVD> original = serv.ReadAll();

            try
            {
                bool deleted = serv.DeleteDvd(d1.Id);
                List<DVD> afterDel = serv.ReadAll();
                
                Assert.AreEqual(3, original.Count);
                Assert.AreEqual(2, afterDel.Count);
                Assert.IsTrue(deleted);
                Assert.AreNotEqual(original, afterDel);
                Assert.IsFalse(afterDel.Contains(d1));
                Assert.IsTrue(afterDel.Contains(d2));
                Assert.IsTrue(afterDel.Contains(d3));
            }
            catch (PersistenceFailedException e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void DeleteFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                bool fail = serv.DeleteDvd(0);
                Assert.Fail();
            }
            catch (PersistenceFailedException e)
            {
                Assert.Pass();
            }
        }
    }
}