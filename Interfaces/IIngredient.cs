using System;
using System.Threading.Tasks;

namespace Kitchen.Interfaces
{
    public interface IIngredient : IComparable<IIngredient>
    {
        string Name { get; }
        int PreparationTime { get; }
        bool NeedsCooking { get; }
        bool IsReady { get; }
        Task Prepare();
    }
}