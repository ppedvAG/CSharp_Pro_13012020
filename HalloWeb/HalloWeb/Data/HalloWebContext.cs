using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HalloWeb.Models;

namespace HalloWeb.Data
{
    public class HalloWebContext : DbContext
    {
        public HalloWebContext (DbContextOptions<HalloWebContext> options)
            : base(options)
        {
   
        }

        public DbSet<HalloWeb.Models.Games> Games { get; set; }
    }
}
