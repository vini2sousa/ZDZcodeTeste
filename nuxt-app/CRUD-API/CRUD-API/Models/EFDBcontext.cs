using Microsoft.EntityFrameworkCore;
using CRUD_API.Models;

namespace APITeste.Models
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }

        public DbSet<Infos> Infos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Infos>()
                .HasKey(i => i.Id);
        }
    }
}
