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

        public DbSet<User> Users { get; set; }

        // OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User エンティティの設定
            modelBuilder.Entity<User>(entity =>
            {
                // 主キーの設定（Id のみを主キーとする）
                entity.HasKey(u => u.Id);

                // ユニークインデックスを設定
                entity.HasIndex(u => u.UserName)
                    .IsUnique();

                entity.HasIndex(u => u.UserEmail)
                    .IsUnique();

                // プロパティの制約を設定
                entity.Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.UserEmail)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}
