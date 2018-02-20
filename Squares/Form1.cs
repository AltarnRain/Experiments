using System;
using System.Drawing;
using System.Windows.Forms;

namespace Squares
{
    public partial class Form1 : Form
    {
        private Random random;
        private Graphics pgfx;

        public Form1()
        {
            InitializeComponent();

            this.random = new Random();
            this.pgfx = this.panel1.CreateGraphics();

            this.trackBar1_Scroll(null, null);
            this.trackBar2_Scroll(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void DrawSquares()
        {
            var bm = new Bitmap(this.panel1.Width, this.panel1.Height);
            var gfx = Graphics.FromImage(bm);

            gfx.FillRectangle(new SolidBrush(this.panel1.BackColor), new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));

            var numberOfSequares = int.Parse(this.textBox1.Text);

            for (int i = 0; i < numberOfSequares; i++)
            {
                var x = this.random.Next(this.panel1.Width);
                var y = this.random.Next(this.panel1.Height);

                var colorNr = this.random.Next(3);

                Color color = Color.Black;
                switch (colorNr)
                {
                    case 0:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Blue;
                        break;
                    case 2:
                        color = Color.Green;
                        break;
                }

                var size = this.random.Next(this.trackBar2.Value);                

                gfx.FillRectangle(new SolidBrush(color), new Rectangle(x, y, size, size));
            }

            var pgfx = this.panel1.CreateGraphics();
            pgfx.DrawImage(bm, new Point(0, 0));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.DrawSquares();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.timer1.Interval = this.trackBar1.Value;
            this.label1.Text = this.trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.label2.Text = this.trackBar2.Value.ToString();
        }
    }
}
