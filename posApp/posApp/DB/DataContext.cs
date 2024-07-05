using Microsoft.EntityFrameworkCore;
using posApp.Models;

namespace posApp.DB
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
       
        public DbSet<Transaction> transactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
