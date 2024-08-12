using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Employe
    {
        [Key]
        public int IdEmploye { get; set; }
        [Required]
        public string Matricule { get; set; }
        [Required]
        public string NomEmp { get; set; }
        [Required]
        public string Departement { get; set; }
        public string Zone { get; set; }
        public string Shift { get; set; }
        [Required]
        public string Etat { get; set; }

        [ForeignKey("Position")]
        public int IdPosition { get; set; }
    }
}
