using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NK_DesktopUI.EventModels;

namespace NK_DesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;

       public ShellViewModel(IEventAggregator events, SalesViewModel salesVM)
        {
            //handles the event for all the viewmodels 
            _events = events;
            _salesVM = salesVM;

            _events.Subscribe(this);

            // opens up the LoginVM at start up
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
      
        }
    }
}
