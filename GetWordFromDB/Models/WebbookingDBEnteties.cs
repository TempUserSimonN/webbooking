using System;
using System.Collections.Generic;
using System.Text;
using NoneScaled.Models;

namespace NoneScaled.Models
    {
        using System;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity;
        using System.Linq;

    public partial class WebbookingDBEnteties : DbContext
        {
            public WebbookingDBEnteties(string baseString) : base(baseString)
            {
            }
            public virtual DbSet<User> user { get; set; }
            public virtual DbSet<Addresse> addresse { get; set; }
            public virtual DbSet<Paller> paller { get; set; }
            public virtual DbSet<TempPlates> tempPlates { get; set; }
            public virtual DbSet<Godslinjer> godslinjer { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
          //     modelBuilder.Entity<User>()
          //         .Property(e => e.pallers)
          //         .IsUnicode(false);
          //
          //     modelBuilder.Entity<Godslinjer>()
          //         .Property(e => e.art)
          //         .IsUnicode(false);
            }
        }
    }
