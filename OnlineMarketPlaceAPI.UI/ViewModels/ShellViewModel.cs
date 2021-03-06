using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarketPlaceAPI.UI.Views;
using Caliburn.Micro;

namespace OnlineMarketPlaceAPI.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        LoginViewModel _loginVM;
        public ShellViewModel(LoginViewModel loginvm)
        {
            _loginVM = loginvm;
            ActivateItem(_loginVM);
        }
    }
}
