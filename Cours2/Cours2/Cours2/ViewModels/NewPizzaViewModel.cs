using Cours2.Model;
using Cours2.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours2.ViewModels
{
	public class NewPizzaViewModel : ViewModelBase
	{

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _price = "";
        public string Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private string _desc = "";
        public string Desc
        {
            get { return _desc; }
            set { SetProperty(ref _desc, value); }
        }

        // Pizza ingredients

        private Ingredient _baseIngredient;
        public Ingredient BaseIngredient
        {
            get { return _baseIngredient; }
            set { SetProperty(ref _baseIngredient, value); }
        }

        private List<Ingredient> _listIngredientsInPizza;
        public List<Ingredient> ListIngredientsInPizza
        {
            get { return _listIngredientsInPizza; }
            set { SetProperty(ref _listIngredientsInPizza, value); }
        }

        // Ingredients to choose lists

        private List<Ingredient> _listBaseIngredients;
        public List<Ingredient> ListBaseIngredients
        {
            get { return _listBaseIngredients; }
            set { SetProperty(ref _listBaseIngredients, value); }
        }

        private List<Ingredient> _listIngredients;
        public List<Ingredient> ListIngredients
        {
            get { return _listIngredients; }
            set { SetProperty(ref _listIngredients, value); }
        }

        // Display related
        // This is a bad way to do this, due to the limitation of forms / no using converters to keep it simple

        private Ingredient _selectedIngredientToAdd;
        public Ingredient SelectedIngredientToAdd
        {
            get { return _selectedIngredientToAdd; }
            set { SetProperty(ref _selectedIngredientToAdd, value); AddIngredient(value); }
        }

        private string _listSelectedIngredientsToDisplay = "";
        public string ListSelectedIngredientsToDisplay
        {
            get { return _listSelectedIngredientsToDisplay; }
            set { SetProperty(ref _listSelectedIngredientsToDisplay, value); }
        }


        public DelegateCommand CommandAddPizza { get; private set; }

        private IPizzaService _pizzaService;
        private IIngredientService _ingredientService;

        public NewPizzaViewModel(INavigationService navigationService, IPizzaService pizzaService, IIngredientService ingredientService)
            : base(navigationService)
        {
            _pizzaService = pizzaService;
            _ingredientService = ingredientService;

            Title = "New Pizza";

            //ListBaseIngredients = IngredientService.Instance.GetBaseIngredients();
            //ListIngredients = IngredientService.Instance.GetToppingIngredients();

            ListBaseIngredients = _ingredientService.GetBaseIngredients();
            ListIngredients = _ingredientService.GetToppingIngredients();

            ListIngredientsInPizza = new List<Ingredient>();

            CommandAddPizza = new DelegateCommand(AddPizza, CanAddPizza).ObservesProperty(() => Name).ObservesProperty(() => Desc).ObservesProperty(()=> Price).ObservesProperty(() => BaseIngredient);
        }

        private bool CanAddPizza()
        {
            if (Name == "")
                return false;

            if (Price == "")
                return false;

            if (Desc == "")
                return false;

            if (BaseIngredient is null)
                return false;

            return true;
        }

        private void AddPizza()
        {
            Pizza pizza = new Pizza(Name, Desc, Price, BaseIngredient, ListIngredientsInPizza);
            //PizzaService.Instance.AddPizza(pizza);
            _pizzaService.AddPizza(pizza);
            NavigationService.GoBackAsync();
        }

        private void AddIngredient(Ingredient ingredient)
        {
            // When leaving the page, SelectedIngredientToAdd is set to null. So we need to avoid doing this function.
            if (ingredient is null)
                return;

            ListIngredientsInPizza.Add(ingredient);

            if (ListSelectedIngredientsToDisplay != "")
                ListSelectedIngredientsToDisplay += " - ";

            ListSelectedIngredientsToDisplay += ingredient.Name;
        }
    }
}
