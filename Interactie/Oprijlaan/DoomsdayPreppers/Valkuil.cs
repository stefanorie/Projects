using IEEE;

namespace DoomsdayPreppers;
public class Valkuil : IDevice
{
    public void Open()
    {
        System.Console.WriteLine("De valkuil opent");
    }

    public void Trigger()
    {
        Open();
    }
}
