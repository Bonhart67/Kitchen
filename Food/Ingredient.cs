using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Kitchen.Interfaces;
using Kitchen.Logger;

namespace Kitchen.Food
{
    public class Ingredient : IIngredient
    {
        public string Name => this.GetType().Name;
        public int PreparationTime { get; protected set; }
        public int CookingTime { get; protected set; }
        public bool NeedsCooking => CookingTime != 0;
        public async Task Prepare() 
        {
            await Task.Delay(PreparationTime);
            Printer.Print($"{ Name } prepared");
        }
    }
}