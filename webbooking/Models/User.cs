using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webbooking.Models
{
    public class User
    {
        public int id { get; set; }
        public List<Paller> pallers { get; set; } //mange til mange
        public List<TempPlates> tempPlates { get; set; } //mange til mange
    }
}