using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalgreTout.Models
{
    [Table("Kontaktperson")]
    public class Kontaktperson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Navn må maks indeholde 50 tegn")]
        public string Person { get; set; }

        [Required]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "Skal indeholde 8 tegn")]
        public int Tlf { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,9}*$")]


        public string Mail { get; set; }
    }
}



/*@"^[a-zA-Z0-9._+-]+@"@")[a-zA-Z0-9.-]+\.[a-zA-Z]{2,9}$>*/