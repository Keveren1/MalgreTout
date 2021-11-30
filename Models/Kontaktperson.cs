using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalgreTout.Models
{
    public partial class Kontaktperson
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
        [EmailAddress]
        public string Mail { get; set; }
    }
}
