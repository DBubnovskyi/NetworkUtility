using System;
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
        }

        private void налаштуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Add(UserControl1.Instance);
            UserControl1.Instance.BringToFront();
            UserControl1.Instance.Dock = DockStyle.Fill;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            //panelMain.Size = FormMain.Size
        }
    }
}
