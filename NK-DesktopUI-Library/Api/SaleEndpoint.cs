using NK_DesktopUI_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Api
{
    public class SaleEndpoint : ISaleEndpoint
    {
        private IAPIHelper _apiHelper;
        public SaleEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Sale", sale))
            {
                if (responseMessage.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }

        }
    }
}