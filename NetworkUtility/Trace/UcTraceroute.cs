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
            GeoDataByIPFromWeb localGeoObj = new GeoDataByIPFromWeb();
            GeoData localGeo = localGeoObj.GetData("");
            double lat = double.Parse(localGeo.InnerData.GeoInfo.Latitude.Replace(".", ","));
            double lng = double.Parse(localGeo.InnerData.GeoInfo.Longityde.Replace(".", ","));
            if (localGeo.InnerData.GeoInfo.Latitude != null && localGeo.InnerData.GeoInfo.Longityde != null)
                traceMep.Position = new PointLatLng(lat, lng);
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
        

        IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress)
        {
            const int timeOutCounter = 0;
            return GetTraceRoute(hostNameOrAddress, 1, timeOutCounter);
        }
        IEnumerable<IPAddress> GetTraceRoute(string hostNameOrAddress, int ttl, int timeOutCounter)
        {
            Ping pinger = new Ping();
            PingOptions pingerOptions = new PingOptions(ttl, true);
            int timeOut = 1000;
           
            byte[] buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            PingReply reply;// = default(PingReply);

            reply = pinger.Send(hostNameOrAddress, timeOut, buffer, pingerOptions);
            textBoxLog.Text += "<-- send ping with ttl " + ttl + "\r\n";

            List<IPAddress> result = new List<IPAddress>();
            if (reply.Status == IPStatus.Success)
            {
                result.Add(reply.Address);
                textBoxLog.Text += "--> " + reply.Address + " " + reply.RoundtripTime + "ms\r\n";
            }
            else if (reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimedOut)
            {
                //add the currently returned address if an address was found with this TTL
                if (reply.Status == IPStatus.TtlExpired)
                {
                    result.Add(reply.Address);
                    textBoxLog.Text += "--> " + reply.Address + " " + reply.RoundtripTime + "ms\r\n";
                    timeOutCounter = 0;
                }
                else if (reply.Status == IPStatus.TimedOut)
                {
                    textBoxLog.Text += "--> " + reply.Address + " " + "TimedOut\r\n";
                    if (++timeOutCounter > 5)
                    {
                        return result;
                    }
                }
                //recurse to get the next address...
                IEnumerable<IPAddress> tempResult;// = default(IEnumerable<IPAddress>);
                tempResult = GetTraceRoute(hostNameOrAddress, ttl + 1, timeOutCounter);
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
            textBoxLog.Text = "";
            route = null;
            points.Clear();
            routes.Routes.Clear();
            traceMep.Overlays.Clear();
            IpFromHost Host = new IpFromHost();
            GeoDataByIPFromWeb Geo = new GeoDataByIPFromWeb();
            Host.GetIpAddress(textBoxUrl.Text);

            if (Host.HostState)
            {

                IpAddresesTraceRoute = GetTraceRoute(Host.NormHost);


                GMapOverlay markersOverlay = new GMapOverlay("markers");

                int index = 0;
                foreach (var ip in IpAddresesTraceRoute)
                {
                    Thread.Sleep(600);
                    index++;
                    GeoData GeoObj = Geo.GetData(ip.ToString());

                    textBoxLog.Text += "\r\n-->" + ip + " #" + index;

                    if (GeoObj.InnerData.GeoInfo.Latitude != null && GeoObj.InnerData.GeoInfo.Latitude != null)
                    {
                        textBoxLog.Text += "\r\n" + GeoObj.InnerData.GeoInfo.Latitude
                                           + "\r\n" + GeoObj.InnerData.GeoInfo.Longityde + "\r\n";

                        double lat = double.Parse(GeoObj.InnerData.GeoInfo.Latitude.Replace(".", ","));
                        double lng = double.Parse(GeoObj.InnerData.GeoInfo.Longityde.Replace(".", ","));

                        traceMep.Position = new PointLatLng(lat, lng);


                        bool ifUnique = true;
                        foreach (var point in markersOverlay.Markers)
                        {
                            if (point.Position.Lat == lat && point.Position.Lng == lng)
                            {
                                point.ToolTipText = ip + " #" + index + "\r\n" + point.ToolTipText;
                                ifUnique = false;
                                points.Add(new PointLatLng(lat, lng));
                            }
                            else
                            {

                            }
                        }
                        if (ifUnique)
                        {
                            points.Add(new PointLatLng(lat, lng));
                            GMarkerGoogle marker = new GMarkerGoogle
                                (
                                new PointLatLng(lat, lng),
                                //GMarkerGoogleType.orange
                                new Bitmap(@"none.png")
                                );
                            marker.ToolTipMode = MarkerTooltipMode.Always;
                            marker.ToolTipText = ip + " #" + index +
                                                 "\r\n" + GeoObj.InnerData.GeoInfo.CountryName +
                                                 "\r\n" + GeoObj.InnerData.GeoInfo.City +
                                                 "\r\n" + GeoObj.InnerData.GeoInfo.isp;
                            marker.ToolTip.Fill = Brushes.WhiteSmoke;
                            marker.ToolTip.Foreground = Brushes.Black;
                            marker.ToolTip.Stroke = Pens.Black;
                            marker.ToolTip.TextPadding = new Size(10, 10);
                            marker.ToolTip.Font =
                                marker.ToolTip.Font = new Font("Arial", (float) 7.5, FontStyle.Regular);

                            markersOverlay.Markers.Add(marker);
                        }
                    }
                    else
                    {
                        textBoxLog.Text += "\r\nno geo data\r\n";
                    }
                    route = new GMapRoute(points, "Route");
                    route.Stroke = new Pen(Color.Brown, 2);
                    routes.Routes.Add(route);
                    traceMep.Overlays.Add(routes);
                    traceMep.Overlays.Add(markersOverlay);
                }
            }
            else
            {
                textBoxLog.Text = "Error! Invalid URL";
            }
        }

        private void traceMep_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Latitude   "  +  traceMep.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            label2.Text = "Longityde "  +  traceMep.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }
    }
}
