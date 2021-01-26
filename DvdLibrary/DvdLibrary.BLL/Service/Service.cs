using System;
using System.Collections.Generic;
using System.Linq;
using DvdLibrary.BLL.DAO;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.BLL.Service
{
    public class Service : IService
    {
        private ILibraryDao _dao;

        public Service()
        {
            _dao = new LibraryDaoImpl();
        }

        public Service(ILibraryDao dao)
        {
            _dao = dao; //testing only
        }

        public DVD ValidateDvd(DVD dvdRequest)
        {
            //generate id or pull original id
            if (dvdRequest.Id == 0)
            {
                return new DVD
                {
                    Id = _dao.ReadAll().Count == 0
                        ? 1
                        : NewId(),
                    //rest are validated by view
                    Title = dvdRequest.Title,
                    ReleaseDate = dvdRequest.ReleaseDate,
                    Director = dvdRequest.Director,
                    Studio = dvdRequest.Studio,
                    MpaaRating = dvdRequest.MpaaRating,
                    UserRating = dvdRequest.UserRating
                };
            }

            return dvdRequest;
        }

        public DVD CreateDvd(DVD dvd)
        {
            try
            {
                return _dao.CreateDvd(dvd);
            }
            catch (LibraryDaoException e)
            {
                throw new PersistenceFailedException(e.Message, e);
            }
        }

        public DVD ReadDvdById(int id)
        {
            try
            {
                return _dao.ReadDvdById(id);
            }
            catch (KeyNotFoundException e)
            {
                throw new NoRecordException(e.Message, e);
            }
        }

        public DVD ReadDvdByTitle(string title)
        {
            try
            {
                return _dao.ReadDvdByTitle(title);
            }
            catch (LibraryDaoException e)
            {
                throw new NoRecordException(e.Message, e);
            }
        }

        public List<DVD> ReadAll()
        {
            List<DVD> all = _dao.ReadAll();

            if (all.Count == 0)
            {
                throw new NoRecordException("Library is empty");
            }

            return all;
        }

        public List<DVD> ReadAllByDirector(string director)
        {
            if (string.IsNullOrEmpty(director))
            {
                throw new NoRecordException("Invalid director name");
            }

            List<DVD> dirFilms = _dao.ReadAllByDirector(director);

            if (dirFilms.Count == 0)
            {
                throw new NoRecordException("Library contains no films by this director");
            }

            return dirFilms;
        }

        public List<DVD> ReadAllByStudio(string studio)
        {
            if (string.IsNullOrEmpty(studio))
            {
                throw new NoRecordException("Invalid director name");
            }

            List<DVD> studioFilms = _dao.ReadAllByStudio(studio);

            if (studioFilms.Count == 0)
            {
                throw new NoRecordException("Library contains no films by this studio or production company");
            }

            return studioFilms;
        }

        public List<DVD> ReadAllByReleaseYear(DateTime release)
        {
            if (release < DateTime.Parse("01-01-1888") || release > DateTime.Now)
            {
                throw new NoRecordException("Release year provided is impossible");
            }

            List<DVD> yearFilms = _dao.ReadAllByReleaseYear(release);

            if (yearFilms.Count == 0)
            {
                throw new NoRecordException("Library contains no films from this year");
            }

            return yearFilms;
        }

        public List<DVD> ReadAllByMpaaRating(string mpaaRating)
        {
            if (string.IsNullOrEmpty(mpaaRating))
            {
                throw new NoRecordException("Invalid rating");
            }

            List<DVD> ratingFilms = _dao.ReadAllByMpaaRating(mpaaRating);

            if (ratingFilms.Count == 0)
            {
                throw new NoRecordException("Library contains no films of this rating");
            }

            return ratingFilms;
        }

        public DVD UpdateDvd(DVD update)
        {
            try
            {
                return _dao.UpdateDvd(update);
            }
            catch (LibraryDaoException e)
            {
                throw new PersistenceFailedException(e.Message, e);
            }
        }

        public bool DeleteDvd(int id)
        {
            try
            {
                return _dao.DeleteDvd(id);
            }
            catch (LibraryDaoException e)
            {
                throw new PersistenceFailedException(e.Message, e);
            }
        }

        /*Helpers*/
        /// <summary>
        /// Generate a new id for DVD
        /// </summary>
        /// <returns>int for the new id</returns>
        private int NewId()
        {
            return _dao.ReadAll()
                .Select(d => d.Id)
                .Max() + 1;
        }
    }
}