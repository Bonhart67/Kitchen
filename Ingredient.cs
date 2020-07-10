namespace Kitchen
{
    public abstract class Ingredient
    {
        public bool IsComplete = false;
        public string Name => GetType().Name;
        public int PreparationTime { get; protected set; }
        public int CookingTime { get; protected set; }
    }
}