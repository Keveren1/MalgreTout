using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalgreTout.Models

{
    public partial class Postnumre
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Skal indeholde 4 tegn")]
        public int Postnr { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Må ikke indeholde mere ned 50 tegn")]
        public string Bynavn { get; set; }
    }
}