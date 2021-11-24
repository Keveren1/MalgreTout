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
        [StringLength(30)]
        public string Person { get; set; }
        public int TLF { get; set; }
        [Required]
        [StringLength(30)]
        public string Mail { get; set; }
    }
}
