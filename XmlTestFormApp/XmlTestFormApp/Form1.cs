using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace XmlTestFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "trying to make Xml Document...";
                XmlDocument xDoc = new XmlDocument();
                xDoc.Save("XmlTestDoc");

            }
            catch (Exception)
            {
                textBox2.Text = "failed to create Xml Document!";
            }
        }
    }
}
