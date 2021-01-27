﻿using Caliburn.Micro;
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


        public void Login(string userName, string password)
        {
            Console.WriteLine();
        }

    }
}