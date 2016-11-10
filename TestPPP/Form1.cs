using allinpay.O2O.Cmn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestPPP
{
    public partial class Form1 : Form
    {
        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        Thread t5;
        Thread t6;
        static List<char> total = new List<char>();
        //要解密的串
        string cx;
        //确定当前所有线程是否停止标记
        private bool _threadStop = false;
        //总查询次数
        double count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //加密
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtX.Text.Trim()))
            {
                MessageBox.Show("请先输入加密密码！");
                txtX.Focus();
                return;
            }
            string sPWD = string.Empty;
            if (cboHY.Checked)
            {
                sPWD = CommonFunctions.md5(CommonFunctions.md5(txtX.Text.Trim()) + AppConst.KEY_MD5_WEB); ;
            }
            else
            {
                sPWD = CommonFunctions.md5(txtX.Text.Trim() + AppConst.KEY_MD5_MIS);
            }
            txtY.Text = sPWD;
        }

        //解密
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtX.Text.Trim()))
            {
                MessageBox.Show("请先输入需解密串！");
                txtX.Focus();
                return;
            }
            char[] tos = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            total.Clear();
            total.AddRange(tos);
            //先固定六位
            bool isHY = false;
            if (cboHY.Checked)//会员
            {
                isHY = true;
            }
            cx = txtX.Text.Trim();
            //Show(true, 1);
            //t1 = new Thread(
            //TS tss = new TS();
            //tss.ts = t1;
            //tss.isHY = false;
            //tss.sType = 1;
            //ParameterizedThreadStart ParStart = new ParameterizedThreadStart(Show);
            //t1 = new Thread(ParStart);
            //t1.Start(tss);
            Control.CheckForIllegalCrossThreadCalls = false;
            t1 = new Thread(() => Show(false, 1, t1));
            t1.IsBackground = true;
            t1.Start();

            t2 = new Thread(() => Show(false, 2, t2));
            t2.IsBackground = true;
            t2.Start();

            t3 = new Thread(() => Show(false, 3, t3));
            t3.IsBackground = true;
            t3.Start();

            t4 = new Thread(() => Show(false, 4, t4));
            t4.IsBackground = true;
            t4.Start();

            t5 = new Thread(() => Show(false, 5, t5));
            t5.IsBackground = true;
            t5.Start();

            t6 = new Thread(() => Show(false, 6, t6));
            t6.IsBackground = true;
            t6.Start();

            //t2 = new Thread(new ThreadStart(kk));
            //t2.Start();
             
        }

        public void kk()
        {
            t2.Abort();
            int i = 0;
        }
        
        //1,2,3,4,5,6
        public void Show(bool isHY, int sType, Thread tsA)//(object tss)//
        {
            int CStart = 0;
            int CEnd = 0;
            int CBreak = 0;
            int M = total.Count / 6;//2
            int N = total.Count % 6;//0,1,2,3,4,5
            //int Nm = N / 3;//0,1
            //int Nn = N % 3;//0,1,2
            CStart = M * (sType - 1);
            CEnd = M * sType - 1;
            if(N >= 1)
            {
                CStart = CStart + (N >= sType - 1 ? sType - 1 : N);
                CEnd = CEnd + (N >= sType ? sType : N);
            }
            CBreak = CEnd + 1;
            for (int c1 = CStart; c1 < CEnd; c1++)
            {
                if (c1 == CBreak)//到达四分之一停止线程
                {
                    break;
                }
                for (int c2 = 0; c2 < total.Count; c2++)
                {
                    for (int c3 = 0; c3 < total.Count; c3++)
                    {
                        for (int c4 = 0; c4 < total.Count; c4++)
                        {
                            for (int c5 = 0; c5 < total.Count; c5++)
                            {
                                for (int c6 = 0; c6 < total.Count; c6++)
                                {
                                    //count++;
                                    //lblCount.Text = count + "次";
                                    //string str = "";
                                    //if (!string.IsNullOrEmpty(qz))
                                    //{
                                    //    str = qz + total[c1] + total[c2] + total[c3] + total[c4] + total[c5] + total[c6] + hz;
                                    //}
                                    //else
                                    //{
                                    //    str = total[c1] + keys + total[c2] + total[c3] + total[c4] + total[c5] + total[c6] + hz;
                                    //}
                                    //lblJG.Text = str;
                                    //ShowReturn(t6, str);
                                    label1.Text = count.ToString();
                                    string str = string.Empty;
                                    str = (total[c1] + "" + total[c2] + total[c3] + total[c4] + total[c5] + total[c6]).ToString();
                                    ShowReturn(tsA, str);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ShowReturn(Thread t,string str)
        {
            count++;
            if (_threadStop == true)
            {
                t.Abort();
                return;
            }
            if (cx == CommonFunctions.md5(str + AppConst.KEY_MD5_MIS))
            {
                _threadStop = true;
                txtY.Text = str;
                //t.Abort();
                MessageBox.Show("OK啦" + count);
            }
        }



        private int GetNum(int sType,ref int startNum,ref int endNum)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 6; i++)
            {
                int to1 = Convert.ToInt32(textBox1.Text.Trim());
                int M1 = to1 / 6;
                int N1 = to1 % 6;
                startNum = M1 * (i - 1);//i -->sType
                endNum = M1 * i - 1;
                if (N1 >= 1)
                {
                    endNum = endNum + (N1 >= i ? i : N1);
                    startNum = startNum + (N1 >= i-1?i-1:N1);
                    sb.Append(string.Format(" startNum:{0} endNum:{1} ", startNum, endNum));
                }
            }
            MessageBox.Show(sb.ToString());
            return 1;
            //int M = total.Length / 6;//2
            //int N = total.Length % 6;//0,1,2,3,4,5
            sType = Convert.ToInt32(textBox2.Text.Trim());
            int to = Convert.ToInt32(textBox1.Text.Trim());
            int M = to / 6;
            int N = to % 6;
            startNum = M * (sType - 1);
            endNum = M * sType - 1;
            if(N >= 1)
            {
                endNum = endNum + (N >= sType?sType:N);
            }
            MessageBox.Show(string.Format("startNum:{0} endNum:{1}",startNum,endNum));
            return 0;
            //1
            startNum = M * (sType - 1);
            endNum = M * sType - 1;
            if(N >= sType)
            {
                endNum = endNum + 1;
            }
            //2
            startNum = M * (sType - 1);
            endNum = M * sType - 1;
            if (N >= sType)
            {
                endNum = endNum + 2;
            }
            else if(N >= sType - 1)
            {
                endNum = endNum + 1;
            }
            if(N >= 1)
            {
                startNum = startNum + 1;
            }
            //3
            startNum = M * (sType - 1);
            endNum = M * sType - 1;
            if (N >= sType)
            {
                endNum = endNum + 3;
            }
            else if (N >= sType - 1)
            {
                endNum = endNum + 2;
            }
            else if (N >= sType - 2)
            {
                endNum = endNum + 1;
            }
            if (N >= 2)
            {
                startNum = startNum + 2;
            }
            if (N >= 1)
            {
                startNum = startNum + 1;
            }
            //4
            startNum = M * (sType - 1);
            endNum = M * sType - 1;
            if (N >= sType)
            {
                endNum = endNum + 4;
            }
            else if (N >= sType - 1)
            {
                endNum = endNum + 3;
            }
            else if (N >= sType - 2)
            {
                endNum = endNum + 2;
            }
            else if (N >= sType - 3)
            {
                endNum = endNum + 1;
            }
            if (N >= 3)
            {
                startNum = startNum + 3;
            }
            if (N >= 2)
            {
                startNum = startNum + 2;
            }
            if (N >= 1)
            {
                startNum = startNum + 1;
            }
            return 0;
        }
    }

    public class TS
    {
        public int sType;
        public bool isHY;
        public Thread ts;
    }
}
