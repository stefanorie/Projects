namespace SomeLib;
public class Person
{
    public string? Name { get; set; }
    private int age;
    public int Age
    {
        get { return age; }
        set {
            if (value >= 0 && value <= 130) {
                age = value;
            }
        }
    }    
    
    public void Introduce() {
        System.Console.WriteLine($"Hello, I'm {Name} and {Age} years old");
    }
}
