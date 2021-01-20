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
        public void ReadByTitleFail()
        {
            dvd1 = serv.ValidateDvd(dvd1);
            DVD d1 = serv.CreateDvd(dvd1);

            try
            {
                DVD fromDao1 = serv.ReadDvdByTitle("");
                DVD fromDao2 = serv.ReadDvdByTitle("None");
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
    }
}