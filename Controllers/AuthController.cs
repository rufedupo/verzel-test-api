﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.RegularExpressions;
using verzel_test_api.domain.Exceptions;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Responses;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                if (loginViewModel == null)
                {
                    return BadRequest();
                }
                var res = await _authService.Login(loginViewModel);
                return Ok(res);
            } 
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            } 
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterResponse>> RegisterAsync([FromBody] RegisterViewModel registerViewModel)
        {
            try
            {
                if (registerViewModel == null || registerViewModel.Name.IsNullOrEmpty() || registerViewModel.Email.IsNullOrEmpty() || registerViewModel.Password.IsNullOrEmpty())
                {
                    return BadRequest("Dados em branco");
                }

                if (!Regex.IsMatch(registerViewModel.Name, @"^(?!.*  )[A-Za-z ]+$"))
                {
                    return BadRequest("Nome inválido.");
                }

                if (!Regex.IsMatch(registerViewModel.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    return BadRequest("Email inválido");
                }

                if (registerViewModel.Password.Length < 6)
                {
                    return BadRequest("Senha precisa ser maior que 6 caracteres.");
                }

                var res = await _authService.Register(registerViewModel);
                return Ok(res);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
