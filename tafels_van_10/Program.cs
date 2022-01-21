// See https://aka.ms/new-console-template for more information
int numberOfTables = 10;

for (int table = 1; table <= numberOfTables; table++) {
    Console.WriteLine($"Tafel van {table}");

    for (int teller = 1; teller <= 10; teller++) {
        Console.WriteLine($"{teller} * {table} = {teller * table}");
    }

    Console.WriteLine(" ");
}
