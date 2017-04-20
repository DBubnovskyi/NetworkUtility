namespace NetworkUtility
{
    partial class UcGeoLocation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader color;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listViewIpPing = new System.Windows.Forms.ListView();
            this.CheckBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IpAddresValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.curentPingValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.minPingValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maxPingValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AvrPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonGeoTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDnsGoogleTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelUpl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelUrlErr = new System.Windows.Forms.Label();
            color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // color
            // 
            color.Text = "";
            color.Width = 30;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.webBrowser);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 709);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(400, 305);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(705, 404);
            this.webBrowser.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Controls.Add(this.listViewIpPing);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(400, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(705, 305);
            this.panel3.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Empty;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 90F;
            chartArea1.InnerPlotPosition.Width = 85F;
            chartArea1.InnerPlotPosition.X = 12F;
            chartArea1.InnerPlotPosition.Y = 2F;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(360, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(345, 305);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // listViewIpPing
            // 
            this.listViewIpPing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewIpPing.CheckBoxes = true;
            this.listViewIpPing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CheckBox,
            this.IpAddresValue,
            this.curentPingValue,
            this.minPingValue,
            this.maxPingValue,
            this.AvrPing,
            color});
            this.listViewIpPing.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewIpPing.FullRowSelect = true;
            this.listViewIpPing.HideSelection = false;
            this.listViewIpPing.Location = new System.Drawing.Point(0, 0);
            this.listViewIpPing.Name = "listViewIpPing";
            this.listViewIpPing.Size = new System.Drawing.Size(360, 305);
            this.listViewIpPing.TabIndex = 5;
            this.listViewIpPing.UseCompatibleStateImageBehavior = false;
            this.listViewIpPing.View = System.Windows.Forms.View.Details;
            // 
            // CheckBox
            // 
            this.CheckBox.Text = "";
            this.CheckBox.Width = 35;
            // 
            // IpAddresValue
            // 
            this.IpAddresValue.Text = "IP Адреса";
            this.IpAddresValue.Width = 120;
            // 
            // curentPingValue
            // 
            this.curentPingValue.Text = "ping";
            this.curentPingValue.Width = 50;
            // 
            // minPingValue
            // 
            this.minPingValue.Text = "Мін.";
            this.minPingValue.Width = 40;
            // 
            // maxPingValue
            // 
            this.maxPingValue.Text = "Мак.";
            this.maxPingValue.Width = 40;
            // 
            // AvrPing
            // 
            this.AvrPing.Text = "Сер.";
            this.AvrPing.Width = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 709);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.textBoxLog);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 395);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(400, 314);
            this.panel6.TabIndex = 5;
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(400, 314);
            this.textBoxLog.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelUrlErr);
            this.panel4.Controls.Add(this.buttonGeoTest);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.buttonDnsGoogleTest);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBoxUrl);
            this.panel4.Controls.Add(this.buttonSearch);
            this.panel4.Controls.Add(this.labelUpl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 395);
            this.panel4.TabIndex = 3;
            // 
            // buttonGeoTest
            // 
            this.buttonGeoTest.BackColor = System.Drawing.Color.Gold;
            this.buttonGeoTest.Enabled = false;
            this.buttonGeoTest.FlatAppearance.BorderSize = 0;
            this.buttonGeoTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeoTest.Location = new System.Drawing.Point(199, 68);
            this.buttonGeoTest.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGeoTest.Name = "buttonGeoTest";
            this.buttonGeoTest.Size = new System.Drawing.Size(188, 20);
            this.buttonGeoTest.TabIndex = 6;
            this.buttonGeoTest.Text = "Тестування";
            this.buttonGeoTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGeoTest.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "З\'єднання з сервісом геолокації";
            // 
            // buttonDnsGoogleTest
            // 
            this.buttonDnsGoogleTest.BackColor = System.Drawing.Color.Gold;
            this.buttonDnsGoogleTest.Enabled = false;
            this.buttonDnsGoogleTest.FlatAppearance.BorderSize = 0;
            this.buttonDnsGoogleTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDnsGoogleTest.Location = new System.Drawing.Point(199, 43);
            this.buttonDnsGoogleTest.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDnsGoogleTest.Name = "buttonDnsGoogleTest";
            this.buttonDnsGoogleTest.Size = new System.Drawing.Size(188, 20);
            this.buttonDnsGoogleTest.TabIndex = 4;
            this.buttonDnsGoogleTest.Text = "Тестування";
            this.buttonDnsGoogleTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDnsGoogleTest.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "З\'єднання з DNS сервером Google";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log викрнання";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUrl.Location = new System.Drawing.Point(42, 16);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(260, 20);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.Click += new System.EventHandler(this.textBoxUrl_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Silver;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(312, 16);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 20);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Пошук";
            this.buttonSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelUpl
            // 
            this.labelUpl.AutoSize = true;
            this.labelUpl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUpl.ForeColor = System.Drawing.Color.Black;
            this.labelUpl.Location = new System.Drawing.Point(10, 19);
            this.labelUpl.Name = "labelUpl";
            this.labelUpl.Size = new System.Drawing.Size(27, 14);
            this.labelUpl.TabIndex = 0;
            this.labelUpl.Text = "URL";
            this.labelUpl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelUrlErr
            // 
            this.labelUrlErr.AutoSize = true;
            this.labelUrlErr.BackColor = System.Drawing.Color.Transparent;
            this.labelUrlErr.ForeColor = System.Drawing.Color.Red;
            this.labelUrlErr.Location = new System.Drawing.Point(132, 3);
            this.labelUrlErr.Name = "labelUrlErr";
            this.labelUrlErr.Size = new System.Drawing.Size(90, 13);
            this.labelUrlErr.TabIndex = 7;
            this.labelUrlErr.Text = "Помилкове URL";
            this.labelUrlErr.Visible = false;
            // 
            // UcGeoLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1040, 700);
            this.Name = "UcGeoLocation";
            this.Size = new System.Drawing.Size(1105, 709);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelUpl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ListView listViewIpPing;
        private System.Windows.Forms.ColumnHeader CheckBox;
        private System.Windows.Forms.ColumnHeader IpAddresValue;
        private System.Windows.Forms.ColumnHeader curentPingValue;
        private System.Windows.Forms.ColumnHeader minPingValue;
        private System.Windows.Forms.ColumnHeader maxPingValue;
        private System.Windows.Forms.ColumnHeader AvrPing;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDnsGoogleTest;
        private System.Windows.Forms.Button buttonGeoTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUrlErr;
    }
}
