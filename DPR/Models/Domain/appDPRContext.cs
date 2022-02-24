using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Models.Domain
{
    public class appDPRContext : DbContext
    {
        public appDPRContext(DbContextOptions<appDPRContext> options) : base(options)
        {
            
        }

        public DbSet<CarOwner> CarOwners { get; set; }

        public DbSet<FillingStationOwner> FillingStationOwners { get; set; }

    }
}
