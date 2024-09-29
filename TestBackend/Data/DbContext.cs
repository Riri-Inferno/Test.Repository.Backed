using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TestBackend.Models.Entities;
using System.ComponentModel.DataAnnotations;

// 現在はReadとWriteで分けてない
namespace TestBackend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
    }
}
