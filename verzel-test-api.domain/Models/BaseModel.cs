using System.ComponentModel.DataAnnotations;

namespace verzel_test_api.domain.Models
{
    public abstract class BaseModel
    { 
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
