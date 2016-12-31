using System.IO;
using System.Windows.Controls;
using WPFApp1;
using static WPFApp1.src.Misc;

namespace WPFApp1.src
{
    public class Dir
    {
        MainWindow main;
        Logger logger;

        public Dir()
        {
            main = GetMain();
            logger = main.GetLogger();
        }

        public bool CreateDirectory(string path, bool log = false)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                if (log)
                    logger.Log($"Created directory: {path}");
                return true;
            }
            else
            {
                if (log)
                    logger.Log($"Directory {path} already exist!");
                return false;
            }
        }

        public bool DeleteDirectory(string path, bool log = false)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
                if (log)
                    logger.Log($"Deleted directory: {path}");
                return true;
            }
            else
            {
                if (log)
                    logger.Log($"Directory {path} does not exist!");
                return false;
            }
        }

        public bool Exist(string path, bool log = false)
        {
            var exist = Directory.Exists(path);
            if (log)
            {
                if (exist)
                {
                    var main = new MainWindow();
                }
            }
            return exist;
        }

        public static void DeleteFileIfExist(string path)
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

        public static void checkIfDataFileAndDirExist()
        {
            if (!Directory.Exists(XmlHelper.FileFolder))
            {
                Directory.CreateDirectory(XmlHelper.FileFolder);
            }
        }
    }
}
