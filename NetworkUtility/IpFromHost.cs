using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace NetworkUtility
{
    class IpFromHost
    {
        public bool HostState;
        public string Message;
        public List<IPAddress> IpAddressesList = new List<IPAddress>();
        public string GetIpAddress(string hostname)
        {
            Message += "\r\nIP адресса домену " + hostname + "\r\n";
            hostname = hostname.Replace("http://","");
            hostname = hostname.Replace("https://", "");
            string[] hosts = hostname.Split('/');
            string normHost = hosts[0];

            IPHostEntry entry = null;

            try
            {
                entry = Dns.GetHostEntry(normHost);
            }
            catch (SocketException e)
            {
                if (e.Data != null)
                {
                    HostState = false;
                    Message += "\r\nDNS сервер не відповідає\r\nабо помилкове їм'я хосту!";
                    return Message;
                }
            }
            HostState = true;
            foreach (IPAddress a in entry.AddressList)
            {
                Message += "  --> " + a + "\r\n";
                IpAddressesList.Add(a);
            }

            Message += "\r\nальтернативне ім'я домену: ";
            foreach (string aliasName in entry.Aliases)
                Message += aliasName + "\r\n";

            Message += "\r\nРеальна назва хоста: " + entry.HostName;

            Ping pingSender = new Ping();
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;
            PingOptions options = new PingOptions(64, true);

            PingReply reply = pingSender.Send(entry.AddressList.FirstOrDefault(), timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                //Message += ("\r\n\r\nAddress: " + reply.Address);
                Message += ("\r\n\r\nRoundTrip time: " + reply.RoundtripTime);
                Message += ("\r\nTime to live: " + reply.Options.Ttl);
                Message += ("\r\nDon't fragment: " + reply.Options.DontFragment);
                Message += ("\r\nBuffer size: " + reply.Buffer.Length);
            }
            else
            {
                Message += ("\r\n\r\n" + reply.Status);
            }

            return Message;
        }
    }
}
