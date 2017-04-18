using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NetworkUtility
{
    public partial class UcGeoLocation : UserControl
    {
        private static UcGeoLocation _sample;
        public static UcGeoLocation Sample
        {
            get
            {
                if (_sample == null)
                {
                    _sample = new UcGeoLocation();
                    Sample.Dock = DockStyle.Fill;
                }
                return _sample;
            }
        }

        public UcGeoLocation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            ListViewItem item = new ListViewItem();
            item.Checked = true;
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("192.123.213.222");
            item.SubItems.Add("SubI 2");
            item.SubItems.Add("SubI 3");
            item.SubItems.Add("SubI 4");
            item.SubItems.Add("SubI 5");
            item.SubItems.Add("");

            listView1.Items.Add(item);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int rand = new Random().Next(10,100);
            if (listView1.Items[0].Checked)
            {
                chart1.Series["Series1"].Points.AddY(rand);
                listView1.Items[0].SubItems[2].Text = rand.ToString();
                listView1.Items[0].SubItems[6].BackColor = Color.Aquamarine;
            }
            else
            {
                chart1.Series["Series1"].Points.AddY(999);
                listView1.Items[0].SubItems[2].Text = "TimeOut";
                listView1.Items[0].SubItems[6].BackColor = Color.LightCoral;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.BorderStyle = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Visible = !chart1.Visible;
        }
    }
}