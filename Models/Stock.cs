using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Stock
    {
        [Key]
        public int IdStock { get; set; }
        [Required]
        public int StockActuelle { get; set; }
        [Required]
        public int StockSecurite { get; set; }
        [Required]
        public int QuantiteEntrer { get; set; }
        [Required]
        public int QuantiteSortie { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Equipement")]
        public int IdEquipement { get; set; }
        [ForeignKey("Fournisseur")]
        public int IdFournisseur { get; set; }
    }
}
