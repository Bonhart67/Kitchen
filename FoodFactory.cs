using Kitchen.Ingredients;

namespace Kitchen
{
    public static class FoodFactory
    {
        public static Food CreateNakedBurger()
        {
            return new Food("Naked Burger")
                .Add<Patty>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Ketchup>();
        }
        public static Food CreateBasicBurger()
        {
            return new Food("Basic Burger")
                .Add<Patty>()
                .Add<Bun>()
                .Add<Ketchup>();
        }
        public static Food CreateCheeseBurger()
        {
            return new Food("Cheese Burger")
                .Add<Bun>()
                .Add<Patty>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static Food CreateFullBurger()
        {
            return new Food("Full Burger")
                .Add<Patty>()
                .Add<Bun>()
                .Add<Lettuce>()
                .Add<Tomato>()
                .Add<Cheese>()
                .Add<Ketchup>();
        }
        public static Food CreateDoubleBurger()
        {
            return new Food("Double Burger")
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
            return new Food("French Fries")
                .Add<Fries>();
        }
        public static Food CreateFriesWithKetchup()
        {
            return new Food("French Fries with ketchup")
                .Add<Fries>()
                .Add<Ketchup>();
        }
    }
}