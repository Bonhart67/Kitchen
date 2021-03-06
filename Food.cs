using System;
using System.Collections.Generic;

namespace Kitchen
{
    public class Food
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; private set; }
        public List<Ingredient> Ingredients { get; private set; } = new List<Ingredient>();
        public Food(string name) => Name = name;
        public Food Add<T>() where T : Ingredient, new()
        {
            Ingredients.Add(new T() { FoodId = Id });
            return this;
        }
    }
}