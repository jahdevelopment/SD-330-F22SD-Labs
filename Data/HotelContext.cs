using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Labs.Models;

namespace SD_330_F22SD_Labs.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext (DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<SD_330_F22SD_Labs.Models.Client> Client { get; set; } = default!;

        public DbSet<SD_330_F22SD_Labs.Models.Room>? Room { get; set; }
    }
}
