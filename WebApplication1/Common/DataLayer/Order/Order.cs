using DataLayer.Base;
using DataLayer.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Order
{
    public class Order : Entity
    {
        [Required]
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Phone { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = null!;

        public string? Description { get; set; }

        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        [NotMapped]
        public decimal TotalPrice => Items.Sum(item => item.TotalItemPrice);
    }
}
