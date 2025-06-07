using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class ApplicationDBContext :  IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        // --------------------------
        public DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categorys { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }

}
