using System;
using System.Collections.Generic;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.BLL.DAO
{
    public interface ILibraryDao
    {
        /// <summary>
        /// Create a new DVD record
        /// </summary>
        /// <param name="dvd">Well formed DVD obj</param>
        /// <returns>DVD obj if successfully added, null if failed</returns>
        /// <exception cref="LibraryDaoException">If unable to persist to file</exception>
        DVD CreateDvd(DVD dvd);

        /// <summary>
        /// Retrieve a DVD record by its id
        /// </summary>
        /// <param name="id">int for the id of dvd</param>
        /// <returns>DVD by that id</returns>
        DVD ReadDvdById(int id);

        /// <summary>
        /// Retrieve a DVD record by its title
        /// </summary>
        /// <param name="title">String for the title in library</param>
        /// <returns>DVD by that title</returns>
        /// <exception cref="LibraryDaoException">If unable to load from file</exception>
        DVD ReadDvdByTitle(string title);

        /// <summary>
        /// Retrieve all records
        /// </summary>
        /// <returns>List of all DVDs</returns>
        /// <exception cref="LibraryDaoException">If unable to load from file</exception>
        List<DVD> ReadAll();

        /// <summary>
        /// Retrieve records by director
        /// </summary>
        /// <param name="director">string for director name</param>
        /// <returns>List of DVDs by director</returns>
        List<DVD> ReadAllByDirector(string director);

        /// <summary>
        /// Retrieve records by studio
        /// </summary>
        /// <param name="studio">string for studio name</param>
        /// <returns>List of DVDs by studio</returns>
        List<DVD> ReadAllByStudio(string studio);

        /// <summary>
        /// Retrieve all records by release year
        /// </summary>
        /// <param name="release">DateTime containing release year</param>
        /// <returns>List of DVDs for that year</returns>
        List<DVD> ReadAllByReleaseYear(DateTime release);

        /// <summary>
        /// Retrieve all records by MPAA rating
        /// </summary>
        /// <param name="mpaaRating">string for the MPAA rating of film</param>
        /// <returns>List of DVDs for that rating</returns>
        List<DVD> ReadAllByMpaaRating(string mpaaRating);

        /// <summary>
        /// Update a DVD record
        /// </summary>
        /// <param name="update">Well formed DVD that updates an existing record</param>
        /// <returns>DVD that was successfully edited and persisted</returns>
        /// <exception cref="LibraryDaoException">If unable to persist to file</exception>
        DVD UpdateDvd(DVD update);

        /// <summary>
        /// Delete a DVD record
        /// </summary>
        /// <param name="id">Int id for record</param>
        /// <returns>True if deleted and the change was persisted, false otherwise</returns>
        /// <exception cref="LibraryDaoException">If unable to load from file</exception>
        bool DeleteDvd(int id);
    }
}