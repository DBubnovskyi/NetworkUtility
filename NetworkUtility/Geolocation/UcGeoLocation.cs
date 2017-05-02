using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

        private bool chartExist = false;

        public UcGeoLocation()
        {
            InitializeComponent();
            InetConnectionTest();
            textBoxUrl.Text = randomHostName();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxUrl.Enabled = false;
            buttonSearch.Enabled = false;
            chartExist = false;
            timer.Enabled = false;
            if (Convert.ToBoolean(textBoxUrl.Text.Length)) //перевірка чи введена URL адреса
            {
                IpFromHost host = new IpFromHost();
                host.GetIpAddress(textBoxUrl.Text); //запит до DNS сервера
                if (host.HostState) //якщо сервер дав відповідь
                {
                    labelUrlErr.Visible = false;
                    textBoxUrl.BackColor = Color.White;

                    listViewIpPing.Items.Clear();
                    foreach (IPAddress Address in host.IpAddressesList) //заповнення таблиці IP адресами які повернув DNS
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

                    textBoxLog.Text = host.Message; 
                    webBrowser.Url = new Uri("https://tools.keycdn.com/geo?host=" + host.NormHost);
                    timer.Enabled = true;
                }
                else //якщо DNS сервер не відповідає
                {
                    labelUrlErr.Visible = true;
                    textBoxUrl.BackColor = Color.OrangeRed;
                }
            }
            else //якщо адреса пуста
            {
                textBoxUrl.BackColor = Color.OrangeRed;
                textBoxUrl.Text = "впишіть URL";
            }

            textBoxUrl.Enabled = true;
            buttonSearch.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(!chartExist)
            {
                chartPing.Series.Clear();
                Random randonGen = new Random();
                for (int index = 0; index < listViewIpPing.Items.Count; index++)
                {
                    chartPing.Series.Add(index.ToString());
                    Color randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
                    chartPing.Series[index].Color = randomColor;
                    listViewIpPing.Items[index].SubItems[6].BackColor = randomColor;
                    chartPing.Series[index].ChartType = SeriesChartType.Line;
                    if (listViewIpPing.Items.Count < 3)
                    {
                        //chartPing.Series[index].IsXValueIndexed = true;
                        chartPing.Series[index].Label = "#VALms";
                    }
                    chartPing.Series[index].MarkerStyle = MarkerStyle.Circle;
                }
                chartExist = true;
            }

            for (int index = 0; index < listViewIpPing.Items.Count; index++)
            {

                if (listViewIpPing.Items[index].Checked)
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(listViewIpPing.Items[index].SubItems[1].Text,999);
                    if (chartPing.Series[index].Points.Count > 22)
                        chartPing.Series[index].Points.RemoveAt(0);
                    if (pingReply.Status == IPStatus.Success)
                    {
                        chartPing.Series[index].Points.AddY(pingReply.RoundtripTime);
                        listViewIpPing.Items[index].SubItems[2].Text = pingReply.RoundtripTime.ToString();
                        listViewIpPing.Items[index].SubItems[1].BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        chartPing.Series[index].Points.AddY(999);
                        listViewIpPing.Items[index].SubItems[2].Text = "TimeOut";
                        listViewIpPing.Items[index].SubItems[1].BackColor = Color.OrangeRed;
                    }

                }
                else
                {
                    if (chartPing.Series[index].Points.Count > 22)
                        chartPing.Series[index].Points.RemoveAt(0);
                    chartPing.Series[index].Points.AddY(0);
                    listViewIpPing.Items[index].SubItems[2].Text = "Off";
                    listViewIpPing.Items[index].SubItems[1].BackColor = Color.Orange;
                }
            }

            
        }

        private void textBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void InetConnectionTest()
        {
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

        private string randomHostName() //рандомно повертає існуючу URL адресу 
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
                "linkedin.com",
                "piznay.com",
                "youtube.com"
            };
            Random random = new Random();
            return hosts[random.Next(hosts.Length-1)];
        }

        private void textBoxUrl_Click(object sender, EventArgs e) //очистка текстового поля по кліку для зручності
        {
            labelUrlErr.Visible = false;
            textBoxUrl.BackColor = Color.White;
            textBoxUrl.Text = "";
        }

        private void buttonRandomUrl_Click(object sender, EventArgs e)
        {
            textBoxUrl.Text = randomHostName();
        }
    }
}