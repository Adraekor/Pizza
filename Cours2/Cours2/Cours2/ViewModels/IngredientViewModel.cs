using Cours2.Model;
using Cours2.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours2.ViewModels
{
    public class IngredientViewModel : ViewModelBase
	{
        private IIngredientService _IngredientService;

        private string ingredientName;
        public string IngredientName
        {
            get { return ingredientName; }
            set { SetProperty(ref ingredientName, value); }
        }

        private IngredientType type;
        public IngredientType Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private string typeName;
        public string TypeName
        {
            get { return typeName; }
            set { SetProperty(ref typeName, value); }
        }

        private List<string> listIngredientType;
        public List<string> ListIngredientType
        {
            get { return listIngredientType; }
            set { SetProperty(ref listIngredientType, value); }
        }

        public DelegateCommand DelegateValidate { get; private set; }

        public IngredientViewModel(INavigationService navService, IIngredientService ingredientService):base(navService)
        {
            DelegateValidate = new DelegateCommand(Validate, CanValidate).ObservesProperty(() => ingredientName).ObservesProperty(() => TypeName);
            _IngredientService = ingredientService;

            ListIngredientType = Enum.GetNames(typeof (IngredientType)).ToList();
        }

        private void Validate()
        {
            _IngredientService.Add(new Ingredient(IngredientName, Type));
            NavigationService.NavigateAsync("NavigationPage/RestaurantMenu");
        }

        private bool CanValidate()
        {
            if (IngredientName == "")
                return false;

            if (Enum.TryParse(TypeName, out IngredientType IngrType))
                Type = IngrType;
            else
                return false;

            return true;
        }
	}
}
