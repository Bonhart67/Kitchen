using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Food
{
    public abstract class Ingredient : IIngredient
    {
        public string Name => this.GetType().Name;
        public int PreparationTime { get; protected set; }
        public virtual bool NeedsCooking => false;
        public virtual bool IsReady => IsPrepared;
        public bool IsPrepared { get; private set; }
        public async Task Prepare() 
        {
            await Task.Delay(PreparationTime);
            IsPrepared = true;
            System.Console.WriteLine($"{ this.Name } prepared");
        }
        public int CompareTo([AllowNull] IIngredient other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}