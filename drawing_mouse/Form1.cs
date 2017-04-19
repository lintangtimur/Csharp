using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawing_mouse
{
    /*
     * Source : http://www.c-sharpcorner.com/forums/drawing-line-using-mouse-movement-event
     * Edited : stelin
     * 19 April 2017
     */
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private Graphics g;
        private Pen p;
        private int prevX;
        private int prevY;

        private bool isDrawing = false;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            prevX = e.X;
            prevY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            Random rnd = new Random();

            //Membuat random color berdasarkan RGB
            p = new Pen(Color.FromArgb(rnd.Next(100), rnd.Next(256), rnd.Next(256)), 6);
            if (isDrawing)
            {
                g.DrawLine(p, prevX, prevY, e.X, e.Y);
                prevX = e.X;
                prevY = e.Y;
                label1.Text = $"X: {e.X.ToString()}, Y: {e.Y.ToString()}";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }
    }
}
