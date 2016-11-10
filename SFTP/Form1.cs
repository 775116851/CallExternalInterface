using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh;

namespace SFTP
{
    public partial class Form1 : Form
    {
        SFTPHelper SFTP;
        public Form1()
        {
            InitializeComponent();
        }

        //连接SFTP
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                SFTP = new SFTPHelper(txtServer.Text, txtUser.Text, txtPwd.Text);
                if (!SFTP.Connect())
                {
                    MessageBox.Show("connect fail");
                }
                else
                {
                    MessageBox.Show("connect ok");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //关闭SFTP
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (SFTP != null)
                {
                    if (SFTP.Connected)
                    {
                        SFTP.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //选择上传文件
        private void btnSelFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //文件上传
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFile.Text.Trim() != string.Empty && SFTP.Connected)
                {
                    if (SFTP.Put(txtFile.Text, "/"))//SFTP.Put(txtFile.Text, "/") "/API360/MM.txt"
                    {
                        MessageBox.Show("upload ok");
                    }
                    else
                    {
                        MessageBox.Show("upload fail");
                    }
                }
                else
                {
                    MessageBox.Show("请先连接到服务器！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //文件下载
        private void btnGet_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(txtDownFile.Text.Trim()) && SFTP.Connected)
                    {
                        if (SFTP.Get(txtDownFile.Text.Trim(), sfd.FileName))
                        {
                            MessageBox.Show("down ok");
                        }
                        else
                        {
                            MessageBox.Show("down fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("服务未启动或未填写具体的下载文件！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //关闭窗口
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (SFTP != null)
                {
                    if (SFTP.Connected)
                    {
                        SFTP.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //创建目录
        private void button1_Click(object sender, EventArgs e)
        {
            #region 无用
            //SshShell ssh = new SshShell(txtServer.Text, txtUser.Text, txtPwd.Text);
            //ssh.Connect();
            //bool isCheck = ssh.Connected;
            //ssh.Expect("the initial server prompt");
            //ssh.WriteLine("ls -lart");
            //string sList = ssh.Expect("shell prompt");
            //ssh.Close();
            //MessageBox.Show(sList);
            //Sftp s = new Sftp(txtServer.Text, txtUser.Text, txtPwd.Text);
            //s.Connect();
            //ArrayList m = s.GetFileList("/");
            
            //WebClient wc = new WebClient();
            //wc.Credentials = new NetworkCredential(txtUser.Text, txtPwd.Text,txtServer.Text);
            //wc.UploadFile(txtUser.Text +@"\MFFQ.txt", @"c:\1.txt");
            //if (SFTP.Connected)
            //{
            //    bool isCheck = SFTP.Put("M", "/");
            //}
            //else
            //{
            //    MessageBox.Show("服务未启动或未填写具体的下载文件！");
            //}
            #endregion
            try
            {
                if (SFTP == null || !SFTP.Connected)
                {
                    btnConnect_Click(sender, e);
                }
                string strDir = txtDir.Text.TrimStart('/').TrimEnd('/');
                if (string.IsNullOrEmpty(strDir))
                {
                    MessageBox.Show("路径不能为空！");
                    return;
                }
                SFTP.CreateDir(strDir);
                MessageBox.Show(strDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //删除目录
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (SFTP == null || !SFTP.Connected)
                {
                    btnConnect_Click(sender, e);
                }
                string strDelDir = txtDeleteDir.Text.TrimStart('/').TrimEnd('/');
                if (string.IsNullOrEmpty(strDelDir))
                {
                    MessageBox.Show("路径不能为空！");
                    return;
                }
                bool isOK = SFTP.DeleteDir(strDelDir);
                MessageBox.Show(strDelDir + "_" + isOK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
