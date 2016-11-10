using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace 分布式事务
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionOptions options = new TransactionOptions();
                options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                options.Timeout = TransactionManager.DefaultTimeout;
                MessageBox.Show("F");
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
                {
                    string sSQLA = "UPDATE dbo.Area SET Status = '0' WHERE SysNo = '5'";
                    SqlHelper.ExecuteNonQuery(Convert.ToString(ConfigurationManager.ConnectionStrings["Conn_MIS2_WSTL"]), sSQLA);
                    MessageBox.Show("A");
                    string sSQLB = "UPDATE dbo.Bank SET Status = '0' WHERE SysNo = '5'";
                    SqlHelper.ExecuteNonQuery(Convert.ToString(ConfigurationManager.ConnectionStrings["Conn_PIM2"]), sSQLB);
                    MessageBox.Show("B");
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
