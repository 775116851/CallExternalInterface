using allinpay.O2O.Cmn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //加密
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text = EncryptText();
        }

        public string EncryptText()
        {
            string strList = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(strList))
            {
                MessageBox.Show("请输入要加密的串码！");
                return "";
            }
            string[] sList = strList.Split(new char[] { ',', '，', '、' });//.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sList.Length; i++)
            {
                string sStr = sList[i].Trim().TrimStart();
                if (!string.IsNullOrEmpty(sStr))
                {
                    sb.Append(CryptoUtil.EncryptTripleDES(sList[i].Trim().TrimStart())).Append(",");
                }
            }
            return sb.ToString();
        }

        //解密
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text = DecryptTriple();
        }

        public string DecryptTriple()
        {
            string strList = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(strList))
            {
                MessageBox.Show("请输入要解密的串码！");
                return "";
            }
            string[] sList = strList.Split(new char[] { ',', '，', '、' });
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sList.Length; i++)
            {
                string sStr = sList[i].Trim().TrimStart();
                if (!string.IsNullOrEmpty(sStr))
                {
                    sb.Append(CryptoUtil.DecryptTripleDES(sList[i].Trim())).Append(",");
                }
            }
            return sb.ToString();
        }

        //加密导出
        private void button3_Click(object sender, EventArgs e)
        {
            string path = "";
            SaveFileDialog opf = new SaveFileDialog();
            opf.Filter = "文本文件|*.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                path = opf.FileName;
                opf.Title = "加密导出";
                string sMessage = EncryptText();
                byte[] f = Encoding.UTF8.GetBytes(sMessage);
                FileStream fs = new FileStream(opf.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Write(f, 0, f.Length);
                fs.Close();
                fs.Dispose();
                MessageBox.Show("导出完成");
            }
            else
            {
                return;
            }
        }

        //解密导出
        private void button4_Click(object sender, EventArgs e)
        {
            string path = "";
            SaveFileDialog opf = new SaveFileDialog();
            opf.Filter = "文本文件|*.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                path = opf.FileName;
                opf.Title = "解密导出";
                string sMessage = DecryptTriple();
                byte[] f = Encoding.UTF8.GetBytes(sMessage);
                FileStream fs = new FileStream(opf.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Write(f, 0, f.Length);
                fs.Close();
                fs.Dispose();
                MessageBox.Show("导出完成");
            }
            else
            {
                return;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string A = textBox1.Text.Trim();
            string B = textBox2.Text.Trim();
            MessageBox.Show(string.Format("上面文本框个数:{0} 下面文本框个数:{1}", A.Split(new char[] { ',', '，', '、' }).Length, B.Split(new char[] { ',', '，', '、' }).Length));
        }

        //整理导出
        private void button6_Click(object sender, EventArgs e)
        {
            string strList = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(strList))
            {
                MessageBox.Show("请输入要加/解密的串码！");
                return ;
            }
            string[] sList = strList.Split(new char[] { ',', '，', '、' });//.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sList.Length; i++)
            {
                string sStr = sList[i].Trim().TrimStart();
                if (!string.IsNullOrEmpty(sStr))
                {
                    sb.Append(sList[i].Trim().TrimStart()).Append(",");
                }
            }

            string path = "";
            SaveFileDialog opf = new SaveFileDialog();
            opf.Filter = "文本文件|*.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                path = opf.FileName;
                opf.Title = "整理导出";
                string sMessage = sb.ToString();//EncryptText();
                byte[] f = Encoding.UTF8.GetBytes(sMessage);
                FileStream fs = new FileStream(opf.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Write(f, 0, f.Length);
                fs.Close();
                fs.Dispose();
                MessageBox.Show("整理导出完成");
            }
            else
            {
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strList = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(strList))
            {
                MessageBox.Show("请输入要加/解密的串码！");
                return;
            }
            string[] sList = strList.Split(new string[]{"/r/n","\r\n"},StringSplitOptions.RemoveEmptyEntries);//.Split(',');
            StringBuilder sbError = new StringBuilder();
            for (int i = 0; i < sList.Length; i++)
            {
                string[] keyValue = sList[i].Trim().TrimStart().Split('|');
                try
                {
                    
                    string sSQL = @"ALTER TABLE " + keyValue[0] + @" ADD OID INT ";
                    SqlHelper.ExecuteNonQuery(txtSQLConn.Text.Trim(), sSQL);    
                    sSQL = "UPDATE " + keyValue[0] + @" SET OID = " + keyValue[1] + @" 
                            ALTER TABLE " + keyValue[0] + @" DROP COLUMN " + keyValue[1] + @"
                            ALTER TABLE " + keyValue[0] + @" ADD " + keyValue[1] + @" INT IDENTITY(1,1) NOT NULL
                            ALTER TABLE " + keyValue[0] + @" ADD CONSTRAINT PK_" + keyValue[0] + " PRIMARY KEY (" + keyValue[1] + ")";
                    SqlHelper.ExecuteNonQuery(txtSQLConn.Text.Trim(), sSQL);    
                }
                catch (Exception ex)
                {
                    sbError.Append(string.Format("表名:{0} 列名:{1} 错误消息：{2}", keyValue[0], keyValue[1], ex.Message + "||||"));
                }

            }
            textBox2.Text = sbError.ToString();
            MessageBox.Show("完成");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
    }
}
