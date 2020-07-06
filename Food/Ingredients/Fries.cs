using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Food.Ingredients
{
    public class Fries : IngredientThatNeedsCooking
    {
        public Fries() => this.PreparationTime = 100;
    }
}