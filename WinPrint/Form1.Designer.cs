namespace WinPrint
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDR = new System.Windows.Forms.Button();
            this.btnDY = new System.Windows.Forms.Button();
            this.dgvPrint = new System.Windows.Forms.DataGridView();
            this.cboAll = new System.Windows.Forms.CheckBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnDYSZ = new System.Windows.Forms.Button();
            this.btnDYYL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDR
            // 
            this.btnDR.Location = new System.Drawing.Point(128, 25);
            this.btnDR.Name = "btnDR";
            this.btnDR.Size = new System.Drawing.Size(75, 23);
            this.btnDR.TabIndex = 0;
            this.btnDR.Text = "导入";
            this.btnDR.UseVisualStyleBackColor = true;
            this.btnDR.Click += new System.EventHandler(this.btnDR_Click);
            // 
            // btnDY
            // 
            this.btnDY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDY.Location = new System.Drawing.Point(612, 28);
            this.btnDY.Name = "btnDY";
            this.btnDY.Size = new System.Drawing.Size(75, 23);
            this.btnDY.TabIndex = 2;
            this.btnDY.Text = "打印";
            this.btnDY.UseVisualStyleBackColor = true;
            this.btnDY.Click += new System.EventHandler(this.btnDY_Click);
            // 
            // dgvPrint
            // 
            this.dgvPrint.AllowUserToAddRows = false;
            this.dgvPrint.AllowUserToDeleteRows = false;
            this.dgvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrint.Location = new System.Drawing.Point(12, 54);
            this.dgvPrint.Name = "dgvPrint";
            this.dgvPrint.RowHeadersVisible = false;
            this.dgvPrint.RowTemplate.Height = 23;
            this.dgvPrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrint.ShowEditingIcon = false;
            this.dgvPrint.Size = new System.Drawing.Size(675, 371);
            this.dgvPrint.TabIndex = 2;
            // 
            // cboAll
            // 
            this.cboAll.AutoSize = true;
            this.cboAll.Location = new System.Drawing.Point(60, 32);
            this.cboAll.Name = "cboAll";
            this.cboAll.Size = new System.Drawing.Size(48, 16);
            this.cboAll.TabIndex = 3;
            this.cboAll.Text = "全选";
            this.cboAll.UseVisualStyleBackColor = true;
            this.cboAll.CheckedChanged += new System.EventHandler(this.cboAll_CheckedChanged);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnDYSZ
            // 
            this.btnDYSZ.Location = new System.Drawing.Point(219, 25);
            this.btnDYSZ.Name = "btnDYSZ";
            this.btnDYSZ.Size = new System.Drawing.Size(75, 23);
            this.btnDYSZ.TabIndex = 4;
            this.btnDYSZ.Text = "打印设置";
            this.btnDYSZ.UseVisualStyleBackColor = true;
            this.btnDYSZ.Visible = false;
            this.btnDYSZ.Click += new System.EventHandler(this.btnDYSZ_Click);
            // 
            // btnDYYL
            // 
            this.btnDYYL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDYYL.Location = new System.Drawing.Point(531, 28);
            this.btnDYYL.Name = "btnDYYL";
            this.btnDYYL.Size = new System.Drawing.Size(75, 23);
            this.btnDYYL.TabIndex = 1;
            this.btnDYYL.Text = "打印预览";
            this.btnDYYL.UseVisualStyleBackColor = true;
            this.btnDYYL.Click += new System.EventHandler(this.btnDYYL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 437);
            this.Controls.Add(this.btnDYYL);
            this.Controls.Add(this.btnDYSZ);
            this.Controls.Add(this.cboAll);
            this.Controls.Add(this.dgvPrint);
            this.Controls.Add(this.btnDY);
            this.Controls.Add(this.btnDR);
            this.Name = "Form1";
            this.Text = "打印小工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDR;
        private System.Windows.Forms.Button btnDY;
        private System.Windows.Forms.DataGridView dgvPrint;
        private System.Windows.Forms.CheckBox cboAll;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnDYSZ;
        private System.Windows.Forms.Button btnDYYL;
    }
}

