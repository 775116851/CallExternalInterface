using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedisTest
{
    public partial class Form1 : Form
    {
        RedisClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new RedisClient("127.0.0.1", 6379);
        }
        //字符串
        private void button1_Click(object sender, EventArgs e)
        {
            client.Set<string>("FA", "123");
            string sFA = client.Get<string>("FA");
            MessageBox.Show(sFA);
        }

        //哈希
        private void button2_Click(object sender, EventArgs e)
        {
            client.SetEntryInHash("FBB", "FB", "234");
            List<string> FBB_Keys = client.GetHashKeys("FBB");
            List<string> FBB_Values = client.GetHashValues("FBB");
            MessageBox.Show(FBB_Keys[0] + "__" + FBB_Values[0]);
        }

        //队列
        private void button3_Click(object sender, EventArgs e)
        {
            client.EnqueueItemOnList("FC", "张三");//入队
            client.EnqueueItemOnList("FC", "历史");
            int length = client.GetListCount("FC");
            for (int i = 0; i < length;i++ )
            {
                MessageBox.Show(client.DequeueItemFromList("FC"));//出队
            }
        }

        //栈
        private void button4_Click(object sender, EventArgs e)
        {
            client.PushItemToList("FD", "VVC");//入栈
            client.PushItemToList("FD", "SD");
            int length = client.GetListCount("FD");
            for (int i = 0; i < length;i++ )
            {
                MessageBox.Show(client.PopItemFromList("FD"));
            }
        }
    }
}
