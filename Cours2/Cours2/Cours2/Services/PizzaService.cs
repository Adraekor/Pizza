using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cours2.Model;
using LiteDB;

namespace Cours2.Services
{

    public class PizzaService : IPizzaService
    {
        private string dbPath;

        private List<Pizza> _pizzas;


        public PizzaService()
        {
            _pizzas = new List<Pizza>();

            Pizza test = new Pizza("Montagnarde", "Après une bonne journée de ski, la Montagnarde !", "10", new Ingredient("Creme", IngredientType.Base));
            test.AddTopping(new Ingredient("Lardons", IngredientType.Meat));
            test.AddTopping(new Ingredient("Munster", IngredientType.Cheese));
            test.AddTopping(new Ingredient("Pommes de terre", IngredientType.Other));
            _pizzas.Add(test);

            test = new Pizza("Printemps", "Une pizza saine qui rapelle l'arrivée du beau temps", "12", new Ingredient("Tomate", IngredientType.Base));
            test.AddTopping(new Ingredient("Mozzarella", IngredientType.Cheese));
            test.AddTopping(new Ingredient("Asperges", IngredientType.Other));
            test.AddTopping(new Ingredient("Poivrons", IngredientType.Other));
            _pizzas.Add(test);

            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            dbPath = Path.Combine(docPath, "PizzaDB.db");

            using (var db = new LiteDatabase(dbPath))
            {
                var collection = db.GetCollection<Pizza>("Pizzas");
                var elements = collection.FindAll();
                foreach( var currentElement in elements)
                    _pizzas.Add(currentElement);
            }
        }
        

        public void AddPizza(Pizza pizza)
        {
            _pizzas.Add(pizza);
            using (var db = new LiteDatabase(dbPath))
            {
                var collection = db.GetCollection<Pizza>("Pizzas");
                collection.Insert(pizza);
            }
        }

        public List<Pizza> GetPizzas()
        {
            return _pizzas;
        }

        public Pizza GetPizza(int pos)
        {
            return _pizzas.ElementAt(pos);
        }
    }
}
