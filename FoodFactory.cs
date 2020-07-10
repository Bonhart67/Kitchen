using Kitchen.Ingredients;

namespace Kitchen
{
    public static class FoodFactory
    {
        public static Food CreateNakedBurger()
        {
            return new Food("NakedBurger")
                .Add<Patty>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Ketchup>();
        }
        public static Food CreateBasicBurger()
        {
            return new Food("BasicBurger")
                .Add<Patty>()
                .Add<Bun>()
                .Add<Ketchup>();
        }
        public static Food CreateCheeseBurger()
        {
            return new Food("CheeseBurger")
                .Add<Bun>()
                .Add<Patty>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static Food CreateFullBurger()
        {
            return new Food("FullBurger")
                .Add<Patty>()
                .Add<Bun>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static Food CreateDoubleBurger()
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
        public static Food CreateFries()
        {
            return new Food("FrenchFries")
                .Add<Fries>();
        }
        public static Food CreateFriesWithKetchup()
        {
            return new Food("FrenchFries")
                .Add<Fries>()
                .Add<Ketchup>();
        }
    }
}