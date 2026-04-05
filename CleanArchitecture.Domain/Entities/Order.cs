using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
