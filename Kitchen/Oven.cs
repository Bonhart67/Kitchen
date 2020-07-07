using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Kitchen
{
    public class Oven
    {
        private const int MAX_OVEN_SLOT = 4;
        public Oven(IEnumerable<INeedsCooking> toBeCooked)
        {
            var _toBeCooked = new Queue<INeedsCooking>(toBeCooked);
            Cook(_toBeCooked);
        }

        private void Cook(Queue<INeedsCooking> toBeCooked)
        {
            Task.Factory.StartNew(async () => 
            {
                while (toBeCooked.Any())
                {
                    var ingredientsToCook = toBeCooked
                        .Take(MAX_OVEN_SLOT)
                        .TakeWhile(i => i.GetType().Equals(toBeCooked.First().GetType()));
                    await WaitForIngredientsToBeReady(ingredientsToCook);
                    // System.Console.WriteLine($"Cooking started with x{ ingredientsToCook.Count() } { ingredientsToCook.First().Name }");
                    // await Task.Delay(ingredientsToCook.First().CookingTime);
                    // for (int i = 0; i < ingredientsToCook.Count(); i++)
                    // {
                    //     ingredientsToCook.ElementAt(i).Cook();
                    //     toBeCooked.Dequeue();
                    // }

                }
            });
        }

        private async Task WaitForIngredientsToBeReady(IEnumerable<INeedsCooking> ingredients)
        {
            while (!ingredients.All(i => i.IsPrepared))
                await Task.Delay(25);
        }
    }
}