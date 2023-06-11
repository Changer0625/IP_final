using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DIP
{
    public partial class DIPSample : Form
    {
        int rgb_or_gray;
        public BrightnessContrast BC;
        public histogram hg;
        public DIPSample()
        {
            InitializeComponent();
            BC = new BrightnessContrast();
            BC.Sending += Sending;
            hg = new histogram();
            hg.Sending += Sending;
        }
        
        [DllImport("../../../../Debug/dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void encode(int *f0,int w,int h,int *g0);
        [DllImport("../../../../Debug/dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void encode1(int* f0, int w, int h, int* g0);
        
        Bitmap NpBitmap;
        int w, h, c;
        private void DIPSample_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
			this.stStripLabel.Text = "";
        }
        private void Sending(Bitmap img)
        {
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = img;
            childForm.Show();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oFileDlg.CheckFileExists = true;
            oFileDlg.CheckPathExists = true;
            oFileDlg.Title = "Open File - DIP Sample";
            oFileDlg.ValidateNames = true;
            oFileDlg.Filter = "bmp files (*.bmp)|*.bmp";
            oFileDlg.FileName = "";

            if (oFileDlg.ShowDialog() == DialogResult.OK)
            {
                MSForm childForm = new MSForm();
                childForm.MdiParent = this;
                childForm.pf1 = stStripLabel;
                NpBitmap = bmp_read(oFileDlg);
                childForm.pBitmap = NpBitmap;
                w = NpBitmap.Width;
                h = NpBitmap.Height;
                childForm.Show();
            }
        }

        private Bitmap bmp_read(OpenFileDialog oFileDlg)
        {
            Bitmap pBitmap;
            string fileloc = oFileDlg.FileName;
            pBitmap = new Bitmap(fileloc);
            w = pBitmap.Width;
            h = pBitmap.Height;
            return pBitmap;
        }

        private int[] bmp2array(Bitmap myBitmap, ref int ByteDepth, ref PixelFormat pixelFormat, ref ColorPalette palette) //grayscale
        {
                BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),
                                               ImageLockMode.ReadWrite,
                                               myBitmap.PixelFormat);
                pixelFormat = myBitmap.PixelFormat;
                palette = myBitmap.Palette;
                ByteDepth = (int)(byteArray.Stride / myBitmap.Width);
                int[] ImgData = new int[myBitmap.Width * myBitmap.Height * ByteDepth];
                int ByteOfSkip = byteArray.Stride - byteArray.Width * ByteDepth;
                if(ByteDepth==1)
                {
                    rgb_or_gray = 0;
                }
                else if(ByteDepth==3)
                {
                    rgb_or_gray = 1;
                }
                unsafe
                {
                    byte* imgPtr = (byte*)(byteArray.Scan0);
                    for (int y = 0; y < byteArray.Height; y++)
                    {
                        for (int x = 0; x < byteArray.Width; x++)
                        {
                            for (int c = 0; c < ByteDepth; c++)
                            {
                                ImgData[(x + byteArray.Height * y) * ByteDepth + c] = (int)*(imgPtr);
                                imgPtr += (int)(byteArray.Stride / myBitmap.Width) / ByteDepth;
                            }
                        }
                        imgPtr += ByteOfSkip;
                    }
                }
                myBitmap.UnlockBits(byteArray);
                return ImgData;
        }

        private static Bitmap array2bmp(int[] ImgData, int ByteDepth, PixelFormat pixelFormat, ColorPalette palette)
        {
            int Width = (int)Math.Sqrt(ImgData.GetLength(0) / ByteDepth);
            int Height = (int)Math.Sqrt(ImgData.GetLength(0) / ByteDepth);
            Bitmap myBitmap = new Bitmap(Width, Height, pixelFormat);
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, Width, Height),
                                           ImageLockMode.WriteOnly,
                                           pixelFormat);
            try
            {
                myBitmap.Palette = palette;
            }
            catch
            {

            }
            //Padding bytes的長度
            int ByteOfSkip = byteArray.Stride - myBitmap.Width * ByteDepth;
            unsafe
            {                                   // 指標取出影像資料
                byte* imgPtr = (byte*)byteArray.Scan0;
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        for (int c = 0; c < ByteDepth; c++)
                        {
                            *imgPtr = (byte)ImgData[(x + Height * y) * ByteDepth + c];       //B
                            imgPtr += 1;
                        }
                    }
                    imgPtr += ByteOfSkip; // 跳過Padding bytes
                }
            }
            myBitmap.UnlockBits(byteArray);
            return myBitmap;
        }

        private void bitPlaneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void b0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k]%2)*255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] / 2 % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] / 4 % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] / 8  % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] / 16 % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] /32 % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] /64 % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void b7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    c = ByteDepth;
                    g = new int[w * h * c];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            int i, j, k = 0;
                            for (j = 0; j < h; j++)
                            {
                                for (i = 0; i < c * w; i++)
                                {
                                    g0[k] = (f0[k] /128 % 2) * 255;
                                    k++;
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }


        private void rGBtoGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    g = new int[3 * w * h]; //RGB
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            for (int i = 0; i < w * h * 3; i += 3)
                            {
                                double gray = f0[i] * 0.299 + f0[i + 1] * 0.587 + f0[i + 2] * 0.114;
                                g[i] = Convert.ToInt16(gray);
                                g[i + 1] = Convert.ToInt16(gray);
                                g[i + 2] = Convert.ToInt16(gray);
                            }
                            //rgb2gray(f0, w, h, g0);
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = new Bitmap(NpBitmap);
            childForm.Show();
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BC.IsDisposed)
            {
                BC = new BrightnessContrast();
                BC.Sending += Sending;
                BC.MdiParent = this;
                BC.pictureBox1.Image = NpBitmap;
                BC.Show();
            }
            else
            {
                BC.pictureBox1.Image = NpBitmap;
                BC.MdiParent = this;
                BC.Show();
            }
        }
        
        private void stStripLabel_Click(object sender, EventArgs e)
        {

        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hg.IsDisposed)
            {
                hg = new histogram();
                hg.Sending += Sending;
                hg.MdiParent = this;
                hg.pictureBox1.Image = NpBitmap;
                hg.Show();
            }
            else
            {
                hg.pictureBox1.Image = NpBitmap;
                hg.MdiParent = this;
                hg.Show();
            }
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;

            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    int ByteDepth = 0;
                    PixelFormat pixelFormat = new PixelFormat();
                    ColorPalette palette = null;
                    f = bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette);
                    g = new int[(1+rgb_or_gray*2) * w * h];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            for (int i = 0; i < w * h * (1 + rgb_or_gray * 2); i += (1 + rgb_or_gray * 2))
                            {
                                g[i] = Math.Abs(255 - f0[i]);
                                if(rgb_or_gray==1)
                                {
                                    g[i + 1] = Math.Abs(255 - f0[i + 1]);
                                    g[i + 2] = Math.Abs(255 - f0[i + 2]);
                                }
                            }
                        }
                    }
                    NpBitmap = array2bmp(g, ByteDepth, pixelFormat, palette);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = new Bitmap(NpBitmap);
            childForm.Show();
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
