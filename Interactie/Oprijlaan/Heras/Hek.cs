using IEEE;

namespace Heras;
public class Hek : IDevice
{
    public void Open()
    {
        System.Console.WriteLine("Het hek gaat open");
    }

    public void Trigger()
    {
        Open();
    }
}
