using TaskManager.Api.Models;

namespace TaskManager.Api.Services
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
        User? GetUser(string username);
    }
}