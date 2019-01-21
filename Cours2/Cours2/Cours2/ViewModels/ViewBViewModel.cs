using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours2.ViewModels
{
	public class ViewBViewModel : ViewModelBase
	{

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ViewBViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "ViewB";
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            UserName = parameters["UserName"] as string;
            Password = parameters["Password"] as string;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            
        }
    }

}
