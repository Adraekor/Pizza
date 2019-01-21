using Cours2.Model;
using LiteDB;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cours2.Services
{
    public class IngredientClient : BindableBase
	{
        public string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PizzaDB.db");
        public IngredientClient()
        {
            //var docPath = ;
            //DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PizzaDB.db");
        }

        public List<Ingredient> GetAllBase()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Ingredient>("Ingredient");
                var result = collection.Find(ingredient => ingredient.IngredientType == IngredientType.Base).ToList();
                return result;
            }
        }

        public List<Ingredient> GetAllToppings()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Ingredient>("Ingredient");
                var result = collection.Find(ingredient => ingredient.IngredientType != IngredientType.Base).ToList();
                return result;
            }
        }

        public Ingredient Get(int id)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Ingredient>("Ingredient");
                return collection.FindById(id);
            }
        }

        public void Add(Ingredient ingredient)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Ingredient>("Ingredient");
                collection.Insert(ingredient);
            }
        }
	}
}
