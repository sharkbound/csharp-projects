using System.Windows;
using WPFApp1.src;
using System.Diagnostics;
using System.IO;
using System;
using static WPFApp1.src.Misc;
//using static WPFApp1.src.Logger;

namespace WPFApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateDir_btn_Click(object sender, RoutedEventArgs e)
        {
            Dir dir = new Dir();
            Logger logger = GetLogger();
            string enteredPath = GetEnteredPath();

            if (pathIsEmpty())
                return;

            if (dir.CreateDirectory(enteredPath, log: true))
            {
                if ((bool)OpenDirBox.IsChecked && dir.IsDirectory(enteredPath))
                {
                    Process.Start(enteredPath);
                }
            }
        }

        private void DeleteDir_btn_Click(object sender, RoutedEventArgs e)
        {
            Dir dir = new Dir();
            Logger logger = GetLogger();
            string enteredPath = GetEnteredPath();

            if (pathIsEmpty())
                return;

            dir.DeleteDirectory(enteredPath, log: true);
        }

        string GetEnteredPath()
        {
            return CreateDirTextBox.Text;
        }

        bool pathIsEmpty()
        {
            bool empty = string.IsNullOrWhiteSpace(GetEnteredPath());
            if (empty)
            {
                GetLogger().Log("The directory path cannot be blank or null!");
            }
            return empty;
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            Dir.checkIfDataFileAndDirExist();
            var xml = new XmlHelper();
            xml.CreateXmlFile();

            for (int ii = 0; ii < 10; ii++)
            {
                DirList.Items.Add($"test item {ii}");
            }

            DirList.Items.Add("test");
        }

        public Logger GetLogger()
        {
            return new Logger(ref OutputTextBlock, Dispatcher);
        }

        private void DeleteAllDirs_btn_Click(object sender, RoutedEventArgs e)
        {
            var m = GetMain();
            ClearDirList();

            foreach (var dir in m.DirList.Items)
            {
                //ToDo: add this
                //if (Directory.Exists())
            }
        }

        private void DeleteSelDir_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedValue = (string)DirList.SelectedValue;
            if (selectedValue == null) return;
            
            if (!Directory.Exists(selectedValue))
            {
                Log("Directory does not exist!");
                return;
            }

            var files = Dir.GetFiles(selectedValue);
            //if (files.Length == 0)
            //{
            //    try
            //    {
            //        Directory.Delete(selectedValue);
            //        Log($"Deleted directory {selectedValue}!");
            //    }
            //    catch
            //    {
            //        Log($"Some error occured trying to remove directory: {selectedValue}");
            //    }
            //    return;
            //}

            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }

            try
            {
                Directory.Delete(selectedValue);
                Log($"Deleted directory {selectedValue}!");
            }
            catch
            {
                Log($"Some error occured trying to remove directory: {selectedValue}");
            }

            ClearDirList();
            PopulateDirList();
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void OpenDirBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            XmlHelper xml = new XmlHelper();

            if (XmlHelper.ConfigExist())
            {
                xml.DeleteConfig();
                xml.CreateXmlFile();
            }
            else
            {
                xml.CreateXmlFile();
            }
        }

        private void OpenXML_btn_Click(object sender, RoutedEventArgs e)
        {
            XmlHelper xml = new XmlHelper();

            if (XmlHelper.ConfigExist())
            {
                XmlHelper.OpenConfig();
            }
        }

        private void DeleteDataDir_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(XmlHelper.FileFolder))
            {
                var files = Directory.GetFiles(XmlHelper.FileFolder, "*.*", SearchOption.TopDirectoryOnly);
                var folders = Directory.GetDirectories(XmlHelper.FileFolder, "*", SearchOption.TopDirectoryOnly);
                var data_dir = $"{Directory.GetCurrentDirectory() + @"\" + XmlHelper.FileFolder}";

                if (files.Length > 1 || folders.Length > 0)
                {
                    string foundFilesList = string.Join(",\n\t", files);
                    string foundFoldersList = string.Join(",\n\t", folders);

                    if (foundFilesList.Length == 0) foundFilesList = "None";
                    if (foundFoldersList.Length == 0) foundFoldersList = "None";

                    var choice = YesNoPrompt($"Found {files.Length} files, {folders.Length} folders in {data_dir}:\n\nFiles Found:\n\t{foundFilesList}\n\nFolders found:\n\t{foundFoldersList}\n\n Do you still want to delete the directory?",
                        "Data folder delete confirmation");

                    if (choice == MessageBoxResult.No)
                    {
                        Log("Data folder removal canceled!");
                        return;
                    }

                    foreach (var file in files)
                    {
                        Dir.DeleteFileIfExist(file);
                    }

                    foreach (var folder in folders)
                    {
                        Directory.Delete(folder);
                    }
                }

                Dir.DeleteFileIfExist(XmlHelper.FilePath);
                Directory.Delete(XmlHelper.FileFolder);
                Log("Deleted Data Directory!");
            }
        }

        private void CreateDataDir_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(XmlHelper.FileFolder))
            {
                Directory.CreateDirectory(XmlHelper.FileFolder);
                Log("Created the Data directory!");
            }
            else
            {
                Log("Data directory already exist!");
            }
        }

        private void OpenCurrDir_btn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Directory.GetCurrentDirectory());
            Log("Opened Current Directory!");
        }
    }
}
