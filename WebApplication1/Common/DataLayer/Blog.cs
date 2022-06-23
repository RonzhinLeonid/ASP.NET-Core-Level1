using DataLayer.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
