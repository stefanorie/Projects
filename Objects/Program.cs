

// Vijf cirkels en zes rechthoeken, in een List

using Objects;

List<Shape> figures = new List<Shape> {
    new Circle { Color = ConsoleColor.Cyan, Radius = 12 },
    new Circle { Color = ConsoleColor.Red, Radius = 2 },
    new Circle { Color = ConsoleColor.Green, Radius = 5 },
    new Circle { Color = ConsoleColor.Yellow, Radius = 4 },
    new Circle { Color = ConsoleColor.DarkMagenta, Radius = 8 },

    new Rectangle { Color = ConsoleColor.DarkBlue, Width = 5, Height = 12 },
    new Rectangle { Color = ConsoleColor.Green, Width = 6, Height = 6 },
    new Rectangle { Color = ConsoleColor.White, Width = 7, Height = 8 },
    new Rectangle { Color = ConsoleColor.Black, Width = 8, Height = 22 },
    new Rectangle { Color = ConsoleColor.DarkYellow, Width = 9, Height = 8 },
    new Rectangle { Color = ConsoleColor.Gray, Width = 10, Height = 20 }
};

foreach(Shape figure in figures) {
    figure.Draw();
}

