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
        [Required(ErrorMessage = "Indtast Navn")]
        public string Person { get; set; }
        [Required(ErrorMessage = "Indtast Tlf")]
        public int TLF { get; set; }
        [Required(ErrorMessage = "Indtast Mail")]
        public string Mail { get; set; }
    }
}
