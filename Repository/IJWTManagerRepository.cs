using HSE.Models.Auth;

namespace HSE.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens CreateToken(string username, string role, string preferredLanguage);
    }
}
