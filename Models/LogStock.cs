using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class LogStock
    {
        [Key]
        public int IdLogStock { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public DateTime DateModification { get; set; }
        [Required]
        public int Quantite { get; set; }
        [ForeignKey("Fournisseur")]
        public int IdFournisseur { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
    }
}
