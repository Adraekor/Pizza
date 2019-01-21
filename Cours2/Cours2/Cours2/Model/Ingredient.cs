using System;
using System.Collections.Generic;
using System.Text;

namespace Cours2.Model
{
    public enum IngredientType { Base, Meat, Cheese, Other }

    public class Ingredient
    {
        public Ingredient()
        {
                
        }

        public int Id { get; set; }

        public IngredientType IngredientType { get; set; }

        public string Name { get; set; }
        
        public Ingredient( string name, IngredientType ingredientType )
        {
            Name = name;
            IngredientType = ingredientType;
        }
    }
}
