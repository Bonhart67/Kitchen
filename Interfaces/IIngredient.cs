using System;
using System.Threading.Tasks;

namespace Kitchen.Interfaces
{
    public interface IIngredient
    {
        string Name { get; }
        int PreparationTime { get; }
        int CookingTime { get; }
    }
}