using DataLayer.Base;
using DataLayer.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Index(nameof(Name), IsUnique = false)]
    public class Blog : NamedEntity
    {
        [Required]
        public string User { get; set; } = null!;
        public DateTime Date { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
