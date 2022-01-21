namespace Objects
{
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }

        public abstract void Draw();
    }
}