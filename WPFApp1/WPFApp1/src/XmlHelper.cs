using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Xml;
using App.MiscFuncs;
using App.logging;

namespace App.Xml
{
    public class XmlHelper
    {
        public static readonly string FilePath = @"Data\Data.xml";
        public static readonly string FileName = "Data.xml";
        public static readonly string FileFolder = "Data";

        Logger logger = new Logger();

        public XmlHelper()
        {
            CreateXmlFile();
        }

        XmlWriter getWriter()
        {
            return XmlWriter.Create(FilePath, getWriterSettings());
        }

        XmlReader getReader()
        {
            return XmlReader.Create(FilePath);
        }

        XmlDocument getDoc()
        {
            var doc = new XmlDocument();
            doc.LoadXml(FilePath);
            return doc;
        }

        XmlWriterSettings getWriterSettings()
        {
            return new XmlWriterSettings { Indent = true };
        }

        public static bool ConfigExist()
        {
            return File.Exists(FilePath);
        }

        public static void OpenConfig()
        {
            if (ConfigExist())
            {
                Process.Start(FilePath);
            }
        }

        public void DeleteConfig()
        {
            if (ConfigExist())
            {
                File.Delete(FilePath);
            }
        }

        public void CreateXmlFile(string fileDir = "Data/Data.xml", bool log = true)
        {
            if (!Directory.Exists(FileFolder)) Directory.CreateDirectory(FileFolder);
            if (ConfigExist()) return;

            XmlWriter w = getWriter();

            w.WriteStartDocument(true);

            w.WriteStartElement("Directories");
            addValue("Path", @"Logs", w);
            addValue("Path", "Logs", w);
            w.WriteEndElement();
            //writeValue(fileDir, writer);

            w.WriteEndDocument();
            w.Close();

            logger.Log("Created xml config file!");
        }

        private void addValue(string node, string value, XmlWriter writer)
        {
            //writer.WriteStartElement("Directories");
            //createDirectoryNode(fileDir, writer);
            //writer.WriteEndElement();

            writer.WriteStartElement(node);
            writer.WriteString(value);
            writer.WriteEndElement();
        }



        public void AddDirectoryElement(string path)
        {
            //var w = getWriter();
            //w.
            var doc = getDoc();
            var dirs = doc.GetElementsByTagName("Directories");
        }

        void createNode(string node, string value, XmlWriter writer)
        {
            //writer.WriteStartElement(node);
            //writer.WriteString(value);
            //writer.WriteEndElement();

            writer.WriteElementString(node, value);
        }

        void createDirectoryNode(string directory, XmlWriter writer)
        {
            writer.WriteStartElement("Path");
            writer.WriteString(directory);
            writer.WriteEndElement();
        }
    }
}
