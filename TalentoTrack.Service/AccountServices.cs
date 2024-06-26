using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentoTrack.Common.DTOs.Account;
using TalentoTrack.Common.Repoitories;
using TalentoTrack.Common.Services;

namespace TalentoTrack.Service
{
    public class AccountServices : IAccountServices
    {
        public readonly IAccountRepoitories _accountRepoitories;

        public AccountServices(IAccountRepoitories accountRepoitories)
        {
            _accountRepoitories = accountRepoitories;
        }
        public async Task<LoginResponse> VerifyLoginDetails(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                var dbUser = await _accountRepoitories.GetLoginDetails(request.Username!, request.Password!);
                if (dbUser == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Invalide Credentials";
                }
                else
                {
                    response.Success = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw;
            }
        }
    }
}
