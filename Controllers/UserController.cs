using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using verzel_test_api.domain.Exceptions;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Responses;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get-info")]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetInfoAsync()
        {
            try
            {
                Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
                var res = await _userService.GetInfo(userId);
                return Ok(res);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-password/{newPassword}")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdatePassword(string newPassword)
        {
            try
            {
                Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
                var res = await _userService.SetPassword(userId, newPassword);
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
