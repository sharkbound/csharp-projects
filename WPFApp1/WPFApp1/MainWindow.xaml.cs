using System.Windows;
using App.logging;
using System.Diagnostics;
using System.IO;
using System;
using App.DirHelper;
using App.MiscFuncs;
using App.Xml;
//using static WPFApp1.src.Logger;

namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dir dir;
        Logger logger;
        Misc misc;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateDir_btn_Click(object sender, RoutedEventArgs e)
        {
            string enteredPath = GetEnteredPath();

            if (pathIsEmpty())
                return;

            if (dir.CreateDirectory(enteredPath))
            {
                if ((bool)OpenDirBox.IsChecked && dir.IsDirectory(enteredPath))
                {
                    Process.Start(enteredPath);
                }
            }

            misc.ClearDirList();
            misc.PopulateDirList();
        }

        private void DeleteDir_btn_Click(object sender, RoutedEventArgs e)
        {
            string enteredPath = GetEnteredPath();

            if (pathIsEmpty())
                return;

            dir.DeleteDirectory(enteredPath, log: true);

            misc.ClearDirList();
            misc.PopulateDirList();
        }

        string GetEnteredPath()
        {
            return CreateDirTextBox.Text;
        }

        bool pathIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(GetEnteredPath()))
            {
                logger.Log("The directory path cannot be blank or null!");
                return true;
            }
            return false;
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            
            logger = new Logger();
            dir = new Dir();
            misc = new Misc();

            dir.checkIfDataFileAndDirExist();
            var xml = new XmlHelper();
            xml.CreateXmlFile();

            misc.PopulateDirList();
        }

        private void DeleteAllDirs_btn_Click(object sender, RoutedEventArgs e)
        {

            foreach (var dir in DirList.Items)
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
                logger.Log("Directory does not exist!");
                return;
            }

            var files = dir.GetFiles(selectedValue);

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
                logger.Log($"Deleted directory {selectedValue}!");
            }
            catch
            {
                logger.Log($"Some error occured trying to remove directory: {selectedValue}");
            }

            misc.ClearDirList();
            misc.PopulateDirList();
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
                var files = dir.GetFiles(XmlHelper.FileFolder, "*.*", SearchOption.TopDirectoryOnly);
                var folders = dir.GetDirectories(XmlHelper.FileFolder, "*", SearchOption.TopDirectoryOnly);
                var data_dir = $"{Directory.GetCurrentDirectory() + @"\" + XmlHelper.FileFolder}";

                if (files.Length > 1 || folders.Length > 0)
                {
                    string foundFilesList = string.Join(",\n\t", files);
                    string foundFoldersList = string.Join(",\n\t", folders);

                    if (foundFilesList.Length == 0) foundFilesList = "None";
                    if (foundFoldersList.Length == 0) foundFoldersList = "None";

                    var choice = misc.YesNoPrompt($"Found {files.Length} files, {folders.Length} folders in {data_dir}:\n\nFiles Found:\n\t{foundFilesList}\n\nFolders found:\n\t{foundFoldersList}\n\n Do you still want to delete the directory?",
                        "Data folder delete confirmation");

                    if (choice == MessageBoxResult.No)
                    {
                        logger.Log("Data folder removal canceled!");
                        return;
                    }

                    foreach (var file in files)
                    {
                        dir.DeleteFileIfExist(file);
                    }

                    foreach (var folder in folders)
                    {
                        Directory.Delete(folder);
                    }
                }

                dir.DeleteFileIfExist(XmlHelper.FilePath);
                Directory.Delete(XmlHelper.FileFolder);
                logger.Log("Deleted Data Directory!");
            }
        }

        private void CreateDataDir_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(XmlHelper.FileFolder))
            {
                Directory.CreateDirectory(XmlHelper.FileFolder);
                logger.Log("Created the Data directory!");
            }
            else
            {
                logger.Log("Data directory already exist!");
            }
        }

        private void OpenCurrDir_btn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Directory.GetCurrentDirectory());
            logger.Log("Opened Current Directory!");
        }

        public MainWindow GetMain()
        {
            return this;
        }
    }
}
