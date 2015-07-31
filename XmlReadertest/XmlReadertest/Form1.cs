using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlReadertest
{
    public partial class Form1 : Form
    {
        static string dir = Directory.GetCurrentDirectory() + @"\XmlItems";
        static string filedir = dir + @"\Settings.xml";
        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists("XmlItems"))
            {
                Directory.CreateDirectory("XmlItems");
            }
            Directory.SetCurrentDirectory(dir);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // textBox2.Text = filedir;
            XmlReader xml = ReturnReader();
           // xml.ReadToFollowing(textBox3.Text);
            //listBox1.Items.Add(xml.Value);
            xml.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Settings.xml"))
            {
                XmlMaker();
            }
            else
            {
                File.Delete(filedir);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var val = textBox1.Text;
           // var doc = Returndoc();
            var doc = Returndoc();
            textBox2.Text = filedir;

             doc.LoadXml(filedir);
            //doc.LoadXml(filedir.Substring(filedir.IndexOf(Environment.NewLine)));

            //XmlNode values = doc.CreateElement("StoredValues");
            //XmlNode textboxval = doc.CreateElement(val);
            //textboxval.InnerText = textBox2.Text;
            //values.AppendChild(textboxval);
            //doc.DocumentElement.AppendChild(values);
            //doc.Save(dir); 
        }

        private XmlTextWriter ReturnXmlTextWriter()
        {
           return new XmlTextWriter("Settings.xml", Encoding.Unicode);
        }

        private XmlTextReader ReturnXmlTextReader()
        {
           return new XmlTextReader("Settings.xml");
        }

        private XmlReader ReturnReader()
        {
            return XmlReader.Create("Settings.xml");
        }

        private XmlWriter ReturnWriter()
        {
           return XmlWriter.Create("Settings.xml");
        }

        public XmlDocument Returndoc()
        {
            return new XmlDocument();
        }

        private void XmlMaker()
        {
            XmlWriter x = ReturnWriter();
            x.WriteStartDocument();
            x.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(dir);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(filedir);
        }
    }
}
