using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Subcategory
    {
        [Key]
        public int IdSubcategory { get; set; }
        [Required]
        public string NomSubcategory { get; set; }
        [ForeignKey("Categorie")]
        public int IdCategorie { get; set; }
    }
}
