class Program {
    public static void Main() {
        Console.WriteLine("Voer twee getallen om bij elkaar op te tellen");

        int firstInput = ReadInput("Voer het eerste getal in ");
        int secondInput = ReadInput("Voer het tweede getal in ");

        int result = AddNumbers(firstInput, secondInput);
        ShowResult(firstInput, secondInput, result);
    }

    static int ReadInput(string message) {
        while(true) {
            Console.Write(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number)) {
                return number;
            }
        }
    }

    static int AddNumbers(int a, int b) {
        return a + b;
    }

    static void ShowResult(int a, int b, int result) {
        Console.WriteLine($"{a} + {b} = {result}");
    }
}
