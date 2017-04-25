using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using Emgu.CV;

namespace CvWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static VideoCapture Video = new VideoCapture(0);

        private void Form1_Load(object sender, EventArgs e)
        {
            ScreenShotTimer.Tick += ScreenShotTimer_Tick;
            ScreenShotTimer.Start();
        }

        private void ScreenShotTimer_Tick(object sender, EventArgs e)
        {
            Mat frame = Video.QueryFrame();
            //Emgu.CV
            picRaw.Image = frame.Bitmap;
        }
    }
}
