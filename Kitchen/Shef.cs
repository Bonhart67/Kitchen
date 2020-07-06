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
        private Oven _oven;
        public Shef(IEnumerable<IFood> order)
        {
            var ingredientsToPrepare = GetAllIngredientsInOrder(order);
            var asd = new Queue<IIngredient>(ingredientsToPrepare);
            var needsCooking = ingredientsToPrepare
                .Where(i => i.NeedsCooking)
                .Select(i => i as INeedsCooking);
            this._oven = new Oven(needsCooking);
            Prepare(new Queue<IIngredient>(ingredientsToPrepare)).Wait();
        }

        private async Task Prepare(Queue<IIngredient> ingredientsToPrepare)
        {
            var task = Task.Factory.StartNew(async () => 
            {
                while (ingredientsToPrepare.TryDequeue(out IIngredient ingredient))
                {
                    await ingredient.Prepare();
                }
            });

            await task;
        }

        private IEnumerable<IIngredient> GetAllIngredientsInOrder(IEnumerable<IFood> order)
        {
            return order
                .SelectMany(f => f.Ingredients)
                .OrderByDescending(i => i.NeedsCooking)
                .ThenBy(i => i);
        }
    }
}