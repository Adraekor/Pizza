using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Cours2.ViewModels
{
    public class AppliMenuViewModel : ViewModelBase
	{
        public DelegateCommand DelegateCarte { get; private set; }
        public DelegateCommand DelegateIngredient { get; private set; }

        public AppliMenuViewModel(INavigationService navigationService):base(navigationService)
        {
            DelegateCarte = new DelegateCommand(NavToCarte);
            DelegateIngredient = new DelegateCommand(NavToIngredients);
        }

        private void NavToCarte()
        {
            NavigationService.NavigateAsync("NavigationPage/ViewA");
        }

        private void NavToIngredients()
        {
            NavigationService.NavigateAsync("NavigationPage/Ingredient");
        }
	}
}
