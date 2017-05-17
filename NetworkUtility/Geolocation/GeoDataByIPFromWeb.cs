using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace NetworkUtility
{
    // ReSharper disable once InconsistentNaming
    class GeoDataByIPFromWeb
    {
        public GeoData GetData(string ip)
        {
            GeoData objGeoData;
            using (WebClient webClient = new WebClient())   //створення нового веб клієнта
            {
                Stream webSream = null;
                try
                {
                    webSream = webClient.OpenRead("https://tools.keycdn.com/geo.json?host=" + ip);
                }
                catch (Exception e)
                {

                }
                if (webSream != null)
                {
                    StreamReader stringFromStream = new StreamReader(webSream);                             //читання потоку як стрічка
                    objGeoData = JsonConvert.DeserializeObject<GeoData>(stringFromStream.ReadToEnd());      //парсинг стрічки json в object
                    webSream.Close();
                }else{ objGeoData = null; }
            }                                                                            
            return objGeoData;      //повернення екземпляру класу з геоданими
        }
    }


    [DataContract]
    class GeoData
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "data")]
        public InnerData InnerData { get; set; }
    }

    [DataContract]
    class InnerData
    {
        [DataMember(Name = "geo")]
        public Geo GeoInfo { get; set; }
    }

    [DataContract]
    class Geo
    {
        [DataMember(Name = "host")]
        public string Host { get; set; }
        [DataMember(Name = "ip")]
        public string Ip { get; set; }
        [DataMember(Name = "rdns")]
        public string Rdns { get; set; }
        [DataMember(Name = "asn")]
        public string asn { get; set; }
        [DataMember(Name = "isp")]
        public string isp { get; set; }
        [DataMember(Name = "country_name")]
        public string CountryName { get; set; }
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }
        [DataMember(Name = "region")]
        public string Region { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }
        [DataMember(Name = "continent_code")]
        public string ContinentCode { get; set; }
        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public string Longityde { get; set; }
        [DataMember(Name = "dma_code")]
        public string DmaCode { get; set; }
        [DataMember(Name = "area_code")]
        public string AreaCode { get; set; }
        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }
        [DataMember(Name = "datetime")]
        public string DateTime { get; set; }
    }
}
