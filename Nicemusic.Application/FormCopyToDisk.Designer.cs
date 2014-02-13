namespace Nicemusic.Application
{
    partial class FormCopyToDisk
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
            this.chkFavoriteList = new System.Windows.Forms.CheckedListBox();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dialogDestinationDisk = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountFileSize = new System.Windows.Forms.Label();
            this.txtSelectedSong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkFavoriteList
            // 
            this.chkFavoriteList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFavoriteList.FormattingEnabled = true;
            this.chkFavoriteList.Location = new System.Drawing.Point(13, 43);
            this.chkFavoriteList.Name = "chkFavoriteList";
            this.chkFavoriteList.Size = new System.Drawing.Size(1029, 274);
            this.chkFavoriteList.TabIndex = 0;
            this.chkFavoriteList.SelectedIndexChanged += new System.EventHandler(this.ChkFavoriteListSelectedIndexChanged);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPath.Location = new System.Drawing.Point(13, 330);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.ReadOnly = true;
            this.txtDestinationPath.Size = new System.Drawing.Size(948, 20);
            this.txtDestinationPath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(967, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(967, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SendButtonClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "count";
            // 
            // lblCountFileSize
            // 
            this.lblCountFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountFileSize.AutoSize = true;
            this.lblCountFileSize.Location = new System.Drawing.Point(136, 362);
            this.lblCountFileSize.Name = "lblCountFileSize";
            this.lblCountFileSize.Size = new System.Drawing.Size(25, 13);
            this.lblCountFileSize.TabIndex = 5;
            this.lblCountFileSize.Text = "size";
            // 
            // txtSelectedSong
            // 
            this.txtSelectedSong.Location = new System.Drawing.Point(13, 13);
            this.txtSelectedSong.Name = "txtSelectedSong";
            this.txtSelectedSong.ReadOnly = true;
            this.txtSelectedSong.Size = new System.Drawing.Size(693, 20);
            this.txtSelectedSong.TabIndex = 6;
            // 
            // FormCopyToDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 389);
            this.Controls.Add(this.txtSelectedSong);
            this.Controls.Add(this.lblCountFileSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.chkFavoriteList);
            this.Name = "FormCopyToDisk";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCopyToDisk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCopyToDiskClosing);
            this.Load += new System.EventHandler(this.FormCopyToDiskLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkFavoriteList;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog dialogDestinationDisk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountFileSize;
        private System.Windows.Forms.TextBox txtSelectedSong;
    }
}