using NK_DesktopUI_Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfor(string token);

        void LogOffUser();
    }
}