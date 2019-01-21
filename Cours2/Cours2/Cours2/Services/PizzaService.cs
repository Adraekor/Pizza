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
        private List<Pizza> _pizzas;
        private PizzaClient PizzaClient;

        public PizzaService()
        {
            _pizzas = new List<Pizza>();
            PizzaClient = new PizzaClient();
        }

        public void AddPizza(Pizza pizza)
        {
            _pizzas.Add(pizza);
            PizzaClient.Add(pizza);
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
