using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class DetailDemande
    {
        [Key]
        public int IdDd { get; set; }
        [ForeignKey("Demande")]
        public int IdDemande { get; set; }
        [ForeignKey("Equipement")]
        public int IdEquipement { get; set; }

    }
}
