using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Equipement
    {
        [Key]
        public int IdEquipement { get; set; }
        [Required]
        public string NomEq { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public string Norme { get; set; }
        public string FournisseurPrincipale { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string TypeEquip { get; set; }
        [Required]
        public int pointure { get; set; }
        [ForeignKey("Subcategory")]
        public int IdSubcategory { get; set; }
    }
}
