using NK_DesktopUI_Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient { get; set; }
        private ILoggedInUserModel _loggedInUserModel;

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitialzeClient();
            _loggedInUserModel = loggedInUser;
        }
        private void InitialzeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),

            });

            using (HttpResponseMessage responseMessage = await apiClient.PostAsync("/Token", data))
            {
                if (responseMessage.IsSuccessStatusCode)
                {

                    var result = await responseMessage.Content. ReadAsAsync <AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }

            }
        }

        public async Task GetLoggedInUserInfor(string token)
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
            apiClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");

            using (HttpResponseMessage responseMessage = await apiClient.GetAsync("/api/User"))
            {
                if(responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUserModel.Token = token;
                    _loggedInUserModel.AuthUserId = result.AuthUserId;
                    _loggedInUserModel.FirstName = result.FirstName;
                    _loggedInUserModel.LastName = result.LastName;
                    _loggedInUserModel.EmailAddress = result.EmailAddress;
                    _loggedInUserModel.CreateDate = result.CreateDate;
                   

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
