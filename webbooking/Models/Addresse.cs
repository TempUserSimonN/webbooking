using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webbooking.Models
{
    public class Addresse
    {
        public int id { get; set; }
        public int nr { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string streat { get; set; }
        public string Contry { get; set; }
        public string postNumber { get; set; }
        public string city { get; set; }
        public int phoneNumber { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string openingsHours { get; set; }
        public string contakt { get; set; }
        public string miscellaneous { get; set; }
        public string notes { get; set; }
        public bool cMR { get; set; }
        public bool saveInAdresseBook { get; set; }
    }
}