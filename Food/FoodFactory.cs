using System.Collections.Generic;
using Kitchen.Food.Ingredients;
using Kitchen.Interfaces;

namespace Kitchen.Food
{
    public static class FoodFactory
    {
        public static IFood CreateNakedBurger()
        {
            return new Food("NakedBurger")
                .Add<Patty>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Ketchup>();
        }
        public static IFood CreateBasicBurger()
        {
            return new Food("BasicBurger")
                .Add<Patty>()
                .Add<Bun>()
                .Add<Ketchup>();
        }
        public static IFood CreateCheeseBurger()
        {
            return new Food("CheeseBurger")
                .Add<Bun>()
                .Add<Patty>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static IFood CreateFullBurger()
        {
            return new Food("FullBurger")
                .Add<Patty>()
                .Add<Bun>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static IFood CreateDoubleBurger()
        {
            return new Food("DoubleBurger")
                .Add<Patty>()
                .Add<Patty>()
                .Add<Bun>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Cheese>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static IFood CreateFries()
        {
            return new Food("FrenchFries")
                .Add<Fries>();
        }
        public static IFood CreateFriesWithKetchup()
        {
            return new Food("FrenchFries")
                .Add<Fries>()
                .Add<Ketchup>();
        }
    }
}