using DvdLibrary.BLL.Service;
using DvdLibrary.UI.Controller;
using DvdLibrary.UI.View;

namespace DvdLibrary.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            DvdLibraryController c = new DvdLibraryController(new Service(), new DvdLibraryView());
            c.Run();
        }
    }
}