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
            if (!Directory.Exists("textfiles"))
            {
                Directory.CreateDirectory("textfiles");
                textBox4.Text = "created textfiles folder...";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text, textBox2.Text);
            textBox4.Text = "created message box!";
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
                textBox4.Text = "name cannot be empty or whitespace!";
            }
            else
            {
                variables.filename = textBox3.Text + ".txt";
                if (!File.Exists("textfiles\\" + variables.filename))
                {
                    try
                    {
                        StreamWriter w = new StreamWriter("textfiles\\" + variables.filename);
                        textBox4.Text = "created " + variables.filename;
                        w.Close();
                       // File.Create(variables.filename);
                       // File.CreateText(variables.filename);
                    }
                    catch
                    {
                        textBox4.Text = "error making file!";
                    }


                }
                else
                {
                    textBox4.Text = variables.filename + " already exist!";
                    //MessageBox.Show("that file name already exist!", "notification");
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
                Process.Start("textfiles\\" + variables.filename);
                textBox4.Text = "opening " + "textfiles\\" + variables.filename;
            }
            catch
            {
                textBox4.Text = "a error as occured!";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                File.AppendAllText("textfiles\\" + variables.filename, DateTime.Now + ": " + textBox3.Text + "\n");
                textBox4.Text = "text added!";
            }
            catch
            {
                textBox4.Text = "an error as occured!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            variables.filename = textBox3.Text + ".txt";
            textBox4.Text = "set " + variables.filename + " as the current txt file!";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists("textfiles\\" + textBox3.Text + ".txt"))
            {
                File.Delete("textfiles\\" + textBox3.Text + ".txt");
                textBox4.Text = variables.dir + textBox3.Text + ".txt" + " Deleted!";
                //textBox4.Text = variables.filename + textBox3.Text + " Deleted!";
            }
            else
            {
                textBox4.Text ="the file textfiles\\" + textBox3.Text + " does not exist!";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("textfiles");
            textBox4.Text = "opened textfiles folder!";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("feeneekiin! feeneeeekiiiinnn!", "fennekin!");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "+")
            {
                int awnser = 0;
                try
                {
                    awnser = int.Parse(textBox5.Text) + int.Parse(textBox6.Text);
                    textBox7.Text = awnser.ToString();
                }
                catch
                {
                    textBox7.Text = "a error has occured!";
                }
            }
            else if ((string)comboBox1.SelectedItem == "-")
            {
                int awnser = 0;
                try
                {
                    awnser = int.Parse(textBox5.Text) - int.Parse(textBox6.Text);
                    textBox7.Text = awnser.ToString();
                }
                catch
                {
                    textBox7.Text = "a error has occured!";
                }
            }
            else if ((string)comboBox1.SelectedItem == "*")
            {
                int awnser = 0;
                try
                {
                    awnser = int.Parse(textBox5.Text) * int.Parse(textBox6.Text);
                    textBox7.Text = awnser.ToString();
                }
                catch
                {
                    textBox7.Text = "a error has occured!";
                }
            }
            else if ((string)comboBox1.SelectedItem == "/")
            {
                int awnser = 0;
                try
                {
                    awnser = int.Parse(textBox5.Text) / int.Parse(textBox6.Text);
                    textBox7.Text = awnser.ToString();
                }
                catch
                {
                    textBox7.Text = "a error has occured!";
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(File.Exists(variables.dir + variables.filename))
            {
                try
                {
                    File.Delete(variables.dir + variables.filename);
                    textBox4.Text = variables.dir + variables.filename + " has been deleted!";
                }
                catch
                {
                    textBox4.Text = "Failed to delete " + variables.dir + variables.filename + "!";
                }
            }
            else
            {
                textBox4.Text = "the file '"+ variables.dir + variables.filename + "' does not exist!";
            }
        }


    }
}
