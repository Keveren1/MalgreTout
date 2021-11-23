using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalgreTout.Models
{
    [Table("Udleveringssted")]
    public partial class Udleveringssted
    {
        [Key]
        [Required(ErrorMessage = "Enter Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
    }
}
    
   