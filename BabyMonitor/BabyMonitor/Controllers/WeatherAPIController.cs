using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BabyMonitor.Controllers
{
    public class WeatherAPIController : ApiController
    {
        // You need [HttpGet] to do proper mapping
        [HttpGet]
        [Route("detectIP")]
        public string detectIP()
        {
            var serviceURL = "http://api.ipify.org/";
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create(serviceURL);
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "plain/text";
            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            Stream receiveStream = serviceResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode, true);
            string serviceResult = readStream.ReadToEnd();

            return serviceResult;
        }

        [HttpGet]
        [Route("convertIP")]
        public string convertIP()
        {
            string my_ip = detectIP();
            var serviceURL = "http://ip-api.com/json/" + my_ip;
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create(serviceURL);
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "application/json";
            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            Stream receiveStream = serviceResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode, true);
            string serviceResult = readStream.ReadToEnd();
            var json = JObject.Parse(serviceResult);

            return json.SelectToken("zip").ToString();
        }

        [HttpGet]
        [Route("getWeather")]
        public string getWeatherbyZip()
        {
            string zipCode = convertIP();
            var serviceURL = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + "&appid=7825191365c540d4cc27a1c4f1f0627d";
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create(serviceURL);
            serviceRequest.Method = "GET";
            serviceRequest.ContentLength = 0;
            serviceRequest.ContentType = "application/json";
            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();
            Stream receiveStream = serviceResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode, true);
            //var result = JsonConvert.DeserializeObject(readStream.ReadToEnd());
            string serviceResult = readStream.ReadToEnd();
            var json = JObject.Parse(serviceResult);

            //json.SelectToken(element).ToString()
            return serviceResult;
        }
    }
}
