using System;
using StudentManagementSystem.BLL.DAO;
using StudentManagementSystem.UI.Controller;
using StudentManagementSystem.UI.View;

namespace StudentManagementSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SMSController c = new SMSController(new StudentRepository(), new SMSView());

            c.Run();
        }
    }
}