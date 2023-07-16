using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verzel_test_api.domain.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        public string? Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<Car> Cars { get; } = new List<Car>();
    }
}