using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BabyInfoDataAccess;


namespace BabyMonitor.Controllers
{
    public class BabyInfoController : ApiController
    {
        [HttpGet]
        [Route("getInfo")]
        public IEnumerable<Temp_Hum_Sound> Get()
        {
            using (BabyInfoEntities entities = new BabyInfoEntities())
            {
                return entities.Temp_Hum_Sound.ToList();
            }
        }

        [HttpGet]
        [Route("getInfo/{event_date}/{event_time}")]
        public Temp_Hum_Sound Get(string event_date, string event_time)
        {
            string request_date = event_date + " " + event_time;
            string s = "2011-03-21 13:26";
            DateTime this_date = DateTime.ParseExact(request_date, "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
            //Console.WriteLine(this_date);
            using (BabyInfoEntities entities = new BabyInfoEntities())
            {
                return entities.Temp_Hum_Sound.FirstOrDefault(e => e.event_date.Date == this_date.Date);
            }
        }
    }
}
