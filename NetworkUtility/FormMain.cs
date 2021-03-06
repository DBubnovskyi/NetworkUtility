﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkUtility
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            panelMain.Controls.Add(UcGeoLocation.Sample);
            panelMain.Controls.Add(Trace.UcTraceRoute.Sample);
            Trace.UcTraceRoute.Sample.BringToFront();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            //panelMain.Size = FormMain.Size
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UcGeoLocation.Sample.BringToFront();
        }

        private void traceRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trace.UcTraceRoute.Sample.BringToFront();
        }
    }
}
