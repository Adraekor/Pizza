﻿using Cours2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cours2.Services
{
    public interface IIngredientService
    {
        List<Ingredient> GetBaseIngredients();

        List<Ingredient> GetToppingIngredients();

        List<Ingredient> GetAll();

        Ingredient GetById(int id);

        void Add(Ingredient ingredient);

    }
}
