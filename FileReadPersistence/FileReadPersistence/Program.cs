using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileReadPersistence
{
    class Program
    {
        public class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Street1 { get; set; }
            public string Street2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
        }

        static void Main(string[] args)
        {
            /*persist*/
            string path = @".\list.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            string[] lines =
            {
                "Blue",
                "Green",
                "Yellow",
                "Red",
                "Orange"
            };

            File.WriteAllLines(path, lines); //brute force write everything

            //stream writer -> with the using expr, will automatically close when done
            //this way will delete anything written tho...
            /*
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("I am a disco dancer");
            }
            */

            //use this to append to the end of file
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine("I am a disco dancer");
            }

            /*read in*/
            string[] readLines = File.ReadAllLines(path); //brute force read everything

            foreach (string line in readLines)
            {
                Console.WriteLine(line);
            }

            //stream reader for more fine tuned control
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                //if returns null -> EOF, stop reading
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            //structuring text so lines = records
            string path2 = @".\records.txt";

            if (!File.Exists(path2))
            {
                File.Create(path2);
            }

            using (StreamWriter writer = new StreamWriter(path2))
            {
                writer.WriteLine("FirstName,LastName,Street1,Street2,City,State,Zip");
                writer.WriteLine("Joe,Somebody,123 Main St,,Akron,OH,44311");
                writer.WriteLine("Mary,Person,250 Maple Ave,Apt 305,Toledo,OH,43449");
            }

            //read it in now
            if (File.Exists(path2))
            {
                string[] rows = File.ReadAllLines(path2);

                List<Contact> contacts = new List<Contact>();

                //split each record into its cols of data, and create the obj
                //start from 1 to skip the header
                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(",");

                    Contact c = new Contact();
                    c.FirstName = columns[0];
                    c.LastName = columns[1];
                    c.Street1 = columns[2];
                    c.Street2 = columns[3];
                    c.City = columns[4];
                    c.State = columns[5];
                    c.ZipCode = columns[6];

                    contacts.Add(c);
                }

                //use LINQ to order by last name and print a mailing label
                foreach (Contact contact in contacts.OrderBy(c => c.LastName))
                {
                    Console.WriteLine($"{contact.LastName}, {contact.FirstName}");
                    Console.WriteLine($"{contact.Street1}");

                    if (!string.IsNullOrEmpty(contact.Street2))
                    {
                        Console.WriteLine($"{contact.Street2}");
                    }

                    Console.WriteLine($"{contact.City}, {contact.State} {contact.ZipCode}");

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Could not find file at {path2}");
            }

            /*drive info*/
            DriveInfo oneDrive = new DriveInfo("C");
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (var drive in allDrives)
            {
                // [1] Print Sizes.
                Console.WriteLine(drive.AvailableFreeSpace);
                Console.WriteLine(drive.TotalFreeSpace);
                Console.WriteLine(drive.TotalSize);
                Console.WriteLine();

                // [2] Format and type.
                Console.WriteLine(drive.DriveFormat);
                Console.WriteLine(drive.DriveType);
                Console.WriteLine();

                // [3] Name and directories
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.RootDirectory);
                Console.WriteLine(drive.VolumeLabel);
                Console.WriteLine();

                Console.WriteLine(drive.IsReady);
            }

            /*dir info*/
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("****** Directory Info ******");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("***************************\n");

            /*subdir manip*/
            DirectoryInfo dir2 = new DirectoryInfo(".");
            
            dir2.CreateSubdirectory("MyFolder"); //Create \MyFolder off the initial directory.
            
            DirectoryInfo myDataFolder = dir2.CreateSubdirectory(@"MyFolder2\Data");
            
            Console.WriteLine("New Folder is: {0}", myDataFolder);

            //delete
            DirectoryInfo dir3 = new DirectoryInfo(@".\Myfolder");
            dir3.Delete();

            // The second parameter specifies whether you wish to destroy any subdirectories
            dir3 = new DirectoryInfo(@".\MyFolder2");
            dir3.Delete(true);
            
            //file info in a dir
            DirectoryInfo dir4 = new DirectoryInfo(@"C:\Users\naris\Documents\Work\TECHHIRE\REPOSITORY\C-Sharp-OOP\FileReadPersistence\FileReadPersistence\bin\Debug\net5.0\pics");
            
            FileInfo[] imageFiles = dir4.GetFiles("*.jpg", SearchOption.AllDirectories);
 
// How many were found?
            Console.WriteLine("Found {0} *.jpg files \n", imageFiles.Length);
 
//Now print out info for each file
            foreach(FileInfo f in imageFiles)
            {
                Console.WriteLine("**********************");
                Console.WriteLine("File Name: {0}", f.Name);
                Console.WriteLine("File Size: {0}", f.Length);
                Console.WriteLine("creation: {0}", f.CreationTime );
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("**********************");
 
            }
        }
    }
}