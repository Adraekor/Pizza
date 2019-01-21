using Cours2.Model;
using LiteDB;
using Prism.Mvvm;
using System;
using System.IO;

namespace Cours2.Services
{
    public class IngredientClient : BindableBase
	{
        public string DbPath { get; }
        public IngredientClient()
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DbPath = Path.Combine(docPath, "PizzaDB.db");
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
