using NK_DesktopUI_Library.Models;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfor(string token);
    }
}