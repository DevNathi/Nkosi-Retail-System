using NK_DesktopUI_Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductsModel>> GetAllProducts();
    }
}