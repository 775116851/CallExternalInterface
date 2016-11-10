using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace ZXingTest
{
    public partial class Form1 : Form
    {
        BarcodeWriter bw = new BarcodeWriter();
        EncodingOptions eo = new EncodingOptions();
        BitMatrix bm = new BitMatrix(30, 30);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //eo.Width = 260;
            //eo.Height = 206;

            //bw.Format = BarcodeFormat.CODE_128;
            //bw.Options = eo;
            //bw.Renderer = 
            //Bitmap bitmap = bw.Write("1123");

            
            //pictureBox1.Image = bitmap;
        }
    }
}
