using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Food;
using Kitchen.Interfaces;

namespace Kitchen.Kitchen
{
    public class Shef
    {
        public Shef(IEnumerable<IFood> order)
        {
            var ingredientsToPrepare = GetAllIngredientsInOrder(order);
            Prepare(new Queue<IIngredient>(ingredientsToPrepare));
        }

        private void Prepare(Queue<IIngredient> ingredientsToPrepare)
        {
            Task.Factory.StartNew(async () => 
            {
                foreach (var ingredient in ingredientsToPrepare)
                {
                    await ingredient.Prepare();
                }
            });
        }

        private IEnumerable<IIngredient> GetAllIngredientsInOrder(IEnumerable<IFood> order)
        {
            return order
                .SelectMany(f => f.Ingredients)
                .OrderByDescending(i => i.NeedsCooking)
                .ThenBy(i => i.Name);
        }
    }
}