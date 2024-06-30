using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace posApp 
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }

        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
