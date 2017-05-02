using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.NetworkInformation;
using System.Net;

namespace NetworkUtility.Trace
{
    public partial class UcTraceRoute : UserControl
    {
        static IEnumerable<IPAddress> IpAddresesTraceRoute;

        private static UcTraceRoute _sample;
        public static UcTraceRoute Sample
        {
            get
            {
                if (_sample == null)
                {
                    _sample = new UcTraceRoute();
                    Sample.Dock = DockStyle.Fill;
                }
                return _sample;
            }
        }
        public UcTraceRoute()
        {
            InitializeComponent();
            traceMep.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            traceMep.SetPositionByKeywords("Paris, France");
            traceMep.ShowCenter = false;

            traceMep.Zoom = 9;
            traceMep.Position = new PointLatLng(49.35, 28.45);
            traceMep.MapProvider = GoogleMapProvider.Instance;
            traceMep.DragButton = MouseButtons.Left;
            traceMep.IgnoreMarkerOnMouseWheel = true;
        }

        private void Trace_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
            foreach(var ip in GetTraceRoute(textBoxUrl.Text))
            {
                textBoxLog.Text += "\r\n" + ip;
            }
        }
        private const string Data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        static IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress)
        {
            return GetTraceRoute(hostNameOrAddress, 1);
        }
        static IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress, int ttl)
        {
            Ping pinger = new Ping();
            PingOptions pingerOptions = new PingOptions(ttl, true);
            int timeout = 10000;
            byte[] buffer = Encoding.ASCII.GetBytes(Data);
            PingReply reply = default(PingReply);

            reply = pinger.Send(hostNameOrAddress, timeout, buffer, pingerOptions);

            List<IPAddress> result = new List<IPAddress>();
            if (reply.Status == IPStatus.Success)
            {
                result.Add(reply.Address);
            }
            else if (reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimedOut)
            {
                //add the currently returned address if an address was found with this TTL
                if (reply.Status == IPStatus.TtlExpired) result.Add(reply.Address);
                //recurse to get the next address...
                IEnumerable<IPAddress> tempResult = default(IEnumerable<IPAddress>);
                tempResult = GetTraceRoute(hostNameOrAddress, ttl + 1);
                result.AddRange(tempResult);
            }
            else
            {
                //failure 
            }

            return result;
        }
    }
}
