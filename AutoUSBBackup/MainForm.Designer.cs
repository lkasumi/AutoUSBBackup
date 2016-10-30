namespace AutoUSBBackup
{
    partial class MainForm
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
            this.lbMessage = new System.Windows.Forms.Label();
            this.driveList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMessage.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMessage.Location = new System.Drawing.Point(12, 9);
            this.lbMessage.MinimumSize = new System.Drawing.Size(100, 100);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(100, 100);
            this.lbMessage.TabIndex = 0;
            // 
            // driveList
            // 
            this.driveList.FormattingEnabled = true;
            this.driveList.ItemHeight = 12;
            this.driveList.Location = new System.Drawing.Point(118, 9);
            this.driveList.Name = "driveList";
            this.driveList.Size = new System.Drawing.Size(165, 172);
            this.driveList.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 190);
            this.Controls.Add(this.driveList);
            this.Controls.Add(this.lbMessage);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.ListBox driveList;
    }
}