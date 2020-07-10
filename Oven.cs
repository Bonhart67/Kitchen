using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen
{
    public class Oven
    {
        public const int MAX_OVEN_SLOT = 4;
        public Task IsCooking = null;
        public event EventHandler<Ingredient[]> BatchDone;
        private Queue<List<Ingredient>> _batches = new Queue<List<Ingredient>>();
        public void AddBatch(List<Ingredient> batch) => _batches.Enqueue(batch);
        public async Task CookBatches()
        {
            while (_batches.Count > 0)
            {
                var batch = _batches.Dequeue();
                string caption = $"{ batch.Count }x { batch[0].Name }";
                Printer.Display($"Cooking started with { caption }", ConsoleColor.Cyan);
                await Task.Delay(batch[0].CookingTime);
                foreach (var ingredient in batch) ingredient.IsComplete = true;
                Printer.Display($"{ caption } cooked", ConsoleColor.DarkYellow);
                BatchDone?.Invoke(this, batch.ToArray());
            }
        }
    }
}