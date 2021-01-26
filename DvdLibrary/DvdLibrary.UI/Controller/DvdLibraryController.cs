using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DvdLibrary.BLL.DTO;
using DvdLibrary.BLL.Service;
using DvdLibrary.UI.View;

namespace DvdLibrary.UI.Controller
{
    public class DvdLibraryController
    {
        private IService _service;
        private DvdLibraryView _view;

        public DvdLibraryController(IService service, DvdLibraryView view)
        {
            _service = service;
            _view = view;
        }

        /**
         * App run loop
         */
        public void Run()
        {
            bool running = true;
            int slct;

            while (running)
            {
                Console.Clear();
                _view.PrintMainMenu();
                slct = GetMenuSelection();

                switch (slct)
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        ListLibrary();
                        break;
                    case 2:
                        AddDvd();
                        break;
                    case 3:
                        RemoveDvd();
                        break;
                    case 4:
                        UpdateDvd();
                        break;
                    case 5:
                        SearchMenu();
                        break;
                }
            }

            ExitMsg();
        }

        /// <summary>
        /// Get menu selection
        /// </summary>
        /// <returns>int between 0-5, 0 signals quit</returns>
        private int GetMenuSelection()
        {
            return _view.GetMenuChoice(1, 5);
        }

        /// <summary>
        /// View entire library
        /// </summary>
        private void ListLibrary()
        {
            Console.Clear();
            _view.DisplayOpeningBanner("Library");

            try
            {
                List<DVD> dvds = _service.ReadAll();
                _view.ListDvds(dvds);
            }
            catch (NoRecordException e)
            {
                _view.DisplayErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// Add new dvd record to file
        /// </summary>
        private void AddDvd()
        {
            Console.Clear();
            _view.DisplayOpeningBanner("Add DVD");

            DVD request = _view.newDvd();
            if (_view.ConfirmAdd(request))
            {
                try
                {
                    _service.CreateDvd(_service.ValidateDvd(request));
                    _view.DisplaySuccessBanner("DVD successfully added.");
                }
                catch (PersistenceFailedException e)
                {
                    _view.DisplayErrorMsg(e.Message);
                }
            }
            else
            {
                _view.DisplayCancelBanner("Add canceled");
            }
        }

        /// <summary>
        /// Remove DVD record from library
        /// </summary>
        private void RemoveDvd()
        {
            Console.Clear();
            _view.DisplayOpeningBanner("Remove DVD from Library");

            List<DVD> dvds;
            try
            {
                dvds = _service.ReadAll();
                _view.ListIndexedDvds(dvds);

                //get validated id and pull by that key
                int minKey = dvds.Select(d => d.Id).Min();
                int maxKey = dvds.Select(d => d.Id).Max();
                int i = _view.SelectForRemoval(minKey, maxKey);

                DVD del = _service.ReadDvdById(i);

                if (_view.RemoveConfirmation(del))
                {
                    _service.DeleteDvd(i);
                    _view.DisplaySuccessBanner("DVD successfully removed.");
                }
                else
                {
                    _view.DisplayCancelBanner("Delete canceled");
                }
            }
            catch (Exception e) when (e is NoRecordException || e is PersistenceFailedException)
            {
                _view.DisplayErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// Update DVD record in library
        /// </summary>
        private void UpdateDvd()
        {
            Console.Clear();
            _view.DisplayOpeningBanner("Update DVD");

            List<DVD> dvds;
            try
            {
                dvds = _service.ReadAll();
                _view.ListIndexedDvds(dvds);

                int minKey = dvds.Select(d => d.Id).Min();
                int maxKey = dvds.Select(d => d.Id).Max();
                int i = _view.SelectForUpdate(minKey, maxKey);

                DVD updateRequest = _view.EditDvd(_service.ReadDvdById(i));

                if (_view.EditConfirmation(updateRequest))
                {
                    _service.UpdateDvd(updateRequest);
                    _view.DisplaySuccessBanner("DVD successfully edited.");
                }
                else
                {
                    _view.DisplayCancelBanner("Edit canceled.");
                }
            }
            catch (Exception e) when (e is NoRecordException || e is PersistenceFailedException)
            {
                _view.DisplayErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// Search submenu functionality
        /// </summary>
        private void SearchMenu()
        {
            bool searching = true;

            while (searching)
            {
                Console.Clear();
                _view.DisplayOpeningBanner("Search");

                _view.DisplaySearchMenu();

                try
                {
                    int slct = _view.GetMenuChoice(1, 5);
                    string searchQuery;
                    switch (slct)
                    {
                        case 1:
                            searchQuery = _view.GetSearchQuery();
                            DVD dvd = _service.ReadDvdByTitle(searchQuery);
                            _view.ListDvds(new List<DVD> {dvd});
                            break;
                        case 2:
                            searchQuery = _view.GetSearchQuery();
                            List<DVD> byDir = _service.ReadAllByDirector(searchQuery);
                            _view.ListDvds(byDir);
                            break;
                        case 3:
                            searchQuery = _view.GetSearchQuery();
                            List<DVD> byStu = _service.ReadAllByStudio(searchQuery);
                            _view.ListDvds(byStu);
                            break;
                        case 4:
                            searchQuery = _view.GetSearchQuery();
                            if (DateTime.TryParseExact(searchQuery, "yyyy", CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out DateTime dateQuery))
                            {
                                List<DVD> byYr = _service.ReadAllByReleaseYear(dateQuery);
                                _view.ListDvds(byYr);
                            }

                            break;
                        case 5:
                            searchQuery = _view.GetSearchQuery();
                            List<DVD> byMpaa = _service.ReadAllByMpaaRating(searchQuery);
                            _view.ListDvds(byMpaa);
                            break;
                        case 0:
                            searching = false;
                            break;
                    }
                }
                catch (NoRecordException e)
                {
                    _view.DisplayErrorMsg(e.Message);
                }
            }
        }

        /// <summary>
        /// Display exit banner for app
        /// </summary>
        private void ExitMsg()
        {
            _view.DisplayExitMsg();
        }
    }
}