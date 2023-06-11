using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace DIP
{
    public delegate void BG_send(Bitmap img);
    public partial class BrightnessContrast : Form
    {

        public BrightnessContrast()
        {
            InitializeComponent();

        }
        public event BG_send Sending;
        private void Brightness_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar1.Maximum = 255;
            trackBar1.Minimum = -255;
            label1.Text = "Brigthness : 0 ";
            pictureBox2.Image = pictureBox1.Image;
            trackBar2.Value = 0;
            trackBar2.Maximum = 255;
            trackBar2.Minimum = -255;
            label2.Text = "Contrast : 0 ";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Brigthness : "+trackBar1.Value.ToString();


            Bitmap bmp = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    int r = pixel.R + trackBar1.Value;
                    int g = pixel.G + trackBar1.Value;
                    int b = pixel.B + trackBar1.Value;

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = bmp;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Contrast : " + trackBar2.Value.ToString();
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    int r = pixel.R + (pixel.R - 127) * trackBar2.Value / 255;
                    int g = pixel.G + (pixel.G - 127) * trackBar2.Value / 255;
                    int b = pixel.B + (pixel.B - 127) * trackBar2.Value / 255;

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Sending(new Bitmap(pictureBox2.Image));
        }

    }
}
