using Cours2.Model;
using System.Collections.Generic;

namespace Cours2.Services
{
    public sealed class IngredientService : IIngredientService
    {
        private IngredientClient ingredientClient;

        private List<Ingredient> _baseIngredients;
        private List<Ingredient> _toppingIngredients;

        public IngredientService()
        {
            _baseIngredients = new List<Ingredient>();
            _toppingIngredients = new List<Ingredient>();

            ingredientClient = new IngredientClient();

            Init2();

            _baseIngredients = ingredientClient.GetAllBase();
            _toppingIngredients = ingredientClient.GetAllToppings();

        }

        private void Init2()
        {
            ingredientClient.Add(new Ingredient("Creme", IngredientType.Base));
        }

        private void Init()
        {
            _baseIngredients.AddRange(new List<Ingredient>
            {
                new Ingredient("Creme", IngredientType.Base),
                new Ingredient("Tomate", IngredientType.Base),
                new Ingredient("Bolognaise", IngredientType.Base)
            });

            _toppingIngredients.AddRange(new List<Ingredient>
            {
                new Ingredient("Mozzarella", IngredientType.Cheese),
                new Ingredient("Chevre", IngredientType.Cheese),
                new Ingredient("Emmental", IngredientType.Cheese),
                new Ingredient("Camembert", IngredientType.Cheese),
                new Ingredient("Roquefort", IngredientType.Cheese),
                new Ingredient("Saucisse", IngredientType.Meat),
                new Ingredient("Jambon", IngredientType.Meat),
                new Ingredient("Lardons", IngredientType.Meat),
                new Ingredient("Boeuf", IngredientType.Meat),
                new Ingredient("Poulet", IngredientType.Meat),
                new Ingredient("Oeuf", IngredientType.Other),
                new Ingredient("Thon", IngredientType.Other),
                new Ingredient("Champignons", IngredientType.Other),
                new Ingredient("Olives", IngredientType.Other),
                new Ingredient("Anchois", IngredientType.Other),
                new Ingredient("Asperges", IngredientType.Other),
                new Ingredient("Ananas", IngredientType.Other),
                new Ingredient("Capres", IngredientType.Other),
                new Ingredient("Pommes de terre", IngredientType.Other),
                new Ingredient("Poivrons", IngredientType.Other)
            });
        }

        public List<Ingredient> GetBaseIngredients()
        {
            return _baseIngredients;
        }

        public List<Ingredient> GetToppingIngredients()
        {
            return _toppingIngredients;
        }

        public List<Ingredient> GetAll()
        {
            var a = new List<Ingredient>();
            a.AddRange(_toppingIngredients);
            a.AddRange(_baseIngredients);

            return a;
        }

        public Ingredient GetById(int id)
        {
            return ingredientClient.Get(id);
        }

        public void Add(Ingredient ingredient)
        {
            ingredientClient.Add(ingredient);
        }
    }
}
