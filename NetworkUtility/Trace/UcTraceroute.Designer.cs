namespace NetworkUtility.Trace
{
    partial class UcTraceRoute
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.traceMep = new GMap.NET.WindowsForms.GMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.Trace = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // traceMep
            // 
            this.traceMep.Bearing = 0F;
            this.traceMep.CanDragMap = true;
            this.traceMep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.traceMep.EmptyTileColor = System.Drawing.Color.Navy;
            this.traceMep.GrayScaleMode = false;
            this.traceMep.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.traceMep.LevelsKeepInMemmory = 5;
            this.traceMep.Location = new System.Drawing.Point(0, 0);
            this.traceMep.MarkersEnabled = true;
            this.traceMep.MaxZoom = 18;
            this.traceMep.MinZoom = 1;
            this.traceMep.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.traceMep.Name = "traceMep";
            this.traceMep.NegativeMode = false;
            this.traceMep.PolygonsEnabled = true;
            this.traceMep.RetryLoadTile = 0;
            this.traceMep.RoutesEnabled = true;
            this.traceMep.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.traceMep.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.traceMep.ShowTileGridLines = false;
            this.traceMep.Size = new System.Drawing.Size(773, 700);
            this.traceMep.TabIndex = 0;
            this.traceMep.Zoom = 0D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxLog);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 700);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.traceMep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(227, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 700);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Trace);
            this.groupBox1.Controls.Add(this.textBoxUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(205, 419);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(11, 24);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(183, 20);
            this.textBoxUrl.TabIndex = 0;
            // 
            // Trace
            // 
            this.Trace.BackColor = System.Drawing.Color.LightBlue;
            this.Trace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Trace.Location = new System.Drawing.Point(11, 50);
            this.Trace.Name = "Trace";
            this.Trace.Size = new System.Drawing.Size(183, 23);
            this.Trace.TabIndex = 1;
            this.Trace.Text = "button1";
            this.Trace.UseVisualStyleBackColor = false;
            this.Trace.Click += new System.EventHandler(this.Trace_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(23, 93);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(183, 327);
            this.textBoxLog.TabIndex = 1;
            // 
            // UcTraceRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UcTraceRoute";
            this.Size = new System.Drawing.Size(1000, 700);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl traceMep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Trace;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.TextBox textBoxLog;
    }
}
