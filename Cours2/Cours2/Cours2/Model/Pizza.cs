using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cours2.Model
{
    public class Pizza
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Vegetarian { get; set; }

        public Ingredient BaseIngredient { get; set; }
        public List<Ingredient> Ingredients { get; private set; }

        public Pizza()
        {

        }

        public Pizza(string name, string description, string price, Ingredient baseIngredient)
        {
            Init();

            this.name = name;
            Description = description;
            Price = price;
            BaseIngredient = baseIngredient;
        }

        public Pizza(string name, string description, string price, Ingredient baseIngredient, List<Ingredient> toppingIngredients) : this(name, description, price, baseIngredient)
        {
            foreach (Ingredient ingredient in toppingIngredients)
                AddTopping(ingredient);
        }

        private void Init()
        {
            Ingredients = new List<Ingredient>();
            Vegetarian = true;
        }

        public void AddTopping(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            if (ingredient.IngredientType == IngredientType.Meat)
                Vegetarian = false;
        }

        public List<Ingredient> GetListToppingUsingType(IngredientType ingredientType)
        {
            return (Ingredients.Where( i => i.IngredientType == ingredientType)).ToList();
        }
    }
}
