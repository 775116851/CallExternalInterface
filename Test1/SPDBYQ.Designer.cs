namespace Test1
{
    partial class SPDBYQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPDBYQ));
            this.txtParams = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.txtAppDesKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtParams
            // 
            resources.ApplyResources(this.txtParams, "txtParams");
            this.txtParams.Name = "txtParams";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtValues
            // 
            resources.ApplyResources(this.txtValues, "txtValues");
            this.txtValues.Name = "txtValues";
            this.txtValues.ReadOnly = true;
            this.txtValues.Click += new System.EventHandler(this.txtValues_Click);
            // 
            // txtAppDesKey
            // 
            resources.ApplyResources(this.txtAppDesKey, "txtAppDesKey");
            this.txtAppDesKey.Name = "txtAppDesKey";
            // 
            // SPDBYQ
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAppDesKey);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtParams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SPDBYQ";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.TextBox txtAppDesKey;
    }
}