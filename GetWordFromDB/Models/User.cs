using NoneScaled.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NoneScaled.Models
{
    [Table("bookingUser")]
    public partial class User
    {
        public int id { get; set; }
        public string vertion { get; set; }
        public int? pallers { get; set; } //mange til mange
        public int? tempPlates { get; set; } //mange til mange
    }
}