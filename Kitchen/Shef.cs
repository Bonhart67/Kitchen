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
            this._oven = new Oven(new Queue<INeedsCooking>(needsCooking));
            Prepare(new Queue<IIngredient>(ingredientsToPrepare));
        }

        private void Prepare(Queue<IIngredient> ingredientsToPrepare)
        {
            Task.Factory.StartNew(async () => 
            {
                while (ingredientsToPrepare.TryDequeue(out IIngredient ingredient))
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
                .ThenBy(i => i);
        }
    }
}