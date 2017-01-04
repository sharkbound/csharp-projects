using System.Windows;
using System.Windows.Controls;
using App.logging;
using App.DirHelper;
using System.IO;
using App.ExtensionMethods;
using System;
using System.Diagnostics;
using System.Reflection;

namespace App.MiscFuncs
{
    public class Misc
    {
        Dir dir = new Dir();
        Logger logger = new Logger();
        MainWindow main = ((MainWindow)Application.Current.MainWindow);
        public static readonly string ExecDir = Assembly.GetExecutingAssembly().Location;

        public Misc()
        {
        }

        public void Log(string msg, bool clear = false, int delay = 2000)
        {
            logger.Log(msg, clear, delay);
        }

        public MessageBoxResult YesNoPrompt(string innerText, string title = "", MessageBoxImage boxImg = MessageBoxImage.Information, MessageBoxResult defaultResult = MessageBoxResult.No)
        {
            //MessageBox.Show()
            return MessageBox.Show(innerText, title, MessageBoxButton.YesNo, boxImg, defaultResult);
        }

        public void ClearDirList(bool restoreDefaults = true)
        {
            if (main.DirList.Items.Count < 2) return;

            main.DirList.Items.Clear();
            if (restoreDefaults) AddedDefaultDirListItems();
        }

        public void PopulateDirList()
        {
            //var dirs = dir.GetDirectories(Directory.GetCurrentDirectory()).CutPath();
            foreach (var dir in Directory.GetDirectories(Directory.GetCurrentDirectory()).CutPath())
            {
                if (dir == "Data" || dir == "WPFApp1") continue;

                main.DirList.Items.Add(dir);
                foreach (var file in Directory.GetFiles(dir))
                {
                    main.DirList.Items.Add($"-> {file.CutPath()}");
                }
            }
        }

        public void AddedDefaultDirListItems()
        {
            main.DirList.Items.Add("Found Directories:");
            main.DirList.Items.Add(new Separator());
        }

        //public void CheckAppDirOrMove()
        //{
        //    var fName = AppDomain.CurrentDomain.FriendlyName;
        //    var destDir = $"WPFApp1\\{fName}";

        //    if (Directory.GetParent(Directory.GetCurrentDirectory()).Name != "WPFApp1")
        //    {
        //        if (!Directory.Exists("WPFApp1")) Directory.CreateDirectory("WPFApp1");
        //        if (File.Exists(destDir)) File.Delete(destDir);

        //        File.Move(AppDomain.CurrentDomain.FriendlyName, destDir);
        //        Process.Start(destDir);
        //        Application.Current.Shutdown();
        //    }

        //    Directory.SetCurrentDirectory(ExecDir);
        //}

        //public static MainWindow GetMain()
        //{
        //    return (MainWindow)Application.Current.MainWindow;
        //}

        //public static Logger GetLogger()
        //{
        //    return GetMain().GetLogger();
        //}
    }
}
