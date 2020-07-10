using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen
{
    public class Chef
    {
        private Oven _oven = new Oven();
        private readonly IEnumerable<Food> _order;
        private IList<Ingredient> _toBeCooked;
        private List<Ingredient> _nextBatch;
        public Chef(IEnumerable<Food> order)
        {
            _order = order;
            _oven.BatchDone += OnBatchDone;
        }

        private void OnBatchDone(object _, Ingredient[] ingredients) => TryServe(ingredients);

        private void TryServe(Ingredient[] ingredients)
        {
            
        }

        public async Task PrepareOrder()
        {
            var allIngredients = GetAllIngredientsInOrder(_order);
            _toBeCooked = allIngredients.Where(i => i.CookingTime > 0).ToList();
            foreach (var ingredient in allIngredients) 
                await HandleIngredient(ingredient);
        }

        private async Task HandleIngredient(Ingredient ingredient)
        {
            await Task.Delay(ingredient.PreparationTime);

            if (ingredient.CookingTime > 0) 
            {
                HandleCooking(ingredient);
                return;
            }
            
            ingredient.IsComplete = true;
            Printer.Display($"{ ingredient.Name } prepared", ConsoleColor.Blue);
            TryServe(new Ingredient[] { ingredient });
        }

        private void HandleCooking(Ingredient ingredient)
        {
            _toBeCooked.Remove(ingredient);
            if (_nextBatch.Count > 0 && ingredient.Name != _nextBatch[0].Name)
                SendBatch();

            _nextBatch.Add(ingredient);
            if (_nextBatch.Count != Oven.MAX_OVEN_SLOT) return;
            
            SendBatch();
            if (_oven.IsCooking != null && !_oven.IsCooking.IsCompleted) return;
            _oven.IsCooking = _oven.CookBatches();
        }

        private void SendBatch()
        {
            _oven.AddBatch(_nextBatch);
            _nextBatch.Clear();
        }

        private IEnumerable<Ingredient> GetAllIngredientsInOrder(IEnumerable<Food> order)
        {
            return order
                .SelectMany(f => f.Ingredients)
                .OrderByDescending(i => i.CookingTime)
                .ThenBy(i => i.Name);
        }
    }
}