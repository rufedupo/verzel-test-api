using verzel_test_api.domain.Models;

namespace verzel_test_api.domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
