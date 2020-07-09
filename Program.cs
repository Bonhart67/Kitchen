using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen.Food;
using Kitchen.Food.Ingredients;
using Kitchen.Interfaces;
using Kitchen.Kitchen;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new List<IFood>() 
            {
                FoodFactory.CreateBasicBurger(),
                FoodFactory.CreateBasicBurger(),
                FoodFactory.CreateCheeseBurger(),
                FoodFactory.CreateCheeseBurger(),
                FoodFactory.CreateDoubleBurger(),
                FoodFactory.CreateDoubleBurger(),
                FoodFactory.CreateFullBurger(),
                FoodFactory.CreateFullBurger(),
                FoodFactory.CreateFriesWithKetchup(),
                FoodFactory.CreateFriesWithKetchup(),
                FoodFactory.CreateFriesWithKetchup(),
                FoodFactory.CreateFriesWithKetchup(),
                FoodFactory.CreateFries(),
                FoodFactory.CreateFries(),
                FoodFactory.CreateFries(),
            };
            var chef = new Chef(order);
            Console.ReadKey();
        }
    }
}
