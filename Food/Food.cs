using System.Collections.Generic;
using Kitchen.Food.Ingredients;
using Kitchen.Interfaces;

namespace Kitchen.Food
{
    public class Food : IFood
    {
        public List<IIngredient> Ingredients { get; private set; }
        public Food() => Ingredients = new List<IIngredient>();
        public Food Add<T>() where T : IIngredient, new() 
        {
            Ingredients.Add(new T());
            return this;
        }
    }
}