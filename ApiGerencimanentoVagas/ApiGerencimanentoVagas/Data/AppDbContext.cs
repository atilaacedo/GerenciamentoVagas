using ApiGerencimanentoVagas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGerencimanentoVagas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<VagaModel> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VagaModel>()
            .Property(v => v.Created_at)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<VagaModel>()
                .Property(v => v.Updated_at)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<VagaModel>()
                .Property(v => v.Status)
                .HasConversion<string>();

            modelBuilder.Entity<VagaModel>()
                .ToTable(tb => tb.HasTrigger("UpdateVagaUpdatedAt"));
        }
    }
}
