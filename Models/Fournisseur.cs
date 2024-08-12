using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Fournisseur
    {
        [Key]
        public int IdFournisseur { get; set; }
        [Required]
        public string NomFournisseur { get; set; }
    }
}
