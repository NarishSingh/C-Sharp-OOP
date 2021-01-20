using System;
using System.Collections.Generic;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.BLL.Service
{
    public interface IService
    {
        DVD ValidateDvd(DVD dvdRequest);

        DVD CreateDvd(DVD dvd);

        DVD ReadDvdById(int id);

        DVD ReadDvdByTitle(string title);

        List<DVD> ReadAll();

        List<DVD> ReadAllByDirector(string director);

        List<DVD> ReadAllByStudio(string studio);

        List<DVD> ReadAllByReleaseYear(DateTime release);

        List<DVD> ReadAllByMpaaRating(string mpaaRating);

        DVD UpdateDvd(DVD update);

        bool DeleteDvd(int id);
    }
}