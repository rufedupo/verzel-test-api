using System.ComponentModel.DataAnnotations;

namespace verzel_test_api.domain.Responses
{
    public class CarResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Age { get; set; }

        public int Km { get; set; }

        public decimal Price { get; set; }

        public byte[] Photo { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
