namespace Objects
{
    public class Circle : Shape
    {
        public int Radius { get; set; }

        public override void Draw() {
            Console.BackgroundColor = Color;
            Console.WriteLine($"Cirkel met {Radius} radius");
            Console.ResetColor();
        }
    }
}