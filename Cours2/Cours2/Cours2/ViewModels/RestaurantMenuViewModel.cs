using Cours2.Model;
using Cours2.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Cours2.ViewModels
{
	public class RestaurantMenuViewModel : ViewModelBase
	{

        private ObservableCollection<Pizza> _pizzas;
        public ObservableCollection<Pizza> Pizzas
        {
            get { return _pizzas; }
            set { SetProperty(ref _pizzas, value); }
        }

        public DelegateCommand CommandNewPizza { get; private set; }
        public DelegateCommand<Pizza> CommandPizzaDetails { get; private set; }

        private IPizzaService _pizzaService;

        public RestaurantMenuViewModel(INavigationService navigationService, IPizzaService pizzaService)
            : base(navigationService)
        {
            _pizzaService = pizzaService;

            Title = "Restaurant menu";
            Pizzas = new ObservableCollection<Pizza>();
            CommandNewPizza = new DelegateCommand(NewPizza);
            CommandPizzaDetails = new DelegateCommand<Pizza>(PizzaDetails);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //Pizzas = new ObservableCollection<Pizza>(PizzaService.Instance.GetPizzas());
            Pizzas = new ObservableCollection<Pizza>(_pizzaService.GetPizzas());
        }

        private void NewPizza()
        {
            NavigationService.NavigateAsync("NewPizza");
        }

        private void PizzaDetails(Pizza pizzaSelected)
        {
            var navigationParam = new NavigationParameters();
            navigationParam.Add("Pizza", pizzaSelected);

            NavigationService.NavigateAsync("PizzaDetails", navigationParam);
        }


    }
}
