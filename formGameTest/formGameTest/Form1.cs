using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace formGameTest
{
    public partial class Form1 : Form
    {
        static var v = new var();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Arial", (float)10, FontStyle.Bold);
            SolidBrush br = v.returnBrush(Color.Red);
            Rectangle rec = v.makeRectangle(20, 20, 40, 40);
            Graphics graphic = this.CreateGraphics();
            e.Graphics.FillRectangle(br, rec);
            string xy = "X: " + rec.X.ToString() + "/ Y: " + rec.Y.ToString();
            while(rec.X < 540)
            {
                xy = "X: " + rec.X.ToString() + "/ Y: " + rec.Y.ToString();
                rec.X += 5;
                e.Graphics.DrawString(xy, font, br, new PointF(0, 0));
                e.Graphics.FillRectangle(br, rec);
                Thread.Sleep(30);
                graphic.Clear(Form.DefaultBackColor);
            }
        }
    }
}
