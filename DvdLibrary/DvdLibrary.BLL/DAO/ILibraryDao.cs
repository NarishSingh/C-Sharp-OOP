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
        /// <exception cref="LibraryDaoException">If unable to persist to file</exception>
        void CreateDvd(DVD dvd);

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
        /// Update a DVD record
        /// </summary>
        /// <param name="update">Well formed DVD that updates an existing record</param>
        /// <returns>DVD that was successfully edited and persisted</returns>
        /// <exception cref="LibraryDaoException">If unable to persist to file</exception>
        void UpdateDvd(DVD update);

        /// <summary>
        /// Delete a DVD record
        /// </summary>
        /// <param name="id">Int id for record</param>
        /// <returns>True if deleted and the change was persisted, false otherwise</returns>
        /// <exception cref="LibraryDaoException">If unable to load from file</exception>
        bool DeleteDvd(int id);
    }
}