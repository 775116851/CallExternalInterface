using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using ZXing.Common;
using ZXing;

namespace WinPrint
{
    public partial class Form1 : Form
    {
        List<ProductExport> list = new List<ProductExport>();
        EncodingOptions options = null;
        BarcodeWriter writer = null;  
        public Form1()
        {
            InitializeComponent();
            
            //MessageBox.Show(PrinterUnitConvert.Convert(870, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.Display).ToString());
            ////设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            //this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 86, 170);//Custum
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", PrinterUnitConvert.Convert(860, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.Display), PrinterUnitConvert.Convert(1700, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.Display));//Custum
            //this.printDocument2.DefaultPageSettings.PaperSize = new PaperSize("A4", 86, 170);
            //设置打印时横向还是纵向 
            this.printDocument1.DefaultPageSettings.Landscape = false;
            //获取或设置一个值，该值指示是否发送到文件或端口 
            //this.printDocument1.PrinterSettings.PrintToFile = true; 

            this.printDocument1.DefaultPageSettings.Margins.Left = 0;
            this.printDocument1.DefaultPageSettings.Margins.Right = 0;
            this.printDocument1.DefaultPageSettings.Margins.Top = 0;
            this.printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            //this.printDocument1.OriginAtMargins = true;//启用页边距
            this.pageSetupDialog1.EnableMetric = true; //以毫米为单位

            //条形码设置
            options = new EncodingOptions
            {
                Width = 120,
                Height = 52
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.ITF;
            writer.Options = options; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboAll.Visible = false;
        }

        //导入
        private void btnDR_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "表格文件 (*.xls)|*.xls";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Import(openFileDialog.FileName);
                cboAll.Checked = false;
            }
            cboAll.Visible = true;
        }

