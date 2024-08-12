using System.ComponentModel.DataAnnotations;

namespace HSE.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        [Required]
        public string NomRole { get; set; }

    }
}
