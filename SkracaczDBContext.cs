using Microsoft.EntityFrameworkCore;
using skracacz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skracacz
{
    public class SkracaczDBContext : DbContext
    {
        public SkracaczDBContext(DbContextOptions<SkracaczDBContext> options) : base(options)
        {

        }
        public DbSet<Link> Links { get; set; }

    }
}
