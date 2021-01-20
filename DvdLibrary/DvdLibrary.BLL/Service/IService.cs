using System;
using System.Collections.Generic;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.BLL.Service
{
    public interface IService
    {
        /// <summary>
        /// Validate a new DVD request
        /// </summary>
        /// <param name="dvdRequest">Partially formed DVD obj</param>
        /// <returns>Well formed DVD obj</returns>
        DVD ValidateDvd(DVD dvdRequest);

        /// <summary>
        /// Create new DVD and persist record
        /// </summary>
        /// <param name="dvd">Well formed DVD obj</param>
        /// <returns></returns>
        /// <exception cref="PersistenceFailedException"></exception>
        DVD CreateDvd(DVD dvd);

        /// <summary>
        /// Read a DVD record by ID
        /// </summary>
        /// <param name="id">int for DVD id</param>
        /// <returns>DVD from file</returns>
        /// <exception cref="NoRecordException">If key is invalid</exception>
        DVD ReadDvdById(int id);

        /// <summary>
        /// Read a DVD record by title
        /// </summary>
        /// <param name="title">string for DVD title</param>
        /// <returns>DVD from file</returns>
        /// <exception cref="NoRecordException">If title is invalid</exception>
        DVD ReadDvdByTitle(string title);

        /// <summary>
        /// Read all DVDs from file
        /// </summary>
        /// <returns>List of all DVDs</returns>
        /// <exception cref="NoRecordException">If library is empty</exception>
        List<DVD> ReadAll();

        /// <summary>
        /// Read all DVDs for director
        /// </summary>
        /// <param name="director">string for director name</param>
        /// <returns>List of all DVDs for that director</returns>
        /// <exception cref="NoRecordException">If list is empty</exception>
        List<DVD> ReadAllByDirector(string director);

        /// <summary>
        /// Read all DVDs for studio
        /// </summary>
        /// <param name="studio">string for studio name</param>
        /// <returns>List of all DVDs for that studio</returns>
        /// <exception cref="NoRecordException">If list is empty</exception>
        List<DVD> ReadAllByStudio(string studio);

        /// <summary>
        /// Read all DVDs released that year
        /// </summary>
        /// <param name="release">DateTime for release date</param>
        /// <returns>List of all DVDs released that year</returns>
        /// <exception cref="NoRecordException">If list is empty</exception>
        List<DVD> ReadAllByReleaseYear(DateTime release);

        /// <summary>
        /// Read all DVDs for MPAA rating
        /// </summary>
        /// <param name="mpaaRating">string for MPAA rating</param>
        /// <returns>List of all DVDs for that MPAA rating</returns>
        /// <exception cref="NoRecordException">If list is empty</exception>
        List<DVD> ReadAllByMpaaRating(string mpaaRating);

        /// <summary>
        /// Update a DVD record and persist changes
        /// </summary>
        /// <param name="update">Well formed DVD obj with a id that matches an existing record</param>
        /// <returns>DVD update</returns>
        /// <exception cref="PersistenceFailedException">If key is invalid</exception>
        DVD UpdateDvd(DVD update);

        /// <summary>
        /// Delete a DVD record
        /// </summary>
        /// <param name="id">int for an existing DVD record</param>
        /// <returns>True if deleted and removal was persisted, false otherwise</returns>
        /// <exception cref="PersistenceFailedException">If key is invalid</exception>
        bool DeleteDvd(int id);
    }
}