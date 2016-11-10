namespace MemcachedInfo
{
    partial class Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtYJE = new System.Windows.Forms.TextBox();
            this.txtZJE = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 436);
            this.listBox1.TabIndex = 0;
            // 
            // txtYJE
            // 
            this.txtYJE.AccessibleDescription = "111";
            this.txtYJE.Location = new System.Drawing.Point(278, 12);
            this.txtYJE.Name = "txtYJE";
            this.txtYJE.Size = new System.Drawing.Size(100, 21);
            this.txtYJE.TabIndex = 1;
            this.txtYJE.Text = "10000";
            // 
            // txtZJE
            // 
            this.txtZJE.AccessibleDescription = "111";
            this.txtZJE.Location = new System.Drawing.Point(278, 55);
            this.txtZJE.Name = "txtZJE";
            this.txtZJE.Size = new System.Drawing.Size(100, 21);
            this.txtZJE.TabIndex = 2;
            this.txtZJE.Text = "1000000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 64);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtZJE);
            this.Controls.Add(this.txtYJE);
            this.Controls.Add(this.listBox1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtYJE;
        private System.Windows.Forms.TextBox txtZJE;
        private System.Windows.Forms.Button button1;
    }
}