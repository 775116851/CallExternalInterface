using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using MyService.ebThread;
using System.IO;

namespace MyService.APP
{
    public class HTTX : EBThread
    {
        public override void run()
        {
            while (true)
            {
                try
                {
                    //WebClient wc = new WebClient();
                    //wc.Credentials = new NetworkCredential("uploadfile", "Up@11234156");
                    //byte[] m = wc.DownloadData(@"\\192.168.1.113\productpic\promotion_20140829.ok");
                    
                    //wc.DownloadFile(@"\\192.168.1.113\productpic\promotion_20140829.ok", AppDomain.CurrentDomain.BaseDirectory + "HTTXXML/20140907/promotion_20140829.ok");
                    //wc.DownloadFile(@"\\192.168.1.113\productpic\promotion_20140829.xml", AppDomain.CurrentDomain.BaseDirectory + "HTTXXML/20140907/promotion_20140829.xml");

                    FTPDownloadNew("uploadfile", "Up@11234156", @"ftp://192.168.1.113/tftp/promotion_20140829.ok", AppDomain.CurrentDomain.BaseDirectory + "HTTXXML/20140907/promotion_20140829.ok");
                    FTPDownloadNew("uploadfile", "Up@11234156", @"ftp://192.168.1.113/tftp/promotion_20140829.xml", AppDomain.CurrentDomain.BaseDirectory + "HTTXXML/20140907/promotion_20140829.xml");
                    Thread.Sleep(12000);
                }
                catch (Exception exx)
                {
                    
                }
            }
        }

        public static void FTPDownloadNew(string userName, string password, string downloadUrl, string localFile)
        {
            Stream responseStream = null;
            FileStream fileStream = null;
            StreamReader reader = null;

            try
            {
                FtpWebRequest downloadRequest =
                    (FtpWebRequest)WebRequest.Create(downloadUrl);

                if (string.IsNullOrEmpty(password))
                {
                    password = "-";
                }
                downloadRequest.Credentials = new NetworkCredential(userName, password);
                downloadRequest.Proxy = null;
                FtpWebResponse downloadResponse =
                    (FtpWebResponse)downloadRequest.GetResponse();
                responseStream = downloadResponse.GetResponseStream();

                fileStream = File.Create(localFile);
                byte[] buffer = new byte[1024];
                int bytesRead;
                while (true)
                {
                    bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
            catch (Exception)
            {
                throw;
                //LTEventsLogText.CreateInstance().WriteLog(ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                else if (responseStream != null)
                    responseStream.Close();
                if (fileStream != null)
                    fileStream.Close();
            }
        }
    }
}
