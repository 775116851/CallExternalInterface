namespace TestPPP
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
            this.txtX = new System.Windows.Forms.TextBox();
            this.btnJM = new System.Windows.Forms.Button();
            this.cboHY = new System.Windows.Forms.CheckBox();
            this.btnJMM = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(12, 12);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(293, 21);
            this.txtX.TabIndex = 0;
            this.txtX.Text = "9577C930E002DFE330CEFAFBA8DF82DE";
            // 
            // btnJM
            // 
            this.btnJM.Location = new System.Drawing.Point(374, 10);
            this.btnJM.Name = "btnJM";
            this.btnJM.Size = new System.Drawing.Size(75, 23);
            this.btnJM.TabIndex = 1;
            this.btnJM.Text = "加密";
            this.btnJM.UseVisualStyleBackColor = true;
            this.btnJM.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboHY
            // 
            this.cboHY.AutoSize = true;
            this.cboHY.Location = new System.Drawing.Point(320, 14);
            this.cboHY.Name = "cboHY";
            this.cboHY.Size = new System.Drawing.Size(48, 16);
            this.cboHY.TabIndex = 2;
            this.cboHY.Text = "会员";
            this.cboHY.UseVisualStyleBackColor = true;
            // 
            // btnJMM
            // 
            this.btnJMM.Location = new System.Drawing.Point(455, 10);
            this.btnJMM.Name = "btnJMM";
            this.btnJMM.Size = new System.Drawing.Size(75, 23);
            this.btnJMM.TabIndex = 3;
            this.btnJMM.Text = "解密";
            this.btnJMM.UseVisualStyleBackColor = true;
            this.btnJMM.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(12, 51);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(518, 21);
            this.txtY.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "13";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 154);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.btnJMM);
            this.Controls.Add(this.cboHY);
            this.Controls.Add(this.btnJM);
            this.Controls.Add(this.txtX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Button btnJM;
        private System.Windows.Forms.CheckBox cboHY;
        private System.Windows.Forms.Button btnJMM;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
    }
}

