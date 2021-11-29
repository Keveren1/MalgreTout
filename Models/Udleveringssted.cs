using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalgreTout.Models
{
    public partial class Udleveringssted
    {
        [Key]
        public int Id { get; set; }
       [Required]
       [StringLength(25, ErrorMessage = "Navnet på virksomheden må maks indeholde 25 tegn")]
        public string Virksomhed { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Adressen må maks indeholde 50 tegn")]
        public string Adresse { get; set; }
    }
}
