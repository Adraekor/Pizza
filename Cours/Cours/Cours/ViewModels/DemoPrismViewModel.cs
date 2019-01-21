using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours.ViewModels
{
	public class DemoPrismViewModel : BindableBase
	{

        private string _testBindingText = "Coucou";
        public string TestBindingText
        {
            get { return _testBindingText; }
            set { SetProperty(ref _testBindingText, value); }
        }

        public DelegateCommand<object> TestCommand{ get; private set; }

        public DemoPrismViewModel()
        {
            TestCommand = new DelegateCommand<object>(ChangeMyText);
        }

        private void ChangeMyText(object parameter)
        {
            TestBindingText = (string)parameter;
        }
    }
}
