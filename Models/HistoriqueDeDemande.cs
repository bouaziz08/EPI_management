using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class HistoriqueDeDemande
    {
        [Key]
        public int IdLog { get; set; }
        [Required]
        public string Etat { get; set; }
        [Required]
        public string nom_equip { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public DateTime DateModification { get; set; }
        [ForeignKey("Employe")]
        public int IdUtilisateur { get; set; }
        [ForeignKey("Demande")]
        public int IdDemande { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdDemandeur { get; set; }
    }
}
