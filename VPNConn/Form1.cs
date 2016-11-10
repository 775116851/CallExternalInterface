using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VPNConn
{
    public partial class Form1 : Form
    {
        VPNHelper vpns = new VPNHelper();
        public Form1()
        {
            InitializeComponent();

            vpns.IPToPing = "104.237.156.248";
            vpns.VPNName = "VPN连接";
            vpns.UserName = "www.i-vpn.net";
            vpns.PassWord = "JGz6PsQ4";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vpns.CreateOrUpdateVPN();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vpns.TryConnectVPN();
        }
    }
}
