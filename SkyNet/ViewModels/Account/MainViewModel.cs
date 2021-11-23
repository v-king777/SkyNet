using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.ViewModels.Account
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            RegisterView = new RegisterViewModel();
            LoginView = new LoginViewModel();
        }

        public RegisterViewModel RegisterView { get; set; }

        public LoginViewModel LoginView { get; set; }
    }
}
