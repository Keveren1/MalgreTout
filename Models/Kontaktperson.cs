using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Phone]
        //[MinLength(8, ErrorMessage = "Skal minimum indeholde 8 cifre")]
        public int TLF { get; set; }

        [Required]
        [EmailAddress]
        //[RegularExpression(@"^[a-åA-Å0-9_.+-]+@[a-åA-Å0-9-]+\.[a-åA-Å0-9-.]+$",
        //ErrorMessage = "Email skal indeholde @")]
        public string Mail { get; set; }
    }
}
