using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Food;
using Kitchen.Interfaces;
using Kitchen.Logger;

namespace Kitchen.Kitchen
{
    public class Chef
    {
        private Oven _oven = new Oven();
        public Chef(IEnumerable<IFood> order)
        {
            var ingredientsToPrepare = GetAllIngredientsInOrder(order);
            PrepareIngredients(ingredientsToPrepare);
        }

        private void PrepareIngredients(IEnumerable<IIngredient> ingredientsToPrepare)
        {
            Task.Factory.StartNew(async () => 
            {
                foreach (var ingredient in ingredientsToPrepare)
                {
                    var readyIngredient = await Prepare(ingredient)
                        .ContinueWith(async task => await _oven.Cook(ingredient));
                    
                }
            });
        }
        private async Task<IIngredient> Prepare(IIngredient ingredient)
        {
            await Task.Delay(ingredient.PreparationTime);
            Printer.Print($"{ ingredient.Name } prepared");
            return ingredient;
        }
        private IEnumerable<IIngredient> GetAllIngredientsInOrder(IEnumerable<IFood> order)
        {
            return order
                .SelectMany(f => f.Ingredients)
                .OrderByDescending(i => i.CookingTime)
                .ThenBy(i => i.Name);
        }
    }
}