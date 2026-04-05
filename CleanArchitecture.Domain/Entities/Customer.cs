using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
