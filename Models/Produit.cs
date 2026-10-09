using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_REST_REVISION.Models
{
    [PrimaryKey("IdProduit")]
    [Table("produit")]


    public partial class Produit
    {

        [Key]
        [Column("idproduit")]
        public int IdProduit { get; set; }

        [Column("nomproduit")]
        public string? NomProduit { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("nomphoto")]
        public string? NomPhoto { get; set; }

        [Column("uriphoto")]
        public string? UriPhoto { get; set; }

        [Column("idtypeproduit")]
        public int IdTypeProduit { get; set; }

        [Column("idmarque")]
        public int IdMarque { get; set; }

        [ForeignKey("idtypeproduit")]
        [InverseProperty(nameof(TypeProduit.Produits))]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual TypeProduit? IdTypeProduitNavigation { get; set; } = null;

        [ForeignKey("idmarque")]
        [InverseProperty(nameof(Marque.Produits))]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Marque? IdMarqueNavigation { get; set; } = null;


        [Column("stockreel")]
        public int StockReel { get; set; }

        [Column("stockmin")]
        public int StockMin { get; set; }


        [Column("stockmax")]
        public int StockMax { get; set; }

    }
}
