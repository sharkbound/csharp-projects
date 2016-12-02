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
            //enableBasicDoubleBuffer();
            //enableDoubleBuffer();
        }

        string bypass = "Bypass_Hash_Verification";

        private void button1_Click(object sender, EventArgs e)
        {
            /* foreach (var file in Helper.GetAllFiles())
             {
                 AppLogBox.Text += "\nFound file at " + file;

                 //File
             } */

            ClearListBox();

            Log("\nGetting files...");

            var files = Helper.GetAllFiles();
            var validFiles = new Dictionary<string, string>();

            Log(String.Format("\nFound {0} total files!", files.Length));

            Task ReaderWorker = Task.Run(() =>
            {

                string results;
                string ProgMsg = "";
                int count = 0;
                int lastIndex = 0;

                foreach (var file in files)
                {
                    if (!File.Exists(file)) continue;

                    var reader = File.OpenText(file);
                    results = reader.ReadToEnd();
                    reader.Close();

                    if (isItem(results) && !results.Contains(bypass))
                    {
                        try
                        {
                            if (count > 1)
                            {
                                LogProgress(ProgMsg, lastIndex);
                            }
                            else
                            {
                                Log("\n" + ProgMsg, out lastIndex);
                            }
                        }
                        catch { }

                        count++;
                        ProgMsg = string.Format("\nChecking file {0} of {1}\n", count, files.Length);
                        validFiles.Add(file, results);
                    }
                }

                Log("");
                Log("\nFound " + validFiles.Count.ToString() + " Valid files!");
                Log("");
            });

            Task.WaitAll(ReaderWorker);
            Log("\nAdding hash bypass text to files....");

            if (validFiles.Count != 0)
            {
                Task WriterWorker = Task.Run(() =>
                    {
                        string ProgMsg = "";
                        int count = 0;
                        int lastIndex = 0;

                        foreach (var file in validFiles)
                        {
                            //var reader = File.OpenText(file.Key);
                            //results = reader.ReadToEnd();
                            //reader.Close();

                            //Log("\n" + file);

                            if (File.Exists(file.Key))
                            {
                                var writer = new StreamWriter(file.Key);
                                writer.Write(file.Value);
                                writer.WriteLine("\n");
                                writer.WriteLine(bypass);
                                writer.Close();

                                try
                                {
                                    if (count > 1)
                                    {
                                        //AppLogBox.Items.RemoveAt(lastIndex);
                                        LogProgress(ProgMsg, lastIndex);
                                    }
                                    else
                                    {
                                        Log("\n" + ProgMsg, out lastIndex);
                                    }
                                }
                                catch { }
                            }
                            count++;

                            //ProgMsg = string.Format("{0} / {1}", count, (int)files.Length*0.55);
                            ProgMsg = string.Format("\nWriting to file {0} of {1}", count, validFiles.Count);
                        }
                        Log("");
                        Log("\nFixed " + count.ToString() + " Items!");
                    });
            }
            else
            {
                Log("No files founds that are not already fixed!");
            }
        }

        private void UpdateColors()
        {
            AppLogBox.BackColor = Color.Black;
            AppLogBox.ForeColor = Color.Green;
        }

        bool isItem(string originalText)
        {
            if (originalText.Contains("Size_X") && originalText.Contains("Size_Y"))
                return true;
            else if (originalText.Contains("Fuel_Max"))
                return true;
            return false;
        }

        public void Log(string msg, out int index)
        {
            //AppLogBox.Text += msg;
            index = AppLogBox.Items.Add(msg);
        }

        public void Log(string msg)
        {
            //AppLogBox.Text += msg;
            AppLogBox.Items.Add(msg);
        }

        public void LogProgress(string msg, int lastMsgIndex)
        {
            //AppLogBox.Text += msg;
            AppLogBox.Items[lastMsgIndex] = msg;
        }

        void ClearListBox()
        {
            if (AppLogBox.Items.Count == 0) return;

            for (int listIndex = AppLogBox.Items.Count - 1; listIndex > 0; listIndex--)
            {
                AppLogBox.Items.RemoveAt(listIndex);
            }

            /*foreach (var item in AppLogBox.Items)
            {
                AppLogBox.Items.Remove(item);
            }*/
        }

        void enableDoubleBuffer()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }

        void enableBasicDoubleBuffer()
        {
            this.DoubleBuffered = true;
        }
    }

    internal class FlickerFreeListBox : System.Windows.Forms.ListBox
    {
        public FlickerFreeListBox()
        {
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(this.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
            }
            base.OnDrawItem(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Region iRegion = new Region(e.ClipRectangle);
            e.Graphics.FillRegion(new SolidBrush(this.BackColor), iRegion);
            if (this.Items.Count > 0)
            {
                for (int i = 0; i < this.Items.Count; ++i)
                {
                    System.Drawing.Rectangle irect = this.GetItemRectangle(i);
                    if (e.ClipRectangle.IntersectsWith(irect))
                    {
                        if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == i)
                        || (this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(i))
                        || (this.SelectionMode == SelectionMode.MultiExtended && this.SelectedIndices.Contains(i)))
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Selected, this.ForeColor,
                                this.BackColor));
                        }
                        else
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Default, this.ForeColor,
                                this.BackColor));
                        }
                        iRegion.Complement(irect);
                    }
                }
            }
            base.OnPaint(e);
        }
    } 
}
