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

            // Seeding data
            modelBuilder.Entity<Marque>().HasData(
                new Marque { IdMarque = 1, NomMarque = "Apple" },
                new Marque { IdMarque = 2, NomMarque = "Samsung" },
                new Marque { IdMarque = 3, NomMarque = "Xiaomi" }
            );

            modelBuilder.Entity<TypeProduit>().HasData(
                new TypeProduit { IdTypeProduit = 1, NomTypeProduit = "Smartphone" },
                new TypeProduit { IdTypeProduit = 2, NomTypeProduit = "Tablette" },
                new TypeProduit { IdTypeProduit = 3, NomTypeProduit = "TV" }
            );

            modelBuilder.Entity<Produit>().HasData(
                new { IdProduit = 1, NomProduit = "iPhone 12", IdMarque = 1, idmarque = 1, IdTypeProduit = 1, idtypeproduit = 1, Description = "Le dernier iPhone", StockReel = 50, StockMin = 10, StockMax = 100 },
                new { IdProduit = 2, NomProduit = "Galaxy S22", IdMarque = 2, idmarque = 2, IdTypeProduit = 1, idtypeproduit = 1, Description = "Le dernier Samsung", StockReel = 5, StockMin = 10, StockMax = 100 },
                new { IdProduit = 3, NomProduit = "Xiaomi BETA", IdMarque = 3, idmarque = 3, IdTypeProduit = 3, idtypeproduit = 3, Description = "TV OLED 4K", StockReel = 20, StockMin = 5, StockMax = 50 }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}