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

namespace MyFirstForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text, textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "name cannot be empty or whitespace!";
            }
            else
            {
                variables.filename = textBox3.Text + ".txt";
                if (!File.Exists("textfiles/" + variables.filename))
                {
                    try
                    {
                        if (!Directory.Exists("textfiles"))
                        {
                            Directory.CreateDirectory("textfiles");
                        }
                        StreamWriter w = new StreamWriter("textfiles/" + variables.filename);
                        w.Close();
                       // File.Create(variables.filename);
                       // File.CreateText(variables.filename);
                    }
                    catch
                    {
                        textBox3.Text = "error making file!";
                    }


                }
                else
                {
                    MessageBox.Show("that file name already exist!", "notification");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("textfiles/" + variables.filename);
            }
            catch
            {
                textBox3.Text = "a error as occured!";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                File.AppendAllText("textfiles/" + variables.filename, DateTime.Now + ": " + textBox3.Text + "\n");
            }
            catch
            {
                textBox3.Text = "an error as occured!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            variables.filename = textBox3.Text + ".txt";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists("textfiles/" + textBox3.Text + ".txt"))
            {
                File.Delete("textfiles/" + textBox3.Text + ".txt");
                textBox3.Text = "File Deleted!";
            }
            else
            {
                textBox3.Text ="the file textfiles/" + textBox3.Text + " does not exist!";
            }
        }

    }
}
