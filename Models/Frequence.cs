using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Frequence
    {
        [Key]
        public int IdFrequence { get; set; }
        [ForeignKey("Position")]
        public int IdPosition { get; set; }
        [ForeignKey("Subcategory")]
        public int IdSubcategorie { get; set; }
        [Required]
        public string NomSubcategorie { get; set; }
        [Required]
        public string FrequenceChangement { get; set; }
    }
}
