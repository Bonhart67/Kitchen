using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Kitchen.Food.Ingredients;
using Kitchen.Interfaces;

namespace Kitchen.Food
{
    public class Food : IFood
    {
        public string Name { get; private set; }
        public List<IIngredient> Ingredients { get; private set; } = new List<IIngredient>();
        public Food(string name)
        { 
            this.Name = name;
        }
        public Food Add<T>() where T : IIngredient, new() 
        {
            Ingredients.Add(new T());
            return this;
        }
    }
}