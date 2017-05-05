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
using System.Threading;

namespace NetworkUtility.Trace
{
    public partial class UcTraceRoute : UserControl
    {
        static IEnumerable<IPAddress> IpAddresesTraceRoute;

        List<PointLatLng> points = new List<PointLatLng>();
        GMapRoute route;
        GMapOverlay routes = new GMapOverlay("routes");

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
            CheckForIllegalCrossThreadCalls = false;
            Thread treceThread = new Thread(TreceRouteStart);
            if (!treceThread.IsAlive)
            {
                treceThread.Name = "Tracing to Host";
                treceThread.Start();
            }
        }
        

        static IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress)
        {
            return GetTraceRoute(hostNameOrAddress, 1);
        }
        static IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress, int ttl)
        {
            Ping pinger = new Ping();
            PingOptions pingerOptions = new PingOptions(ttl, true);
            int timeout = 10000;
            byte[] buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            PingReply reply;// = default(PingReply);

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
                IEnumerable<IPAddress> tempResult;// = default(IEnumerable<IPAddress>);
                tempResult = GetTraceRoute(hostNameOrAddress, ttl + 1);
                result.AddRange(tempResult);
            }
            else
            {
                //failure 
            }

            return result;
        }

        void TreceRouteStart(object state)
        {
            //UcTraceRoute form = (state as UcTraceRoute);
            //if (form.InvokeRequired)
            //    form.Invoke(new ParameterizedThreadStart(TreceRouteStart), state);
            //else
            //{
                route = null;
                points.Clear();
                routes.Routes.Clear();
                traceMep.Overlays.Clear();
                IpFromHost Host = new IpFromHost();
                GeoDataByIPFromWeb Geo = new GeoDataByIPFromWeb();
                Host.GetIpAddress(textBoxUrl.Text);
                textBoxLog.Text = "";

                IpAddresesTraceRoute = GetTraceRoute(Host.NormHost);
                
                GMapOverlay markersOverlay = new GMapOverlay("markers");

                foreach (var ip in IpAddresesTraceRoute)
                {
                    GeoData GeoObj = Geo.GetData(ip.ToString());

                    textBoxLog.Text += "\r\n-->" + ip;

                    if (GeoObj.InnerData.GeoInfo.Latitude != null && GeoObj.InnerData.GeoInfo.Latitude != null)
                    {
                        textBoxLog.Text += "\r\n" + GeoObj.InnerData.GeoInfo.Latitude
                                                + "\r\n" + GeoObj.InnerData.GeoInfo.Longityde + "\r\n";

                        double lat = double.Parse(GeoObj.InnerData.GeoInfo.Latitude.Replace(".", ","));
                        double lng = double.Parse(GeoObj.InnerData.GeoInfo.Longityde.Replace(".", ","));

                        //MainMap.Position = new PointLatLng(lat, lng);

                        points.Add(new PointLatLng(lat, lng));
                        GMarkerGoogle marker = new GMarkerGoogle
                        (
                            new PointLatLng(lat,lng),
                            //GMarkerGoogleType.orange
                            new Bitmap(@"none.png")
                        );
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        marker.ToolTipText = ip.ToString() +
                            "\r\n" + GeoObj.InnerData.GeoInfo.CountryName +
                            "\r\n" + GeoObj.InnerData.GeoInfo.City +
                            "\r\n" + GeoObj.InnerData.GeoInfo.isp;
                        marker.ToolTip.Fill = Brushes.WhiteSmoke;
                        marker.ToolTip.Foreground = Brushes.Black;
                        marker.ToolTip.Stroke = Pens.Black;
                        marker.ToolTip.TextPadding = new Size(10, 10);
                        marker.ToolTip.Font = marker.ToolTip.Font = new Font("Arial", (float)7.5, FontStyle.Regular);

                        markersOverlay.Markers.Add(marker);
                    }
                    route = new GMapRoute(points, "Route");
                    route.Stroke = new Pen(Color.Brown, 2);
                    routes.Routes.Add(route);
                    traceMep.Overlays.Add(routes);
                    traceMep.Overlays.Add(markersOverlay);
                //}           
            }   
        }

        private void traceMep_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Latitude   "  +  traceMep.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            label2.Text = "Longityde "  +  traceMep.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }
    }
}
