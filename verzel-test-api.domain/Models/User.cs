using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verzel_test_api.domain.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        public string? Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}