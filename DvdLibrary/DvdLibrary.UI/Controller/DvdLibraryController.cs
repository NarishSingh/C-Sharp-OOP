using System;
using System.Collections.Generic;
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

                        break;

                    case 5:
                        //TODO this will lead to sub menu for search
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
            _view.DisplayLibraryBanner();

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
            _view.DisplayAddBanner();

            DVD request = _view.newDvd();
            if (_view.ConfirmAdd(request))
            {
                try
                {
                    _service.CreateDvd(_service.ValidateDvd(request));
                    _view.DvdAddedSuccess();
                }
                catch (PersistenceFailedException e)
                {
                    _view.DisplayErrorMsg(e.Message);
                }
            }
            else
            {
                _view.DvdAddCanceled();
            }
        }

        private void RemoveDvd()
        {
            Console.Clear();
            _view.DisplayRemoveBanner();

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
                    _view.RemoveSuccess();
                }
                else
                {
                    _view.RemoveCanceled();
                }
            }
            catch (Exception e) when (e is NoRecordException || e is PersistenceFailedException)
            {
                _view.DisplayErrorMsg(e.Message);
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