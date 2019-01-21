using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours2.ViewModels
{
	public class ViewAViewModel : ViewModelBase
    {

        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand CommandMovePage { get; private set; }

        public ViewAViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "ViewA";
            CommandMovePage = new DelegateCommand(MovePage, CanMove).ObservesProperty(() => UserName).ObservesProperty(() => Password);
        }

        private bool CanMove()
        {
            if (UserName == "")
                return false;

            if (Password == "")
                return false;

            return true;
        }

        private void MovePage()
        {
            var navigationParam = new NavigationParameters();
            navigationParam.Add("UserName", UserName);
            navigationParam.Add("Password", Password);

            NavigationService.NavigateAsync("ViewB", navigationParam);
        }

    }
}
