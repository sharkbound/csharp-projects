using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1;
using System.Windows.Controls;
using System.IO;

namespace WPFApp1.src
{
    public class Misc
    {
        public static MainWindow GetMain()
        {
            return (MainWindow)Application.Current.MainWindow;
        }

        public static Logger GetLogger()
        {
            return GetMain().GetLogger();
        }

        public static void Log(string msg, bool clear = false, int delay = 2000)
        {
            GetLogger().Log(msg, clear, delay);
        }

        public static MessageBoxResult YesNoPrompt(string innerText, string title = "", MessageBoxImage boxImg = MessageBoxImage.Information, MessageBoxResult defaultResult = MessageBoxResult.No)
        {
            //MessageBox.Show()
            return MessageBox.Show(innerText, title, MessageBoxButton.YesNo, boxImg, defaultResult);
        }

        public static void ClearDirList(bool restoreDefaults = true)
        {
            var m = GetMain();
            if (m.DirList.Items.Count < 2) return;

            m.DirList.Items.Clear();
            if (restoreDefaults) AddedDefaultDirListItems();
        }

        public static void PopulateDirList()
        {
            var m = GetMain();
            var dirs = Dir.GetDirectories(Directory.GetCurrentDirectory());
            foreach (var dir in dirs)
            {
                m.DirList.Items.Add(dir);
            }
        }

        public static void AddedDefaultDirListItems()
        {
            var m = GetMain();
            m.DirList.Items.Add("Created Directories:");
            m.DirList.Items.Add(new Separator());
        }
    }
}
