using System.ComponentModel.DataAnnotations;

namespace verzel_test_api.domain.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string NewPassword { get; set; }
    }
}
