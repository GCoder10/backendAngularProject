using Microsoft.EntityFrameworkCore;
using Projekt.API.Models;

namespace Projekt.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Worker> workers { get; set; }
        
    }
}