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
	public class PizzaDetailsViewModel : ViewModelBase
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

        private string _description = "";
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private string _baseIngredient = "";
        public string BaseIngredient
        {
            get { return _baseIngredient; }
            set { SetProperty(ref _baseIngredient, value); }
        }

        private string _listCheeseIngredients = "";
        public string ListCheeseIngredients
        {
            get { return _listCheeseIngredients; }
            set { SetProperty(ref _listCheeseIngredients, value); }
        }

        private string _listMeatIngredients = "";
        public string ListMeatIngredients
        {
            get { return _listMeatIngredients; }
            set { SetProperty(ref _listMeatIngredients, value); }
        }

        private string _listOtherIngredients = "";
        public string ListOtherIngredients
        {
            get { return _listOtherIngredients; }
            set { SetProperty(ref _listOtherIngredients, value); }
        }

        public PizzaDetailsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Détails pizza";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

         
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            Pizza pizza = parameters.GetValue<Pizza>("Pizza");
            Name = pizza.name;
            Price = pizza.Price;
            Description = pizza.Description;
            BaseIngredient = pizza.BaseIngredient.Name;
            ListCheeseIngredients = convertListIngredientToString(pizza.GetListToppingUsingType(IngredientType.Cheese));
            ListMeatIngredients = convertListIngredientToString(pizza.GetListToppingUsingType(IngredientType.Meat));
            ListOtherIngredients = convertListIngredientToString(pizza.GetListToppingUsingType(IngredientType.Other));
        }

        private string convertListIngredientToString(List<Ingredient> ingredients)
        {
            string list = "";
            foreach(Ingredient ingredient in ingredients)
            {
                list += ingredient.Name + " - ";
            }

            if (list != "")
                return list.Remove(list.Length - 2);

            return list;
        }
    }
}
