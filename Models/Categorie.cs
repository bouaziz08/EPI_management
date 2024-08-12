using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        [Required]
        public string NomCategorie { get; set; }
    }
}
