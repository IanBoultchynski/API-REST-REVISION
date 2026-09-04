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
            modelBuilder.Entity<Marque>(entity =>
            {
                entity.HasKey(e => e.IdMarque).HasName("pk_marque");
            });

            modelBuilder.Entity<TypeProduit>(entity =>
            {
                entity.HasKey(e => e.IdTypeProduit).HasName("pk_typeproduit");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.IdProduit).HasName("pk_produit");

                entity.HasOne(d => d.IdMarqueNavigation)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.IdMarque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produit_marque");

                entity.HasOne(d => d.IdTypeProduitNavigation)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.IdTypeProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produit_typeproduit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}