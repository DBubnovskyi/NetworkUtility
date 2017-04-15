namespace NetworkUtility
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.цуйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.йуцToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ййййййуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSeting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemSeting,
            this.ToolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(746, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цуйToolStripMenuItem,
            this.йуцToolStripMenuItem,
            this.ййййййуToolStripMenuItem});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemFile.Text = "Файл";
            // 
            // цуйToolStripMenuItem
            // 
            this.цуйToolStripMenuItem.Name = "цуйToolStripMenuItem";
            this.цуйToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.цуйToolStripMenuItem.Text = "цуй";
            // 
            // йуцToolStripMenuItem
            // 
            this.йуцToolStripMenuItem.Name = "йуцToolStripMenuItem";
            this.йуцToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.йуцToolStripMenuItem.Text = "йуц";
            // 
            // ййййййуToolStripMenuItem
            // 
            this.ййййййуToolStripMenuItem.Name = "ййййййуToolStripMenuItem";
            this.ййййййуToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.ййййййуToolStripMenuItem.Text = "ййййййу";
            // 
            // ToolStripMenuItemSeting
            // 
            this.ToolStripMenuItemSeting.Name = "ToolStripMenuItemSeting";
            this.ToolStripMenuItemSeting.Size = new System.Drawing.Size(101, 20);
            this.ToolStripMenuItemSeting.Text = "Налаштування";
            this.ToolStripMenuItemSeting.Click += new System.EventHandler(this.налаштуванняToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(75, 20);
            this.ToolStripMenuItemHelp.Text = "Допомога";
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(746, 576);
            this.panelMain.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(746, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(177, 200);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetworkUtility";
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSeting;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem цуйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem йуцToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ййййййуToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
    }
}

