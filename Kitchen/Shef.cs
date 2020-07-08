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
        private IList<IFood> _toBeServed;
        public Shef(IEnumerable<IFood> order)
        {
            this._toBeServed = order.ToList();
            var ingredientsToPrepare = GetAllIngredientsInOrder(order);
            var needsCooking = ingredientsToPrepare
                .Where(i => i.NeedsCooking)
                .Select(i => i as INeedsCooking);
            _oven = new Oven(new Queue<INeedsCooking>(needsCooking));
            foreach (var ingredient in ingredientsToPrepare)
                ingredient.Prepared += TryServe;
            _oven.Cooked += TryServe;
            Prepare(new Queue<IIngredient>(ingredientsToPrepare));
        }

        private void TryServe(object sender, IIngredient[] ingredients)
        {
            var toServe = _toBeServed
                .Where(f => f.Ingredients.All(i => i.IsReady));
            // System.Console.WriteLine($"{ toServe.Count() } food is ready at the moment");
            if (!toServe.Any()) return;
            System.Console.WriteLine($"{ toServe.Count() }x { toServe.First().Name } served");
            foreach (var food in toServe)
                _toBeServed.Remove(food);
        }

        private void TryServe(object sender, IIngredient ingredient)
        {
            TryServe(sender, new IIngredient[] { ingredient });
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
                .ThenBy(i => i);
        }
    }
}