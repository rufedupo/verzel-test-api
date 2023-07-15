using verzel_test_api.domain.Responses;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginViewModel loginViewModel);

        Task<RegisterResponse> Register(RegisterViewModel registerViewModel);
    }
}
