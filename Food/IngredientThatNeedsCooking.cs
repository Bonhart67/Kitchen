using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Food
{
    public class IngredientThatNeedsCooking : Ingredient, INeedsCooking
    {
        public override bool NeedsCooking => true;
        public int CookingTime { get; protected set; }
        public bool IsCooked { get; protected set; }
        public override bool IsReady => IsCooked;
        public void Cook()
        {
            IsCooked = true;
        }
    }
}