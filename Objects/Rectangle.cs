namespace Objects
{
    public class Rectangle : Shape
    {
        private int width;
        public int Width
        {
            get { return width; }
            set { 
                if (value >= 0) {
                    width = value; 
                }
            }
        }
        
        private int height;
        public int Height
        {
            get { return height; }
            set {
                if (value >= 0) {
                    height = value;
                }
            }
        }

        public override void Draw() {
            Console.BackgroundColor = Color;
            Console.WriteLine($"Rechthoek met {width} breedte en {height} hoogte");
            Console.ResetColor();
        }
    }
}