using verzel_test_api.domain.Interfaces.Repositories;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Responses;
using verzel_test_api.domain.Settings;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetInfo(Guid guid)
        {
            var user = await _userRepository.GetById(guid);
            return new UserResponse
            {
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<bool> SetPassword(Guid guid, string newPassword)
        {
            var user = await _userRepository.GetById(guid);
            user.Password = EncryptDecryptManager.Encrypt(newPassword);
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.Update(user);
            return true;
        }
    }
}
