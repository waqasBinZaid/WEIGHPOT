namespace ITWhiz.ScaleSoft.Desktop
{
    partial class FrmOption
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
            this.btnfirstweight = new System.Windows.Forms.Button();
            this.btnsecondweight = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnfirstweight
            // 
            this.btnfirstweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfirstweight.Location = new System.Drawing.Point(88, 62);
            this.btnfirstweight.Name = "btnfirstweight";
            this.btnfirstweight.Size = new System.Drawing.Size(109, 35);
            this.btnfirstweight.TabIndex = 0;
            this.btnfirstweight.Text = "&First Weight";
            this.btnfirstweight.UseVisualStyleBackColor = true;
            this.btnfirstweight.Click += new System.EventHandler(this.btnfirstweight_Click);
            // 
            // btnsecondweight
            // 
            this.btnsecondweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsecondweight.Location = new System.Drawing.Point(88, 113);
            this.btnsecondweight.Name = "btnsecondweight";
            this.btnsecondweight.Size = new System.Drawing.Size(109, 35);
            this.btnsecondweight.TabIndex = 1;
            this.btnsecondweight.Text = "&Second Weight";
            this.btnsecondweight.UseVisualStyleBackColor = true;
            this.btnsecondweight.Click += new System.EventHandler(this.btnsecondweight_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(88, 173);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(109, 35);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "&Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsecondweight);
            this.Controls.Add(this.btnfirstweight);
            this.Name = "FrmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOption";
            this.Load += new System.EventHandler(this.FrmOption_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnfirstweight;
        private System.Windows.Forms.Button btnsecondweight;
        private System.Windows.Forms.Button btncancel;
    }
}