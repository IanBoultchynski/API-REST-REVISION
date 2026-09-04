using API_REST_REVISION.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_Revision
{
    public partial class ProduitsDbContext : DbContext
    {
        public ProduitsDbContext()
        {
        }

        public ProduitsDbContext(DbContextOptions<ProduitsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<TypeProduit> TypeProduits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=ProduitsDB;uid=postgres;password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}