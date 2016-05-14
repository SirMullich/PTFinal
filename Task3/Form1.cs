using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        Timer t;
        int angle;

        // Прямоугольник для FillPie
        Rectangle rect;
        // Для заливки FillPie
        SolidBrush brush;

        public Form1()
        {
            InitializeComponent();
            
            angle = 0;

            rect = new Rectangle(140, 20, 150, 150);

            brush = new SolidBrush(Color.DarkBlue);

            t = new Timer();

            t.Interval = 500;
            t.Tick += Draw;
        }

        private void Draw(object sender, EventArgs e)
        {
            if (angle + 18 <= 360)
            {
                // Угол увеличивается на 18, чтобы было 360 / 18 = 20 шагов
                angle += 18;
            }
            else
            {
                t.Stop();
            }

            progressBar1.PerformStep();
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Начальный угол 270 потому что 0 находится на оси Х
            e.Graphics.FillPie(brush, rect, 270, angle);
        }

        private void Start(object sender, EventArgs e)
        {
            t.Start();
        }
    }
}
