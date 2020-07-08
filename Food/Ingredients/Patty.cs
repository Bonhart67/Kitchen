using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Food.Ingredients
{
    public class Patty : IngredientThatNeedsCooking
    {
        public Patty()
        {
            this.PreparationTime = 100;
            this.CookingTime = 1000;
        }
    }
}