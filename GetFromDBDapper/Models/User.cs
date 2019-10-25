using NoneScaled.Models;
using System;
using System.Collections.Generic;

namespace NoneScaled.Models
{
    public partial class User
    {
        public int id { get; set; }
        public string vertion { get; set; }
        public int? pallers { get; set; } //mange til mange
        public int? tempPlates { get; set; } //mange til mange
    }
}