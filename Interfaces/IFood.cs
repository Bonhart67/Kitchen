using System.Collections.Generic;

namespace Kitchen.Interfaces
{
    public interface IFood
    {
        List<IIngredient> Ingredients { get; }
    }
}