using System;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.StopWatch.Start();
            var chef = new Chef(GetOrder());
            chef.PrepareOrder().Wait();
            Console.ReadKey();
        }

        private static IEnumerable<Food> GetOrder()
        {
            return new List<Food> 
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
        }
    }
}
