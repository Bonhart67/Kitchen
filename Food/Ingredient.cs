using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Kitchen.Interfaces;
using Kitchen.Logger;

namespace Kitchen.Food
{
    public abstract class Ingredient : IIngredient
    {
        public string Name => this.GetType().Name;
        public int PreparationTime { get; protected set; }
        public int CookingTime { get; protected set; }
    }
}