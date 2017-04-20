using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
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
            InetConnectionTest();
           
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(textBoxUrl.Text.Length))
            {
                IpFromHost host = new IpFromHost();
                host.GetIpAddress(textBoxUrl.Text);
                if (host.HostState)
                {
                    labelUrlErr.Visible = false;
                    textBoxUrl.BackColor = Color.White;

                    listViewIpPing.Items.Clear();
                    foreach (IPAddress Address in host.IpAddressesList)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Checked = true;
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(Address.ToString());
                        item.SubItems.Add("N/A");
                        item.SubItems.Add("N/A");
                        item.SubItems.Add("N/A");
                        item.SubItems.Add("N/A");
                        item.SubItems.Add("");
                        listViewIpPing.Items.Add(item);
                    }
                }
                else
                {
                    labelUrlErr.Visible = true;
                    textBoxUrl.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                textBoxUrl.BackColor = Color.OrangeRed;
                textBoxUrl.Text = "впишіть URL";
            }


            //InetConnectionTest();
            ////timer.Enabled = true;
            //ListViewItem item = new ListViewItem();
            //item.Checked = true;
            //item.UseItemStyleForSubItems = false;
            //item.SubItems.Add("192.123.213.222");
            //item.SubItems.Add("SubI 2");
            //item.SubItems.Add("SubI 3");
            //item.SubItems.Add("SubI 4");
            //item.SubItems.Add("SubI 5");
            //item.SubItems.Add("");

            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int rand = new Random().Next(10,100);
            if (listViewIpPing.Items[0].Checked)
            {
                chart1.Series["Series1"].Points.AddY(rand);
                listViewIpPing.Items[0].SubItems[2].Text = rand.ToString();
                listViewIpPing.Items[0].SubItems[6].BackColor = Color.Aquamarine;
            }
            else
            {
                chart1.Series["Series1"].Points.AddY(999);
                listViewIpPing.Items[0].SubItems[2].Text = "TimeOut";
                listViewIpPing.Items[0].SubItems[6].BackColor = Color.OrangeRed;
            }
        }

        private void InetConnectionTest()
        {
            textBoxUrl.Text = randomHostName();
            Ping server = new Ping();
            //перевірка підключення до інтеренету і сервісу геолокації
            PingReply serverReply = server.Send("8.8.8.8");
            textBoxLog.Text += "Перевірка підключення до мережі" +
                               "\r\nпінг до 8.8.8.8   ";
            if (serverReply?.Status == IPStatus.Success)
            {
                buttonDnsGoogleTest.BackColor = Color.YellowGreen;
                buttonDnsGoogleTest.Text = "Є підключення";
                textBoxLog.Text += serverReply.RoundtripTime + "ms";
            }
            else
            {
                buttonDnsGoogleTest.BackColor = Color.OrangeRed;
                buttonDnsGoogleTest.Text = "Підключення відсутнє";
                textBoxLog.Text += "TimeOut";
            }

            textBoxLog.Text += "\r\ntools.keycdn.com   ";
            
            bool err = false;
            try
            {
               Dns.GetHostEntry("tools.keycdn.com");
            }
            catch (Exception e)
            {
                buttonGeoTest.BackColor = Color.OrangeRed;
                buttonGeoTest.Text = "Підключення відсутнє";
                textBoxLog.Text += "TimeOut";
                err = true;
            }
            
            if (!err)
            {
                buttonGeoTest.BackColor = Color.YellowGreen;
                buttonGeoTest.Text = "Є підключення";
                textBoxLog.Text += "Ok";
            }
        }

        private string randomHostName()
        {
            string[] hosts = 
            {
                "stackoverflow.com",
                "google.com",
                "vk.com",
                "twitter.com",
                "flaticon.com",
                "color.adobe.com",
                "github.com",
                "msdn.microsoft.com",
                "tools.keycdn.com",
                "2ip.ua",
                "intita.com",
                ".linkedin.com",
                "piznay.com"
            };
            Random random = new Random();
            return hosts[random.Next(hosts.Length-1)];
        }

        private void textBoxUrl_Click(object sender, EventArgs e)
        {
            labelUrlErr.Visible = false;
            textBoxUrl.BackColor = Color.White;
            textBoxUrl.Text = "";
        }
    }
}