using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemcachedInfo
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            Show(10000, 32);
            Show2(211138, 1);
            Show3(100000, 1);
        }

        public double Show(double newPrice,int fCount)
        {
            newPrice = newPrice * 0.1 + newPrice;
            listBox1.Items.Add(newPrice);
            fCount--;
            if(fCount <= 0)
            {
                MessageBox.Show("结束了。。。");
                return 0;
            }
            return Show(newPrice, fCount);
        }

        public double Show2(double newPrice,int fCount)
        {
            newPrice = newPrice * 0.9;
            listBox1.Items.Add(newPrice);
            fCount++;
            if(newPrice <= 10000)
            {
                MessageBox.Show("结束了。。。" + fCount + "次数");
                return 0;
            }
            return Show2(newPrice, fCount);
        }

        public double Show3(double newPrice,int fCount)
        {
            newPrice = newPrice * 0.9;
            listBox1.Items.Add(newPrice);
            fCount++;
            if (newPrice <= 1)
            {
                MessageBox.Show("结束了。。。" + fCount + "次数");
                return 0;
            }
            return Show3(newPrice, fCount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double newPrice = Convert.ToDouble(txtYJE.Text.Trim());
            Ts(newPrice, 0);
        }

        public double Ts(double newPrice, int fCount)
        {
            double endPrice = Convert.ToDouble(txtZJE.Text.Trim());
            if (newPrice > endPrice)
            {
                newPrice = newPrice * 0.9;
                listBox1.Items.Add(newPrice);
                fCount++;
                if (newPrice <= endPrice)
                {
                    MessageBox.Show("结束了。。。" + fCount + "次数");
                    return 0;
                }
                return Ts(newPrice, fCount);
            }
            else
            {
                newPrice = newPrice * 0.1 + newPrice;
                listBox1.Items.Add(newPrice);
                fCount++;
                if (newPrice >= endPrice)
                {
                    MessageBox.Show("结束了。。。" + fCount + "次数");
                    return 0;
                }
                return Ts(newPrice, fCount);
            }
        }
    }
}
