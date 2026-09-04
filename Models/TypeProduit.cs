using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_REST_REVISION.Models
{

    [PrimaryKey("IdTypeProduit")]
    [Table("typdeproduit")]

    public partial class TypeProduit
    {
        [Key]
        [Column("idtypeproduit")]
        public int IdTypeProduit { get; set; }


        [Column("nomtypeproduit")]
        public string? NomTypeProduit { get; set; }


        [InverseProperty(nameof(Produit.IdTypeProduitNavigation))]
        public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();



    }
}


