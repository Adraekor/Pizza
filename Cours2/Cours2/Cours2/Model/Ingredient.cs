using System;
using System.Collections.Generic;
using System.Text;

namespace Cours2.Model
{
    public enum IngredientType { Base, Meat, Cheese, Other }

    public class Ingredient
    {
        public int Id { get; private set; }

        public IngredientType IngredientType;

        public string Name { get; set; }
        
        public Ingredient( string name, IngredientType ingredientType )
        {
            Name = name;
            IngredientType = ingredientType;
        }
    }
}
