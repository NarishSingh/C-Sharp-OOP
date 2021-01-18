using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.BLL.DAO
{
    public class LibraryDaoImpl : ILibraryDao
    {
        private Dictionary<int, DVD> _library = new();
        private string _path;

        public LibraryDaoImpl()
        {
            _path = "library.txt";
        }

        public LibraryDaoImpl(string path)
        {
            _path = path;
        }


        public void CreateDvd(DVD dvd)
        {
            LoadLibrary();
            _library.Add(dvd.Id, dvd);
            WriteLibrary();
        }

        public DVD ReadDvdById(int id)
        {
            LoadLibrary();
            return _library[id];
        }

        public DVD ReadDvdByTitle(string title)
        {
            LoadLibrary();
            foreach (DVD dvd in _library.Values)
            {
                if (dvd.Title.Equals(title))
                {
                    return dvd;
                }
            }

            return null;
        }

        public List<DVD> ReadAll()
        {
            LoadLibrary();
            return _library.Values.ToList();
        }

        public void UpdateDvd(DVD update)
        {
            LoadLibrary();
            _library[update.Id] = update;
        }

        public bool DeleteDvd(int id)
        {
            LoadLibrary();
            return _library.Remove(id);
        }

        /*DATA (UN)MARSHALLING*/
        /// <summary>
        /// Format record for file persistence
        /// </summary>
        /// <param name="d">Well formed DVD obj</param>
        /// <returns>String formatted for persistence</returns>
        private string FormatRecord(DVD d)
        {
            return
                $"{d.Id}::{d.Title}::{d.ReleaseDate.ToString("MM/dd/yyyy")}::{d.Director}::{d.Studio}::" +
                $"{d.MpaaRating}::{d.UserRating}";
        }

        /// <summary>
        /// Load library to memory from file
        /// </summary>
        private void LoadLibrary()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] cols = line.Split("::");

                        DVD d = new DVD
                        {
                            Id = int.Parse(cols[0]),
                            Title = cols[1],
                            ReleaseDate = DateTime.Parse(cols[2]),
                            Director = cols[3],
                            Studio = cols[4],
                            MpaaRating = cols[5],
                            UserRating = cols[6]
                        };

                        _library.Add(d.Id, d);
                    }
                }
            }
            catch (Exception e)
            {
                throw new LibraryDaoException(e.Message, e);
            }
        }

        /// <summary>
        /// Persist library to file
        /// </summary>
        /// <exception cref="LibraryDaoException">If unable to persist to file</exception>
        private void WriteLibrary()
        {
            List<DVD> dvds = _library.Values.ToList();

            try
            {
                File.Create(_path);

                using (StreamWriter w = new StreamWriter(_path))
                {
                    foreach (DVD d in dvds)
                    {
                        w.WriteLine(FormatRecord(d));
                    }
                }
            }
            catch (Exception e)
            {
                throw new LibraryDaoException(e.Message, e);
            }
        }
    }
}