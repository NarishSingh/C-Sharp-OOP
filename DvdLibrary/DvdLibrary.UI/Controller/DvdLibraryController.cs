using System;
using System.Collections.Generic;
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

                        break;
                    case 3:

                        break;
                    case 4:

                        break;

                    case 5:
                        //this will lead to sub menu for search
                        break;
                }
            }
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

        private void AddDvd()
        {
            Console.Clear();
           _view.DisplayAddBanner();
           
           //TODO finish, might need to split dvd validation from create
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