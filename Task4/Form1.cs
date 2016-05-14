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

namespace Week7_Sinusoid_Graph
{
    public partial class Form1 : Form
    {
        // Разные цвета для функций
        Pen p1 = new Pen(Color.Blue, 2);
        Pen p2 = new Pen(Color.Black, 2);
        Pen p3 = new Pen(Color.Chocolate, 2);
        Pen p4 = new Pen(Color.Green, 2);

        // Ручка для рисования GRID
        Pen p_dash = new Pen(Color.DarkGray, 1);


        Timer timer = new Timer();

        float dx;
        float coord_x;
        float coord_y1;
        float coord_y2;
        float coord_y3;
        float coord_y4;

        // to offset y on plane
        float offset_y;
        float offset_x;

        // multiplier to zoom
        float multiplier_x;
        float multiplier_y;

        public Bitmap bmp;
        Graphics gfx;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 5;
            timer.Tick += Draw;
            timer.Start();

            // Bitmap на основе pictureBox
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // К графике привязываем bitmap
            gfx = Graphics.FromImage(bmp);
            p_dash.DashStyle = DashStyle.Dot;

            dx = 0.04F;
            coord_x = -15.0F;
            coord_y1 = -coord_x;
            coord_y2 = -(float)Math.Sin(coord_x);
            coord_y3 = -(float)(coord_x + Math.Sin(coord_x));
            coord_y4 = -(float)(coord_x * Math.Sin(coord_x));

            offset_y = -180;
            offset_x = 310;

            multiplier_x = 20;
            multiplier_y = 40;


            // Координатная плоскость
            gfx.DrawLine(new Pen(Color.Red, 1), new Point() { X = 0, Y = 180 }, new Point() { X = this.Width, Y = 180});
            gfx.DrawLine(new Pen(Color.Red, 1), new Point() { X = 310, Y = 0 }, new Point() { X = 310, Y = this.Height });

            // Рисуем grid, где y / x = 2 не учитывается (не красиво)
            for (int i = 0; i < this.Height; i = i + 20)
            {
                gfx.DrawLine(p_dash, new Point() { X = 0, Y = i }, new Point() { X = this.Width, Y = i });
            }

            for (int i = 10; i < this.Width; i = i + 20)
            {

                gfx.DrawLine(p_dash, new Point() { X = i, Y = 0 }, new Point() { X = i, Y = this.Height });
            }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Draw(object sender, EventArgs e)
        {
            // рисуем пока Х не вышел за границы
            if (offset_x + multiplier_x * coord_x < this.Width)
            {
                // Put "negative" sign for y's, because coordinate system is inverted

                gfx.DrawLine(p1, new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * coord_y1) ), new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * (float)( coord_x + dx ) ) ) );
                gfx.DrawLine(p2, new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * coord_y2) ), new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * (float)( Math.Sin(coord_x + dx) ) ) ) );
                gfx.DrawLine(p3, new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * coord_y3) ), new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * (float)( coord_x + dx + Math.Sin(coord_x + dx) ) ) ) );
                gfx.DrawLine(p4, new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * coord_y4) ), new PointF( offset_x + multiplier_x * coord_x, -(offset_y + multiplier_y * (float)( (coord_x + dx) * Math.Sin(coord_x + dx) ) ) ) );

                // increment
                coord_x += dx;
                coord_y1 = (float)(coord_x);
                coord_y2 = (float)Math.Sin(coord_x);
                coord_y3 = (float)(coord_x + Math.Sin(coord_x));
                coord_y4 = (float)(coord_x * Math.Sin(coord_x));

                pictureBox1.Image = bmp;
                
            }
            else
            {
                timer.Stop();
            }
            
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}
