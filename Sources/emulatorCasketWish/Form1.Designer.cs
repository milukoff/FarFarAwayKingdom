namespace emulatorCasketWish
{
    partial class Form1
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
            this.InfoLabel = new System.Windows.Forms.Label();
            this.GetStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoLabel
            // 
            this.InfoLabel.Location = new System.Drawing.Point(12, 156);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(342, 97);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GetStatus
            // 
            this.GetStatus.Location = new System.Drawing.Point(15, 28);
            this.GetStatus.Name = "GetStatus";
            this.GetStatus.Size = new System.Drawing.Size(339, 40);
            this.GetStatus.TabIndex = 4;
            this.GetStatus.Text = "Получить статус сервиса ";
            this.GetStatus.UseVisualStyleBackColor = true;
            this.GetStatus.Click += new System.EventHandler(this.GetStatus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 275);
            this.Controls.Add(this.GetStatus);
            this.Controls.Add(this.InfoLabel);
            this.Name = "Form1";
            this.Text = "Эмулятор приложения \"Ларец\"";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button GetStatus;
    }
}

