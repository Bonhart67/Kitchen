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
        public Oven(Queue<INeedsCooking> toBeCooked)
        {
            StartCooking(toBeCooked);
        }

        private void StartCooking(Queue<INeedsCooking> toBeCooked)
        {
            Task.Factory.StartNew(async () => 
            {
                while (toBeCooked.Any())
                {
                    var ingredientsToCook = SelectIngredientsToCookNext(toBeCooked);
                    ingredientsToCook = await WaitForIngredientsToBeReady(ingredientsToCook);
                    System.Console.WriteLine($"Cooking started with { ingredientsToCook.Length }x { ingredientsToCook.First().Name }");
                    var cookedIngredients = await Cook(ingredientsToCook);
                    for (int i = 0; i < cookedIngredients.Length; i++)
                        toBeCooked.Dequeue();
                }
            });
        }

        private INeedsCooking[] SelectIngredientsToCookNext(Queue<INeedsCooking> ingredients)
        {
            return ingredients
                .Take(MAX_OVEN_SLOT)
                .TakeWhile(i => i.GetType().Equals(ingredients.First().GetType()))
                .ToArray();
        }

        private async Task<INeedsCooking[]> WaitForIngredientsToBeReady(INeedsCooking[] ingredients)
        {
            while (!ingredients.All(i => i.IsPrepared))
                await Task.Delay(25);
            return ingredients;
        }

        private async Task<INeedsCooking[]> Cook(INeedsCooking[] ingredients)
        {
            await Task.Delay(ingredients.First().CookingTime);
            ingredients.ToList().ForEach(i => i.Cook());
            System.Console.WriteLine($"{ ingredients.Length }x { ingredients[0].Name } cooked");
            return ingredients;
        }
    }
}