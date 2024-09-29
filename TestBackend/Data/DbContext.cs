using Microsoft.EntityFrameworkCore;
using TestBackend.Models.Entities;

// 現在はReadとWriteで分けてない
namespace TestBackend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
