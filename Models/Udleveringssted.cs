using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalgreTout.Models
{
    [Table("Udleveringssted")]
    public partial class Udleveringssted
    {
        [Key]
        public int Id { get; set; }
        
       [Required]
       [StringLength(50, ErrorMessage = "Må ikke indeholde mere end 25 tegn")]
       public string Virksomhed { get; set; }
       
        [Required]
        [StringLength(50, ErrorMessage = "Må ikke indeholde mere end 25 tegn")]
        public string Adresse { get; set; }
    }
}
