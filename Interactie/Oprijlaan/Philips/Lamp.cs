using IEEE;

namespace Philips;

public class Lamp : IDevice
{
    public void Aan()
    {
        System.Console.WriteLine("De lamp gaat aan");
    }

    public void Trigger()
    {
        Aan();
    }
}
