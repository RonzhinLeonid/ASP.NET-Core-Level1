using DataLayer.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Orders
{
    public class OrderItem : Entity
    {
        [Required]
        public Product Product { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public Order Order { get; set; } = null!;

        [NotMapped]
        public decimal TotalItemPrice => Price * Quantity;
    }
}
