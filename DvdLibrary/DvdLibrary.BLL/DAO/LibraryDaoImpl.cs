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
            _path = @"C:\Users\naris\Documents\Work\TECHHIRE\REPOSITORY\C-Sharp-OOP\DvdLibrary\AppData\library.txt";
        }

        public LibraryDaoImpl(string path)
        {
            _path = path;
        }


        public DVD CreateDvd(DVD dvd)
        {
            LoadLibrary();

            if (dvd.Id == 0 || _library.ContainsKey(dvd.Id))
            {
                throw new LibraryDaoException("Invalid Key");
            }

            _library.Add(dvd.Id, dvd);
            WriteLibrary();

            return _library.ContainsValue(dvd) ? dvd : null;
        }

        public DVD ReadDvdById(int id)
        {
            LoadLibrary();
            return _library[id];
        }

        public DVD ReadDvdByTitle(string title)
        {
            LoadLibrary();

            if (string.IsNullOrEmpty(title))
            {
                throw new LibraryDaoException("Title must not be blank");
            }

            DVD? dvd = _library.Values
                .FirstOrDefault(d => d.Title.Equals(title));

            if (dvd != null)
            {
                return dvd;
            }
            else
            {
                throw new LibraryDaoException("No DVD by this title in library");
            }
        }

        public List<DVD> ReadAll()
        {
            LoadLibrary();
            return _library.Values.ToList();
        }

        public List<DVD> ReadAllByDirector(string director)
        {
            LoadLibrary();
            return _library.Where(kv => kv.Value.Director.Equals(director))
                .Select(kv => kv.Value)
                .ToList();
        }

        public List<DVD> ReadAllByStudio(string studio)
        {
            LoadLibrary();
            return _library.Where(kv => kv.Value.Studio.Equals(studio))
                .Select(kv => kv.Value)
                .ToList();
        }

        public List<DVD> ReadAllByReleaseYear(DateTime release)
        {
            LoadLibrary();
            return _library.Where(kv => kv.Value.ReleaseDate.Year == release.Year)
                .Select(kv => kv.Value)
                .ToList();
        }

        public List<DVD> ReadAllByMpaaRating(string mpaaRating)
        {
            LoadLibrary();
            return _library.Where(kv => kv.Value.MpaaRating == mpaaRating)
                .Select(kv => kv.Value)
                .ToList();
        }

        public DVD UpdateDvd(DVD update)
        {
            if (update.Id == 0)
            {
                throw new LibraryDaoException("DVD not validated, update rejected");
            }

            LoadLibrary();
            try
            {
                _library[update.Id] = update;
            }
            catch (KeyNotFoundException e)
            {
                throw new LibraryDaoException("Cannot update non-existent record");
            }

            WriteLibrary();

            return _library.ContainsValue(update) ? update : null;
        }

        public bool DeleteDvd(int id)
        {
            LoadLibrary();

            if (id == 0 || !_library.ContainsKey(id))
            {
                throw new LibraryDaoException("Invalid Key");
            }

            bool removed = _library.Remove(id);
            WriteLibrary();

            return removed;
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
                $"{d.Id}::{d.Title}::{d.ReleaseDate:MM/dd/yyyy}::{d.Director}::{d.Studio}::" +
                $"{d.MpaaRating}::{d.UserRating}";
        }

        /// <summary>
        /// Load library to memory from file
        /// </summary>
        private void LoadLibrary()
        {
            _library.Clear();

            try
            {
                using (StreamReader sr = new(_path))
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
            //scrub file
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }

            List<DVD> dvds = _library.Values.ToList();

            try
            {
                var file = File.Create(_path);
                file.Close();

                using (StreamWriter w = new(_path))
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