using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnturnedModFixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string bypass = "Bypass_Hash_Verification";

        private void button1_Click(object sender, EventArgs e)
        {
           /* foreach (var file in Helper.GetAllFiles())
            {
                AppLogBox.Text += "\nFound file at " + file;

                //File
            } */

            Log("\ngetting files...");

            var files = Helper.GetAllFiles();

            Log(String.Format("\nFound {0} files!", files.Length));
            Log("\nAdding hash bypass text to files....");

            if (files.Length != 0)
            {
                Task Worker = Task.Run(() =>
                    {
                        string results;
                        string ProgMsg = "";
                        int count = 0;

                        foreach (var file in files)
                        {
                            var reader = File.OpenText(file);
                            results = reader.ReadToEnd();

                            if (isItem(results) && !results.Contains(bypass))
                            {
                                reader.Close();

                                //Log("\n" + file);

                                if (File.Exists(file))
                                {
                                    var writer = new StreamWriter(file);
                                    writer.Write(results);
                                    writer.WriteLine("\n");
                                    writer.WriteLine(bypass);
                                    writer.Close();

                                    try
                                    {
                                        if (count > 1)
                                        {
                                            AppLogBox.Text = AppLogBox.Text.Remove(73); 
                                        }
                                    }
                                    catch { }
                                }

                                Log("\n" + ProgMsg);
                                count++;
                                ProgMsg = string.Format("{0} / {1}", count, (int)files.Length*0.56);
                            }
                        }

                        Log("\nFixed " + count.ToString() + " Items!");
                    }); 
            }
        }

        bool isItem(string originalText)
        {
            if (originalText.Contains("Size_X") && originalText.Contains("Size_Y"))
                return true;
            else if (originalText.Contains("Fuel_Max"))
                return true;
            return false;
        }

        public void Log(string msg)
        {
            AppLogBox.Text += msg;
        }
    }
}
