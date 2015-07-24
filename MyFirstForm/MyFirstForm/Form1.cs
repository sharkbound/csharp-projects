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
            variables.filename = textBox3.Text + ".txt";
            if (!File.Exists(variables.filename))
            {
                if (string.IsNullOrWhiteSpace(variables.filename) || string.IsNullOrEmpty(variables.filename))
                {
                    textBox3.Text = "name cannot be empty or whitespace!";
                }
                else
                {
                    try
                    {
                        File.CreateText(variables.filename);

                    }
                    catch
                    {
                        textBox3.Text = "error making file!";
                    }
                }

            }
            else
            {
                MessageBox.Show("that file name already exist!", "notification");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(variables.filename);
        }

        private static void WriteToFile(string text)
        {
            //StreamWriter w = new StreamWriter(variables.filename);
            //w.WriteLine(text);
            //w.Close();
            //w.Dispose();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.AppendAllText(variables.filename, textBox3.Text + "\n");
           // WriteToFile(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            variables.filename = textBox3.Text + ".txt";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.Delete(textBox3.Text + ".txt");
        }

    }
}
