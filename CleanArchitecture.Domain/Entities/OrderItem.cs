
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public string productName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

    }
}
