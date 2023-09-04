namespace DXLog.net
{
    partial class DXLbuttonbar
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
            this.ANT1 = new System.Windows.Forms.Button();
            this.ANT2 = new System.Windows.Forms.Button();
            this.ANT3 = new System.Windows.Forms.Button();
            this.ANT4 = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ANT1
            // 
            this.ANT1.BackColor = System.Drawing.SystemColors.Highlight;
            this.ANT1.Enabled = false;
            this.ANT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANT1.ForeColor = System.Drawing.Color.White;
            this.ANT1.Location = new System.Drawing.Point(3, 46);
            this.ANT1.Name = "ANT1";
            this.ANT1.Size = new System.Drawing.Size(75, 23);
            this.ANT1.TabIndex = 2;
            this.ANT1.Text = "ANT 1";
            this.ANT1.UseVisualStyleBackColor = false;
            this.ANT1.Click += new System.EventHandler(this.F1_Click);
            // 
            // ANT2
            // 
            this.ANT2.BackColor = System.Drawing.SystemColors.Highlight;
            this.ANT2.Enabled = false;
            this.ANT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANT2.ForeColor = System.Drawing.Color.White;
            this.ANT2.Location = new System.Drawing.Point(84, 46);
            this.ANT2.Name = "ANT2";
            this.ANT2.Size = new System.Drawing.Size(75, 23);
            this.ANT2.TabIndex = 3;
            this.ANT2.Text = "ANT 2";
            this.ANT2.UseVisualStyleBackColor = false;
            this.ANT2.Click += new System.EventHandler(this.F2_Click);
            // 
            // ANT3
            // 
            this.ANT3.BackColor = System.Drawing.SystemColors.Highlight;
            this.ANT3.Enabled = false;
            this.ANT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANT3.ForeColor = System.Drawing.Color.White;
            this.ANT3.Location = new System.Drawing.Point(165, 46);
            this.ANT3.Name = "ANT3";
            this.ANT3.Size = new System.Drawing.Size(75, 23);
            this.ANT3.TabIndex = 4;
            this.ANT3.Text = "ANT 3";
            this.ANT3.UseVisualStyleBackColor = false;
            this.ANT3.Click += new System.EventHandler(this.F3_Click);
            // 
            // ANT4
            // 
            this.ANT4.BackColor = System.Drawing.SystemColors.Highlight;
            this.ANT4.Enabled = false;
            this.ANT4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANT4.ForeColor = System.Drawing.Color.White;
            this.ANT4.Location = new System.Drawing.Point(246, 46);
            this.ANT4.Name = "ANT4";
            this.ANT4.Size = new System.Drawing.Size(75, 23);
            this.ANT4.TabIndex = 5;
            this.ANT4.Text = "ANT 4";
            this.ANT4.UseVisualStyleBackColor = false;
            this.ANT4.Click += new System.EventHandler(this.F4_Click);
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.SystemColors.Highlight;
            this.Connect.Enabled = false;
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect.ForeColor = System.Drawing.Color.White;
            this.Connect.Location = new System.Drawing.Point(213, 10);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(108, 23);
            this.Connect.TabIndex = 9;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 10;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DXLbuttonbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 85);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.ANT4);
            this.Controls.Add(this.ANT3);
            this.Controls.Add(this.ANT2);
            this.Controls.Add(this.ANT1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.FormID = 1004;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DXLbuttonbar";
            this.Text = "Antenna Switch PA2DK";
            this.Activated += new System.EventHandler(this.DXLbuttonbar_Activated);
            this.Load += new System.EventHandler(this.DXLbuttonbar_Load);
            this.Shown += new System.EventHandler(this.DXLbuttonbar_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ANT1;
        private System.Windows.Forms.Button ANT2;
        private System.Windows.Forms.Button ANT3;
        private System.Windows.Forms.Button ANT4;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label label1;
    }
}