using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHealthcare.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;

namespace Ehealthcare.Api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IBaseRepository<User> UserRepository;
        public AccountController(IBaseRepository<User> UserRepo)
        {
            UserRepository = UserRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser(string email, string password)
        {
            if (this.ModelState.IsValid)
            {
                AuthService authService = new AuthService(UserRepository);
                AuthUserModel response = await authService.Authenticate(email, password).ConfigureAwait(true);
                if (response != null)
                {
                    return this.Ok(response);
                }
                else
                {
                    return this.BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
                }
            }

            return this.BadRequest();
        }
    }
}
