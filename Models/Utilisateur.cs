using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        [Required]
        public string Matricule { get; set; }
        [Required]
        public string NomU { get; set; }
        [Required]
        public string Gmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Departement { get; set; }
        [Required]
        public string Etat { get; set; }
        public string Zone { get; set; }
        [Required]
        public string Shift { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }
    }
}
