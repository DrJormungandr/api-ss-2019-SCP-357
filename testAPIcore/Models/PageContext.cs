using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace testAPIcore.Models
{
    public class PageContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public PageContext(DbContextOptions<PageContext> options)
            : base(options)
            {
                Database.EnsureCreated();
            }
    }

}
