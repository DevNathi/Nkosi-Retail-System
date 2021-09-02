    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NK_DesktopUI.EventModels;
using NK_DesktopUI_Library.Api;
using NK_DesktopUI_Library.Models;

namespace NK_DesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        ILoggedInUserModel _user;
        IAPIHelper _apiHelper;

       public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            //handles the event for all the viewmodels 
            _events = events;
            _salesVM = salesVM;
            _user = user;
            _apiHelper = apiHelper;

            _events.Subscribe(this);

            // opens up the LoginVM at start up
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }
                return output;
            }

        }
        //CLOSING THE APPLICATION
        public void ExitApplication()
        {
            TryClose();
        }
        public void LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            // opens up the LoginVM at start up
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
      
        }
    }
}
