using System;
using SGBank.BLL;
using SGBank.Models.Responses;
using SGBank.UI.View;

namespace SGBank.UI
{
    public class BankController
    {
        private IAcctService _service;
        private BankView _view;

        public BankController(IAcctService service, BankView view)
        {
            _service = service;
            _view = view;
        }

        /// <summary>
        /// App run loop
        /// </summary>
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
                        AcctLookup();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }

                ExitMsg();
            }
        }

        /// <summary>
        /// Get menu selection
        /// </summary>
        /// <returns>int between 0-3, 0 signals quit</returns>
        private int GetMenuSelection()
        {
            return _view.GetMenuChoice(1, 3);
        }
        
        /// <summary>
        /// Lookup an existing account
        /// </summary>
        private void AcctLookup()
        {
            Console.Clear();
            _view.DisplayOpeningBanner("View Account");

            string acctNum = _view.GetNumForLookup();
            AcctLookupResponse a = _service.LookupAcct(acctNum);

            if (a.Success)
            {
                _view.DisplayAcctDetails(a.Acct);
            }
            else
            {
                _view.DisplayErrorMsg(a.Msg);
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