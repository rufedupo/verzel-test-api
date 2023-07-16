using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verzel_test_api.domain.Models
{
    [Table("Cars")]
    public class Car : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Km { get; set; }

        [Required]
        public decimal Price { get; set; }

        public byte[]? Photo { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; } 
    }
}
