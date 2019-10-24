using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoneScaled.Models
{
    public class Godslinjer
    {
        public int id { get; set; }
        public string mærkeOgMr { get; set; }
        public int antal { get; set; }
        public int art { get; set; } = 0;
        public string inhold { get; set; }
        public string bruttovægt { get; set; }
        public string nettoVægt { get; set; }
        public string volume { get; set; }
        public string volumeKode { get; set; }
        public string temperatur { get; set; }
        public string emballageType { get; set; }
        public string antalAfEmballage { get; set; }
        public string afhentningsadresse { get; set; }
        public string leveringsadresse { get; set; }
        public string bundPll { get; set; }
        public string bytteEmb { get; set; }
        public int bytteEmbArt { get; set; } = 1;
        public string kolliAntal { get; set; }
        public int kolliArt { get; set; } = 2;
    }
}