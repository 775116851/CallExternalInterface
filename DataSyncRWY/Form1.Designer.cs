namespace DataSyncRWY
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
            this.button1 = new System.Windows.Forms.Button();
            this.QYDown = new System.Windows.Forms.Button();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.btnCS = new System.Windows.Forms.Button();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtJQMPLB = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.txtDYJQJBMLB = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(728, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QYDown
            // 
            this.QYDown.Location = new System.Drawing.Point(728, 55);
            this.QYDown.Name = "QYDown";
            this.QYDown.Size = new System.Drawing.Size(85, 23);
            this.QYDown.TabIndex = 1;
            this.QYDown.Text = "区域下载";
            this.QYDown.UseVisualStyleBackColor = true;
            this.QYDown.Click += new System.EventHandler(this.QYDown_Click);
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(12, 132);
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValues.Size = new System.Drawing.Size(604, 279);
            this.txtValues.TabIndex = 7;
            this.txtValues.DoubleClick += new System.EventHandler(this.txtValues_DoubleClick);
            // 
            // btnCS
            // 
            this.btnCS.Location = new System.Drawing.Point(728, 130);
            this.btnCS.Name = "btnCS";
            this.btnCS.Size = new System.Drawing.Size(85, 23);
            this.btnCS.TabIndex = 6;
            this.btnCS.Text = "测试";
            this.btnCS.UseVisualStyleBackColor = true;
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // txtParams
            // 
            this.txtParams.Location = new System.Drawing.Point(12, 12);
            this.txtParams.Multiline = true;
            this.txtParams.Name = "txtParams";
            this.txtParams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParams.Size = new System.Drawing.Size(710, 114);
            this.txtParams.TabIndex = 5;
            this.txtParams.Text = "{\"action\":\"GET_PROVINCE\"}";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(728, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "景区及其门票";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(728, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "景区图片";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(728, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "景区门票库存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(728, 271);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "景区列表接口";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(728, 300);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "景区门票列表接口";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtJQMPLB
            // 
            this.txtJQMPLB.Location = new System.Drawing.Point(622, 302);
            this.txtJQMPLB.Name = "txtJQMPLB";
            this.txtJQMPLB.Size = new System.Drawing.Size(100, 21);
            this.txtJQMPLB.TabIndex = 13;
            this.txtJQMPLB.Text = "300008";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(728, 329);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "单一景区及门票列表";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtDYJQJBMLB
            // 
            this.txtDYJQJBMLB.Location = new System.Drawing.Point(622, 331);
            this.txtDYJQJBMLB.Name = "txtDYJQJBMLB";
            this.txtDYJQJBMLB.Size = new System.Drawing.Size(100, 21);
            this.txtDYJQJBMLB.TabIndex = 15;
            this.txtDYJQJBMLB.Text = "300008";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(728, 388);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "下载数据";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(622, 388);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 17;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(622, 417);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 18;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(728, 84);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(85, 23);
            this.button11.TabIndex = 19;
            this.button11.Text = "Post提交";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 466);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.txtDYJQJBMLB);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtJQMPLB);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.btnCS);
            this.Controls.Add(this.txtParams);
            this.Controls.Add(this.QYDown);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button QYDown;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Button btnCS;
        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtJQMPLB;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtDYJQJBMLB;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

