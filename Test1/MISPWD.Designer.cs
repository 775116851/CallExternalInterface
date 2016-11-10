namespace Test1
{
    partial class MISPWD
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
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(12, 12);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(255, 21);
            this.txtP1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(354, 12);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(337, 21);
            this.txtP2.TabIndex = 2;
            // 
            // MISPWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 262);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtP1);
            this.Name = "MISPWD";
            this.Text = "MISPWD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtP2;
    }
}