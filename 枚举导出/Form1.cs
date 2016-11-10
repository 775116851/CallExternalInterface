using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 枚举导出
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
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("导出快递");
            DataTable dt = AppEnum.GetEnumKeyName(typeof(AppEnum.ExpressCompany));
            IRow row00 = sheet.CreateRow(0);
            ICell cell00 = row00.CreateCell(0);
            ICell cell01 = row00.CreateCell(1);
            cell00.SetCellValue("快递公司中文名称");
            cell01.SetCellValue("快递公司英文名称");
            for(int i = 0; i < dt.Rows.Count ;i++)
            {
                DataRow dr = dt.Rows[i];
                IRow row = sheet.CreateRow(i + 1);
                ICell cell0 = row.CreateCell(0);
                ICell cell1 = row.CreateCell(1);
                cell0.SetCellValue(Convert.ToString(dr["text"]));
                cell1.SetCellValue(Convert.ToString(dr["value"]));
            }

            using (FileStream stream = new FileStream(@"快递导出文件.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
            MessageBox.Show("导出成功！！");
        }
    }
}
