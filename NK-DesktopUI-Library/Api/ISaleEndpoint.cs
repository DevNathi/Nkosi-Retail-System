using NK_DesktopUI_Library.Models;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}