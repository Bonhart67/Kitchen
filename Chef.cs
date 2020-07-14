using System.Threading.Tasks;

namespace Kitchen
{
    public class Chef
    {
        public Task IsPreparing = null;

        public async Task Prepare(Ingredient ingredient)
        {
            await Task.Delay(ingredient.PreparationTime);
        }
    }
}