using HSE.Models.Auth;
using HSE.Repository;
using HSE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LdapAuthentication _ldapAuthentication;
        private readonly IJWTManagerRepository _jwtManagerRepository;
        public UsersController(LdapAuthentication ldapAuthentication, IJWTManagerRepository jWTManagerRepository)
        {
            _ldapAuthentication = ldapAuthentication;
            _jwtManagerRepository = jWTManagerRepository;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public  IActionResult Authenticate(AuthRequest authRequest)
        {
            bool isAuthenticated = _ldapAuthentication.IsAuthenticated(authRequest.username, authRequest.password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }else
            {
                Tokens tokens = _jwtManagerRepository.CreateToken(authRequest.username, "jklfds", "fr");
                return Ok(tokens);
            }
        }

    }
}
