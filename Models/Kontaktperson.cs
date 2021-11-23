using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalgreTout.Models
{
    [Table("Kontaktperson")]
    public partial class Kontaktperson
    {
        [Key]
        [Required(ErrorMessage = "Enter Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Person { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public int Tlf { get; set; }
        
        [Required(ErrorMessage = "Enter Mail")]
        public string Mail { get; set; }
        
    }
}