using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_REST_REVISION.Models
{

    [PrimaryKey("IdMarque")]
    [Table("marque")]
    public partial class Marque
    {
        [Key]
        [Column("idmarque")]
        public int IdMarque { get; set; }

        [Column("nommarque")]
        public string? NomMarque { get; set; }

        [InverseProperty(nameof(Produit.IdMarqueNavigation))]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();

    }
}
