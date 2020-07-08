using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kitchen.Interfaces
{
    public interface IFood
    {
        string Name { get; }
        List<IIngredient> Ingredients { get; }
    }
}