using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh.java.util;
using Tamir.SharpSsh.jsch;

namespace SFTP
{
    public class SFTPHelper
    {
        private Session m_session;
        private Channel m_channel;
        private ChannelSftp m_sftp;

        //host:sftp地址   user：用户名   pwd：密码        
        public SFTPHelper(string host, string user, string pwd)
        {
            string[] arr = host.Split(':');
            string ip = arr[0];
            int port = 22;
            if (arr.Length > 1) port = Int32.Parse(arr[1]);



            JSch jsch = new JSch();
            m_session = jsch.getSession(user, ip, port);
            MyUserInfo ui = new MyUserInfo();
            ui.setPassword(pwd);

            m_session.setUserInfo(ui);

        }

        //SFTP连接状态        
        public bool Connected { get { return m_session.isConnected(); } }

        //连接SFTP        
        public bool Connect()
        {
            try
            {
                if (!Connected)
                {
                    m_session.connect();
                    m_channel = m_session.openChannel("sftp");
                    m_channel.connect();
                    m_sftp = (ChannelSftp)m_channel;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //断开SFTP        
        public void Disconnect()
        {
            if (Connected)
            {
                m_channel.disconnect();
                m_session.disconnect();
            }
        }

        //SFTP存放文件        
        public bool Put(string localPath, string remotePath)
        {
            try
            {
                Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(localPath);
                Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(remotePath);
                m_sftp.put(src, dst);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //SFTP获取文件        
        public bool Get(string remotePath, string localPath)
        {
            try
            {
                Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(remotePath);
                Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(localPath);
                m_sftp.get(src, dst);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //删除SFTP文件
        public bool Delete(string remoteFile)
        {
            try
            {
                m_sftp.rm(remoteFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //获取SFTP文件列表        
        public ArrayList GetFileList(string remotePath, string fileType)
        {
            try
            {
                Tamir.SharpSsh.java.util.Vector vvv = m_sftp.ls(remotePath);
                ArrayList objList = new ArrayList();
                foreach (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry qqq in vvv)
                {
                    string sss = qqq.getFilename();
                    if (sss.Length > (fileType.Length + 1) && fileType == sss.Substring(sss.Length - fileType.Length))
                    { objList.Add(sss); }
                    else { continue; }
                }

                return objList;
            }
            catch
            {
                return null;
            }
        }

        //登录验证信息        
        public class MyUserInfo : UserInfo
        {
            String passwd;
            public String getPassword() { return passwd; }
            public void setPassword(String passwd) { this.passwd = passwd; }

            public String getPassphrase() { return null; }
            public bool promptPassphrase(String message) { return true; }

            public bool promptPassword(String message) { return true; }
            public bool promptYesNo(String message) { return true; }
            public void showMessage(String message) { }
        }

        //创建目录
        public bool CreateDir(string dir)
        {
            bool isOK = true;
            try
            {
                Vector content = m_sftp.ls(dir);
                if (content == null)
                {
                    m_sftp.mkdir(dir);
                }
            }
            catch (SftpException e)
            {
                try
                {
                    string[] dirList = dir.Split('/');
                    string dirM = string.Empty;
                    for (int i = 0; i < dirList.Length; i++)
                    {
                        string sFileName = dirList[i];
                        if (string.IsNullOrEmpty(sFileName))
                        {
                            continue;
                        }
                        if (i == 0 || string.IsNullOrEmpty(dirM))
                        {
                            dirM = dirList[i];
                        }
                        else
                        {
                            dirM = dirM + "/" + dirList[i];
                        }
                        CreateFolder(dirM);
                    }
                }
                catch (Exception ee)
                {
                    isOK = false;
                }
            }
            return isOK;
        }

        public void CreateFolder(string dirM)
        {
            try
            {
                Vector content = m_sftp.ls(dirM);
                if (content == null)
                {
                    m_sftp.mkdir(dirM);
                }
            }
            catch (SftpException e)
            {
                m_sftp.mkdir(dirM);
            }
        }

        //删除目录
        public bool DeleteDir(string dir)
        {
            bool isOK = true;
            try
            {
                Vector content = m_sftp.ls(dir);
                if (content != null)
                {
                    m_sftp.rm(dir);
                }
            }
            catch (Exception ex)
            {
                isOK = false;
            }
            return isOK;
        }
    }
}
