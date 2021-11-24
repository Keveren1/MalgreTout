﻿using System;
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
        [StringLength(90)]
        public string Virksomhed { get; set; }
        [Required]
        [StringLength(90)]
        public string Adresse { get; set; }
    }
}
