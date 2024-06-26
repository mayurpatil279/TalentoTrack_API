
using Microsoft.AspNetCore.Mvc;
using TalentoTrack.Common.DTOs.Account;
using TalentoTrack.Common.Services;
using TalentoTrack.Dao.Db;

namespace TalentoTrack_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountServices _accountServices;

        public AccountController(ILogger<AccountController> logger, IAccountServices accountServices)
        {
            _logger = logger;
            _accountServices = accountServices;
        }

        [HttpPost(Name = "Login")]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var response = await _accountServices.VerifyLoginDetails(request);
            return response;
        }
    }
}
