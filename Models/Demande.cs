using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Demande
    {
        [Key]
        public int IdDemande { get; set; }
        [Required]
        public string MatriculeDemandeur { get; set; }
        [Required]
        public string nomequipement { get; set; }
        [Required]
        public int Quantite { get; set; }
        [Required]
        public string TypeDeDemande { get; set; }
        [Required]
        public DateTime DateDeDemande { get; set; }
        public string Commentaire { get; set; }
        [Required]
        public string Etat { get; set; }
        [Required]
        public int pointure { get; set; }
        public string Feedback { get; set; }

        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
        [ForeignKey("Employe")]
        public int IdEmploye { get; set; }
    }
}
