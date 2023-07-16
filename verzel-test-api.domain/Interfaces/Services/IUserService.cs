using verzel_test_api.domain.Responses;

namespace verzel_test_api.domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetInfo(Guid guid);

        Task<bool> SetPassword(Guid guid, string newPassword);
    }
}
