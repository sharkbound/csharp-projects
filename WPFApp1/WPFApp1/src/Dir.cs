using App.logging;
using System.IO;
using App.MiscFuncs;
using App.Xml;
using System.Windows;


namespace App.DirHelper
{
    public class Dir
    {
        //MainWindow main = ((MainWindow)Application.Current.MainWindow);
        Logger logger = new Logger();

        public bool CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                logger.Log($"The directory \"{path}\" already exist!");
                return false;
            }

            Directory.CreateDirectory(path);
            logger.Log($"Created directory {path}!");
            return true;
        }

        public bool DeleteDirectory(string path, bool log = false)
        {
            if (!Directory.Exists(path))
            {
                logger.Log($"The directory \"{path}\" does not exist!");
                return false;
            }

            Directory.CreateDirectory(path);
            logger.Log($"Deleted directory {path}!");
            return true;
            
        }

        public void DeleteFileIfExist(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public bool IsDirectory(string path)
        {
            return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        }

        public void checkIfDataFileAndDirExist()
        {
            if (!Directory.Exists(XmlHelper.FileFolder))
            {
                Directory.CreateDirectory(XmlHelper.FileFolder);
            }
        }

        public string[] GetFiles(string directory, string pattern = "*", SearchOption mode = SearchOption.TopDirectoryOnly)
        {
            if (Directory.Exists(directory))
            {
               return Directory.GetFiles(directory, pattern, mode);
            }
            return new string[] { "Directory does not exist!" };
        }

        public string[] GetDirectories(string directory, string pattern = "*", SearchOption mode = SearchOption.TopDirectoryOnly)
        {
            if (Directory.Exists(directory))
            {
                return Directory.GetDirectories(directory, pattern, mode);
            }
            return new string[] { "Directory does not exist!" };
        }
    }
}
