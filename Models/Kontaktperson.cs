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
        [RegularExpression(@"^[ÆØÅæøåa-zA-Z0-9._+-]+@[ÆØÅæøåa-zA-Z0-9.-]+\.[ÆØÅæøåa-zA-Z]{2,9}$", ErrorMessage ="Forkert mail format")]
        public string Mail { get; set; }
    }
}
