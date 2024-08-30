using System.ComponentModel.DataAnnotations.Schema;

namespace HSE.NewFolder
{
    public class AddStockDTO
    {
        public int IdEquipement { get; set; }
        public int QuantiteEntrer { get; set; }
    }
}
