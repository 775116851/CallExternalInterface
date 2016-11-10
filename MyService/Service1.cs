using MyService.APP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer1.Enabled = false;
            //EventLog.WriteEntry("大爷启动了！");
            //PromotionProductXML ppXML = new PromotionProductXML();
            //ppXML.start();

            HTTX httx = new HTTX();
            httx.start();

            CloseComputer cc = new CloseComputer();
            cc.start();
        }
    }
}
