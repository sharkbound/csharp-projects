using System.Windows;
using System.Windows.Controls;
using App.logging;
using App.DirHelper;
using System.IO;
using App.ExtensionMethods;

namespace App.MiscFuncs
{
    public class Misc
    {
        Dir dir = new Dir();
        Logger logger = new Logger();
        MainWindow main = ((MainWindow)Application.Current.MainWindow);

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
            var dirs = dir.GetDirectories(Directory.GetCurrentDirectory()).CutPath();
            foreach (var dir in dirs)
            {
                main.DirList.Items.Add(dir);
            }
        }

        public void AddedDefaultDirListItems()
        {
            main.DirList.Items.Add("Found Directories:");
            main.DirList.Items.Add(new Separator());
        }

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
