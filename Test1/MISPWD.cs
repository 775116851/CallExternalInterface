using allinpay.O2O.Cmn;
//using CommonLayer.Cmn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class MISPWD : Form
    {
        public MISPWD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtP2.Text = Util.GetMD5(txtP1.Text.Trim());
        }
    }
}
