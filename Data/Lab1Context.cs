using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Labs.Models;

namespace SD_330_F22SD_Labs.Data
{
    public class Lab1Context : DbContext
    {
        public Lab1Context (DbContextOptions<Lab1Context> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; } = default!;

        public DbSet<Address> Address { get; set; } = default!;
    }
}
