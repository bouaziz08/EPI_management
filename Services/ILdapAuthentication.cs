namespace HSE.Services
{
    public interface ILdapAuthentication
    {
        bool IsAuthenticated(string username, string password);
        string[] GetUserInfo(string username);
        string GetUsernameByDisplayName(string displayName);
        string GetManagerCN(string managerFullField);

    }
}
