using Cours2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cours2.Services
{
    public interface IPizzaService
    {

        List<Pizza> GetPizzas();

        void AddPizza(Pizza pizza);

        Pizza GetPizza(int pos);

    }
}
