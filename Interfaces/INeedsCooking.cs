using System.Threading.Tasks;

namespace Kitchen.Interfaces
{
    public interface INeedsCooking : IIngredient
    {
        int CookingTime { get; }
        bool IsCooked { get; }
        void Cook();
    }
}