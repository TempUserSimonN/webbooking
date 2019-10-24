using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webbooking.Models
{
    public class TempPlates
    {
        public int id { get; set; }
        public string navn { get; set; }
        //s Addresse oplysninger
        public string ordergiver { get; set; }
        public string oKontakt { get; set; }
        public string afsender { get; set; }
        public string modtager { get; set; }
        public string aKontakt { get; set; }
        //s Reference Dato
        public string reference { get; set; }
        public string fragtBrevsn { get; set; }
        public DateTime afhDatoTid { get; set; }
        public string afhKommentar { get; set; }
        public DateTime forvLevDatoTid { get; set; }
        public string levKommentar { get; set; }
        //s Info
        public string infoTilTransprotør { get; set; }
        public string infoTilFragtbrev { get; set; }
        //s Godslinjer
        public List<Godslinjer> godslinjers { get; set; } //en til mange
    }
}