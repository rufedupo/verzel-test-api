using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace verzel_test_api.domain.ViewModels
{
    public class AddCarViewModel
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

        public IFormFile? Photo { get; set; }
    }
}
