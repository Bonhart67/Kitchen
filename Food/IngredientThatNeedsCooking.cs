using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Food
{
    public class IngredientThatNeedsCooking : Ingredient, INeedsCooking
    {
        public override bool NeedsCooking => true;
        public int CookingTime { get; protected set; }
        public bool IsCooked { get; protected set; }
        public override async Task Prepare() 
        {
            await Task.Delay(PreparationTime);
            System.Console.WriteLine($"{ this.Name } prepared");
        }

        public void Cook() => IsCooked = true;
    }
}