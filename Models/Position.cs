using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Position
    {
        [Key]
        public int IdPosition { get; set; }
        public string NomPosition { get; set; }


    }
}
