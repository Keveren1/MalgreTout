using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalgreTout.Models
{
    public partial class NewAllUdleveringssted
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Navn må ikke indeholde mere end 50 tegn")]
        public string Person { get; set; }
        [Required]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "Skal indeholde 8 tegn")]
        public int Tlf { get; set; }
        [Required]
        [RegularExpression(@"^[ÆØÅæøåa-zA-Z0-9._+-]+@[ÆØÅæøåa-zA-Z0-9.-]+\.[ÆØÅæøåa-zA-Z]{2,9}$", ErrorMessage ="Forkert mail format")]
        public string Mail { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Må ikke indeholde mere end 25 tegn")]
        public string Virksomhed { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Må ikke indeholde mere end 25 tegn")]
        public string Adresse { get; set; }
        [Required]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Skal indeholde 4 tegn")]
        public int Postnr { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Må ikke indeholde mere ned 50 tegn")]
        public string Bynavn { get; set; }
    }
}
