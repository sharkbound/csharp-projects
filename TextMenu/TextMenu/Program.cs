using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private void Start()
        {
            var menu = new Menu("--> ", new List<MenuItem>
            {
                new MenuItem("Hello World", () => Console.WriteLine("Hello World!")),
                new MenuItem("Create Folder", () => CreateFolderMenuOption()),
                new MenuItem("Open Folder", () => OpenFolderMenuOption())
            });

            menu.Execute();
        }

        private void CreateFolderMenuOption()
        {
            Console.WriteLine("Enter folder name: ");
            string folder = Console.ReadLine();

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Console.WriteLine("Created Folder " + folder);
            }
            else
            {
                Console.WriteLine(folder + " already exist");
            }
        }

        private void OpenFolderMenuOption()
        {
            Console.WriteLine("Enter folder name: ");
            string folder = Console.ReadLine();

            if (Directory.Exists(folder))
            {
                Process.Start(folder);
                Console.WriteLine("Openned Folder " + folder);
            }
            else
            {
                Console.WriteLine(folder + " does not exist");
            }
        }
    }
}
