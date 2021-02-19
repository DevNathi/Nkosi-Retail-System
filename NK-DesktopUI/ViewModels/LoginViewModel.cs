using Caliburn.Micro;
using NK_DesktopUI.Helpers;
using NK_DesktopUI_Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _useName;
        private string _password;
        private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string UserName
        {
            get { return _useName; }
            set
            { 
                _useName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }

        }


        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }


        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;

               if(ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
            
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
                
            }
        }



        public bool CanLogin
        {
            get
            {
                bool output = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }


        public async Task Login()
        {
            try 
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);

                //User infor from a Loggedinuser 
                await _apiHelper.GetLoggedInUserInfor(result.Access_Token);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }

        }

    }
}
