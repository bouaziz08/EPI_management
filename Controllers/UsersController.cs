using HSE.Models.Auth;
using HSE.Repository;
using HSE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSE.Controllers
{
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
        [HttpPost]
        public  IActionResult Authenticate(string username, string password)
        {
            bool isAuthenticated = _ldapAuthentication.IsAuthenticated(username, password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }else
            {
                Tokens tokens = _jwtManagerRepository.CreateToken(username, "jklfds", "fr");
                return Ok(tokens);
            }
        }

    }
}
