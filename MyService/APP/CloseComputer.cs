using log4net;
using MyService.ebThread;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyService.APP
{
    public class CloseComputer : EBThread
    {
        private ILog _log = log4net.LogManager.GetLogger(typeof(CloseComputer));
        public override void run()
        {
            while (true)
            {
                try
                {
                    //System.Diagnostics.Process.Start("cmd.exe", "shutdown -f -s -t 10");
                    _log.Info("开始啦");
                    string sMessage = string.Empty;
                    int hour = DateTime.Now.Hour;
                    int minute = DateTime.Now.Minute;
                    if (hour >= 22)//22点之后不管了
                    {
                        Thread.Sleep(0);
                    }
                    else if(hour == 20 || hour == 21)//20:34
                    {
                        if (hour == 20)
                        {
                            //sleepTime = (60 - minute + 1) * 60 * 1000;
                            //Thread.Sleep(sleepTime);
                            sMessage = CmdPing(60 - minute + 1);//倒计时60秒
                            _log.Info(string.Format("倒计时{0}分钟,消息{1}", 60 - minute + 1, sMessage));
                        }
                        else
                        {
                            sMessage = CmdPing(1);
                            _log.Info(string.Format("倒计时{0}分钟,消息{1}", 1, sMessage));
                        }
                        Thread.Sleep(1000 * 30);//30秒后再执行
                    }
                    else //19:34
                    {
                        if (hour < 19)
                        {
                            Thread.Sleep(60 * 60 * 1000);//延迟一小时
                        }
                        else if (hour == 19)
                        {
                            if(minute <= 40)
                            {
                                Thread.Sleep(20 * 60 * 1000);//延迟20分钟
                            }
                        }
                        else
                        {
                            Thread.Sleep(5 * 60 * 1000);//延迟5分钟
                        }
                    }
                    
                    //Thread.Sleep(12000);
                }
                catch (Exception exx)
                {
                    _log.Error("关闭电脑出现异常："+ exx.Message);
                }
            }
        }

        
        private string CmdPing(int minute)
        {

            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            string pingrst;

            p.Start();

            minute = minute * 60;
            //p.StandardInput.WriteLine("ping -n 1 " + strIp);
            //p.StandardInput.WriteLine("net.exe", "use " + UploadFilePath + " " + FarDeskPwd + " /user:" + FarDeskUser);
            p.StandardInput.WriteLine("shutdown -s -f -t " + minute);

            p.StandardInput.WriteLine("exit");

            string strRst = p.StandardOutput.ReadToEnd();

            if (strRst.IndexOf("(0% loss)") != -1)

                pingrst = "连接";

            else if (strRst.IndexOf("Destination host unreachable.") != -1)

                pingrst = "无法到达目的主机";

            else if (strRst.IndexOf("Request timed out.") != -1)

                pingrst = "超时";

            else if (strRst.IndexOf("Unknown host") != -1)

                pingrst = "无法解析主机";

            else

                pingrst = strRst;

            p.Close();

            return pingrst;
        }
    }
}
