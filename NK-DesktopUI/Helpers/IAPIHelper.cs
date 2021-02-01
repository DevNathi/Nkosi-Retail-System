using NK_DesktopUI.Models;
using System.Threading.Tasks;

namespace NK_DesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}