        public string Import(string fileName)
        {
            try
            {
                string oleDBConnString = String.Empty;
                oleDBConnString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties='Excel 8.0;'";//HDR=No;IMEX=1
                OleDbConnection oleDBConn = null;
                OleDbDataAdapter oleAdMaster = null;
                DataTable m_tableName = new DataTable();
                DataSet ds = new DataSet();
                oleDBConn = new OleDbConnection(oleDBConnString);
                oleDBConn.Open();
                m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (m_tableName != null && m_tableName.Rows.Count > 0)
                {
                    m_tableName.TableName = m_tableName.Rows[0]["TABLE_NAME"].ToString();
                }
                string sqlMaster;
                //sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "] WHERE F1 IS NOT NULL";
                sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "] ";
                oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
                oleAdMaster.Fill(ds, "m_tableName");
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();

                dgvPrint.Columns.Clear();
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.DataPropertyName = "全选";
                chkColumn.Name = "全选";
                chkColumn.HeaderText = "";
                chkColumn.ThreeState = false;
                dgvPrint.Columns.Add(chkColumn);

                dgvPrint.DataSource = ds.Tables[0];
                for (int i = 1; i < dgvPrint.Columns.Count; i++)
                {
                    dgvPrint.Columns[i].ReadOnly = true;
                    dgvPrint.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;//禁止排序
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入文件出现异常:" + ex.Message);
            }
            return "";
        }

        //打印
        private void btnDY_Click(object sender, EventArgs e)
        {
            if (CheckDataList() == false)
            {
                return;
            }
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        public bool CheckDataList()
        {
            bool isPass = false;
            list.Clear();
            m = 0;
            n = 1;
            if (dgvPrint.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPrint.Rows.Count; i++)
                {
                    DataGridViewCellCollection dvc = dgvPrint.Rows[i].Cells;
                    bool isCheck = Convert.ToBoolean(dvc[0].Value);
                    if (isCheck == true)
                    {
                        ProductExport pe = new ProductExport();
                        pe.SysNo = Convert.ToString(dvc[1].Value);
                        pe.ExportData = Convert.ToString(dvc[2].Value);
                        pe.ProductID = Convert.ToString(dvc[3].Value);
                        pe.VendorID = Convert.ToString(dvc[4].Value);
                        pe.ProductName = Convert.ToString(dvc[5].Value);
                        list.Add(pe);
                    }
                }
            }
            if (list.Count <= 0)
            {
                MessageBox.Show("请先选择要导出的数据");
                return false;
            }
            isPass = true;
            return isPass;
        }

        //全选
        private void cboAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvPrint.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPrint.Rows.Count; i++)
                {
                    dgvPrint.Rows[i].Cells[0].Value = cboAll.Checked;
                }
            }
        }

        //打印设置
        private void btnDYSZ_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog(); 
        }

        //打印预览
        private void btnDYYL_Click(object sender, EventArgs e)
        {
            if (CheckDataList() == false)
            {
                return;
            }
            this.printPreviewDialog1.ShowDialog(); 
        }

        int m = 0;//当前已遍历的商品下标
        int n = 1;//页数 每页取左右 共10条数据
        //打印详情
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (list == null || list.Count <= 0)
                {
                    e.Cancel = true;
                }
                int pageCount = 5;
                int listCount = 0;//剩余条数
                if (list.Count > n * 10)
                {
                    listCount = list.Count - (n - 1) * 10;//剩余条数
                    pageCount = 5;
                }
                else
                {
                    listCount = list.Count - (n - 1) * 10;//剩余条数
                    pageCount = listCount / 2 + listCount % 2;//循环次数
                }
                Font font1 = new Font("宋体", DWConver(3));   //设置字体类型和大小
                Font font2 = new Font("Code 128", 30, FontStyle.Regular, GraphicsUnit.World);//条形码IntHrP36DlTt  IntHrP72DlTt  C39HrP60DhTt
                //font2.FontFamily = new FontFamily(
                Brush brush = new SolidBrush(Color.Red);  //设置画刷颜色
                Pen pen = new Pen(Color.Red, 0.1f);  //创建画笔对象

                WinPrint.Code128 _Code = new WinPrint.Code128();//代码生成条形码方式
                _Code.ValueFont = new Font("宋体", 11);
                for (int i = 0; i < pageCount; i++)
                {
                    ProductExport peLeft = list[m];
                    //左 方框
                    //e.Graphics.DrawLine(pen, DWConver(2), DWConver((2 + 30 * i + 4 * i)), DWConver(42), DWConver((2 + 30 * i + 4 * i)));//上横
                    //e.Graphics.DrawLine(pen, DWConver(2), DWConver((2 + 30 * i + 4 * i)), DWConver(2), DWConver((2 + 30 * (i + 1) + 4 * i)));//左竖
                    //e.Graphics.DrawLine(pen, DWConver(42), DWConver((2 + 30 * i + 4 * i)), DWConver(42), DWConver((2 + 30 * (i + 1) + 4 * i)));//右竖
                    //e.Graphics.DrawLine(pen, DWConver(2), DWConver((2 + 30 * (i + 1) + 4 * i)), DWConver(42), DWConver((2 + 30 * (i + 1) + 4 * i)));//下横

                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;//商品名称 文本居中对其
                    Rectangle drawRectLeft = new Rectangle(DWConver(6), DWConver((2 + 30 * i + 4 * i + 2)), DWConver(34), DWConver(9));
                    e.Graphics.DrawString(peLeft.ProductName, font1, brush, drawRectLeft, sf);
                    //e.Graphics.DrawString(peLeft.ProductName, font1, brush, DWConver(5), DWConver((2 + 30 * i + 4 * i + 2)));
                    e.Graphics.DrawImage(writer.Write(peLeft.ProductID), DWConver(6), DWConver((2 + 30 * i + 4 * i + 13)));//第三方控件产生条形码
                    #region 字体和代码产生条形码
                    //e.Graphics.DrawString(GetCode128A(peLeft.ProductID), font2, brush, DWConver(5), DWConver((2 + 30 * i + 4 * i + 13)));//字体产生条形码
                    //Code128A:数字+大写字母+特殊字符 Code128B:数字+大小写字母+特殊字符 Code128C:双位数字
                    //if (i == 0)//图片压缩，不一定有效
                    //{
                    //    e.Graphics.DrawImage(GetSmall(_Code.GetCodeImage(peLeft.ProductID, WinPrint.Code128.Encode.Code128B), 1.4, 2), DWConver(9), DWConver((2 + 30 * i + 4 * i + 13)));//代码产生条形码
                    //}
                    //else
                    //{
                    //    e.Graphics.DrawImage(GetSmall(_Code.GetCodeImage(peLeft.ProductID, WinPrint.Code128.Encode.Code128B), 1.4, 1), DWConver(9), DWConver((2 + 30 * i + 4 * i + 13)));//代码产生条形码
                    //}
                    #endregion
                    //e.Graphics.DrawString(peLeft.ProductID, font1, brush, DWConver(14), DWConver((2 + 30 * i + 4 * i + 24)));
                    //判断是否还有数据 无数据翻页打印
                    if ((i + 1) == pageCount && (2 * (i + 1) - 1) == listCount)
                    {
                        e.HasMorePages = false;
                        break;
                    }
                    m++;
                    ProductExport peRight = list[m];
                    //右 方框
                    //e.Graphics.DrawLine(pen, DWConver(44), DWConver((2 + 30 * i + 4 * i)), DWConver(84), DWConver((2 + 30 * i + 4 * i)));//上横
                    //e.Graphics.DrawLine(pen, DWConver(44), DWConver((2 + 30 * i + 4 * i)), DWConver(44), DWConver((2 + 30 * (i + 1) + 4 * i)));//左竖
                    //e.Graphics.DrawLine(pen, DWConver(84), DWConver((2 + 30 * i + 4 * i)), DWConver(84), DWConver((2 + 30 * (i + 1) + 4 * i)));//右竖
                    //e.Graphics.DrawLine(pen, DWConver(44), DWConver((2 + 30 * (i + 1) + 4 * i)), DWConver(84), DWConver((2 + 30 * (i + 1) + 4 * i)));//下横

                    Rectangle drawRectRight = new Rectangle(DWConver(47), DWConver((2 + 30 * i + 4 * i + 2)), DWConver(34), DWConver(9));
                    e.Graphics.DrawString(peRight.ProductName, font1, brush, drawRectRight, sf);
                    //e.Graphics.DrawString(peRight.ProductName, font1, brush, DWConver(47), DWConver((2 + 30 * i + 4 * i + 2)));
                    //e.Graphics.DrawString(peRight.ProductID, font2, brush, DWConver(47), DWConver((2 + 30 * i + 4 * i + 13)));
                    e.Graphics.DrawImage(writer.Write(peRight.ProductID), DWConver(48), DWConver((2 + 30 * i + 4 * i + 13)));//第三方控件产生条形码
                    //e.Graphics.DrawString(peRight.ProductID, font1, brush, DWConver(56), DWConver((2 + 30 * i + 4 * i + 24)));
                    m++;
                }
                n++;
                listCount = list.Count - (n - 1) * 10;//剩余条数
                if (listCount > 0)//判断是否翻页打印 限定每页打印个数，超过即翻页打印
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                e.HasMorePages = false;//不在
                MessageBox.Show(string.Format("打印出现异常:{0} 异常详情:{1}",ex.Message,ex.ToString()));
            }

            #region 无用代码
            //for (int i = 0; i < 2;i++ )
            //{
            //    e.Graphics.DrawLine(pen, 2, 2, 42, 2);//上横
            //    e.Graphics.DrawLine(pen, 2, 2, 2, 32);//左竖
            //    e.Graphics.DrawLine(pen, 42, 2, 42, 32);//右竖
            //    e.Graphics.DrawLine(pen, 2, 32, 42, 32);//下横

            //    e.Graphics.DrawString("商品名称", font1, brush, 5, 4);
            //    e.Graphics.DrawString("1234567", font2, brush, 9, 12);
            //    e.Graphics.DrawString("商品编号", font1, brush, 14, 26);

            //    e.Graphics.DrawLine(pen, 44, 2, 84, 2);//上横
            //    e.Graphics.DrawLine(pen, 44, 2, 44, 32);//左竖
            //    e.Graphics.DrawLine(pen, 84, 2, 84, 32);//右竖
            //    e.Graphics.DrawLine(pen, 44, 32, 84, 32);//下横

            //    e.Graphics.DrawLine(pen, 2, 36, 42, 36);//上横
            //    e.Graphics.DrawLine(pen, 2, 36, 2, 66);//左竖
            //    e.Graphics.DrawLine(pen, 42, 36, 42, 66);//右竖
            //    e.Graphics.DrawLine(pen, 2, 66, 42, 66);//下横
            //    e.HasMorePages = true;
            //}
            //m++;
            //if(m > 2)
            //{
            //    e.HasMorePages = false;
            //}
            #endregion
        }

        //Code128 A型 支持数字+大写字母+特殊字符 (用于字体条形码生成)
        public string GetCode128A(string inputData)
        {
            string result = "";
            int checksum = 103;
            int j = 1;
            for (int ii = 0; ii < inputData.Length; ii++)
            {
                if (inputData[ii] >= 32)
                {
                    checksum += (inputData[ii] - 32) * (ii + 1);
                }
                else
                {
                    checksum += (inputData[ii] + 64) * (ii + 1);
                }
            }
            checksum = checksum % 103;
            if (checksum < 95)
            {
                checksum += 32;
            }
            else
            {
                checksum += 100;
            }
            result = Convert.ToChar(203) + inputData.ToString() + Convert.ToChar(checksum) + Convert.ToChar(206);
            return result;
        }

        //Code128 B型 支持数字+大小写字母+特殊字符 (用于字体条形码生成)
        public string GetCode128B(string inputData)
        {
            string result = "";
            int checksum = 104;
            int j = 1;
            for (int ii = 0; ii < inputData.Length; ii++)
            {
                if (inputData[ii] >= 32)
                {
                    checksum += (inputData[ii] - 32) * (ii + 1);
                }
                else
                {
                    checksum += (inputData[ii] + 64) * (ii + 1);
                }
            }
            checksum = checksum % 103;
            if (checksum < 95)
            {
                checksum += 32;
            }
            else
            {
                checksum += 100;
            }
            result = Convert.ToChar(204) + inputData.ToString() + Convert.ToChar(checksum) + Convert.ToChar(206);
            return result;
        }

        //Code128 C型 支持双位数字 (用于字体条形码生成)
        public string GetCode128C(string inputData)
        {
            string result = "";
            int checksum = 105;
            int j = 1;
            for (int ii = 0; ii < inputData.Length; ii++)
            {
                if (ii % 2 == 0)
                {
                    checksum += Convert.ToInt32(inputData.Substring(ii, 2)) * j;
                    if (Convert.ToInt32(inputData.Substring(ii, 2)) < 95)
                    {
                        result += Convert.ToChar(Convert.ToInt32(inputData.Substring(ii, 2)) + 32);
                    }
                    else
                    {
                        result += Convert.ToChar(Convert.ToInt32(inputData.Substring(ii, 2)) + 100);
                    }
                    j++;
                }
                ii++;
            }
            checksum = checksum % 103;
            if (checksum < 95)
            {
                checksum += 32;
            }
            else
            {
                checksum += 100;
            }
            result = Convert.ToChar(205) + result + Convert.ToChar(checksum) + Convert.ToChar(206);
            return result;
        }

        //单位转换 0.1mm -->0.01英寸 (传入毫米)
        public int DWConver(int mm)
        {
            mm = mm * 10;
            return PrinterUnitConvert.Convert(mm, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.Display);
        }

        //Bitmap 缩放
        private Bitmap GetSmall(Bitmap bm, double times,int type)
        {
            int nowWidth = (int)(bm.Width / times);
            int nowHeight = (int)(bm.Height / times);
            Bitmap newbm = new Bitmap(nowWidth, nowHeight);//新建一个放大后大小的图片

            if (times >= 1 && times <= 1.1)
            {
                newbm = bm;
            }
            else
            {
                Graphics g = Graphics.FromImage(newbm);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                if (type == 1)
                {
                    g.DrawImage(bm, new Rectangle(0, 0, nowWidth, nowHeight), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                }
                else
                {
                    g.DrawImage(bm, new Rectangle(0, 0, nowWidth, bm.Height), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                }
                g.Dispose();
            }
            return newbm;
        }

        //不使用
        private Bitmap GetImage(string p_Text)
        {
            Brush br = new SolidBrush(Color.Black);
            Pen p = new Pen(br, 1);
            Brush br1 = new SolidBrush(Color.White);
            Pen p1 = new Pen(br1, 1);
            Graphics graphics = CreateGraphics();
            //graphics.DrawLine(p,50,50,50,70);
            string inputString = p_Text.Trim();
            int x = 1;
            for (int i = 0; i < inputString.Length; i++)
            {
                for (int j = 0; j < Convert.ToInt32(inputString[i].ToString()); j++)
                {
                    if (i % 2 == 0)
                    {
                        //e.Graphics.DrawString("|", ft2, br, x, -3);
                        //graphics.DrawLine(p, x, 50, x, 80);
                        x = x + 1;
                    }
                    else
                    {
                        //e.Graphics.DrawString("|", ft2, br1, x, -3);
                        //graphics.DrawLine(p1, x, 50, x, 80);
                        x = x + 1;
                    }
                }
            }
            Bitmap _CodeImage = new Bitmap(x, 40);
            graphics = Graphics.FromImage(_CodeImage);
            int y = 1;
            for (int i = 0; i < inputString.Length; i++)
            {
                for (int j = 0; j < Convert.ToInt32(inputString[i].ToString()); j++)
                {
                    if (i % 2 == 0)
                    {
                        //e.Graphics.DrawString("|", ft2, br, x, -3);
                        graphics.DrawLine(p, y, 5, y, 18);
                        y = y + 1;
                    }
                    else
                    {
                        //e.Graphics.DrawString("|", ft2, br1, x, -3);
                        graphics.DrawLine(p1, y, 5, y, 18);
                        y = y + 1;
                    }
                }
            }
            return _CodeImage;
        }
    }

    public class ProductExport
    {
        public string SysNo;
        public string ExportData;
        public string ProductID;
        public string VendorID;
        public string ProductName;
    }
}
