using System;
using System.Collections.Generic;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.StopWatch.Start();
            var order = new List<Food>() 
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
            chef.PrepareOrder().Wait();
            Console.ReadKey();
        }
    }
}
