using System.Net;
using verzel_test_api.domain.Exceptions;
using verzel_test_api.domain.Interfaces.Repositories;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Models;
using verzel_test_api.domain.Responses;
using verzel_test_api.domain.Settings;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.business.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Login(LoginViewModel loginViewModel)
        {
            var user = await _userRepository.GetByEmailAndPassword(loginViewModel.Email, EncryptDecryptManager.Encrypt(loginViewModel.Password));
            if (user == null)
                throw new HttpException("Usuário ou senha inválida!", HttpStatusCode.NotFound);

            var token = _tokenService.GenerateToken(user);
            return new LoginResponse { 
                UserId = user.Id, 
                Token = token,
                ExpireToken = DateTime.UtcNow.AddHours(8)
            };
        }

        public async Task<RegisterResponse> Register(RegisterViewModel registerViewModel)
        {
            var user = await _userRepository.GetByEmail(registerViewModel.Email);
            if (user != null)
                throw new HttpException("Usuário já cadastrado no sistema!", HttpStatusCode.BadRequest);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = registerViewModel.Email,
                Name = registerViewModel.Name,
                Password = EncryptDecryptManager.Encrypt(registerViewModel.Password),
                Role = "admin",
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.Insert(newUser);

            return new RegisterResponse
            {
                Id = newUser.Id,
                Email = newUser.Email,
                Name = newUser.Name,
                CreatedAt = newUser.CreatedAt
            };
        }
    }
}
