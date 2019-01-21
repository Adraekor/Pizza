using Cours2.Model;
using LiteDB;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cours2.Services
{
	public class PizzaClient : BindableBase
	{
        public string DbPath { get; }
        public PizzaClient()
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DbPath = Path.Combine(docPath, "PizzaDB.db");
        }

        public Pizza Get(int id)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Pizza>("Pizza");
                return collection.FindById(id);
            }
        }

        public List<Pizza> GetAll()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Pizza>("Pizza");
                return collection.FindAll().ToList();
            }
        }

        public void Add(Pizza pizza)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Pizza>("Pizza");
                collection.Insert(pizza);
            }
        }
    }
}
