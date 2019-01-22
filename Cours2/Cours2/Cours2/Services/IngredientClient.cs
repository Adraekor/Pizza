using Cours2.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cours2.Services
{
    public class IngredientClient
	{
        public string DbPath;

        public IngredientClient()
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DbPath = Path.Combine(docPath, "PizzaDB.db");
        }

        public List<Ingredient> GetAllBase()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Ingredient>("Ingredient");
                return collection.Find(ingredient => ingredient.IngredientType == IngredientType.Base).ToList();
            }
        }

        public List<Ingredient> GetAllToppings()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Ingredient>("Ingredient");
                return collection.Find(ingredient => ingredient.IngredientType != IngredientType.Base).ToList();
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
