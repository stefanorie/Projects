using IEEE;

namespace Infrac;

public delegate void ConnectDevice2();

public class Detectielus
{
    private List<IDevice> devices = new List<IDevice>();

    public event ConnectDevice2? devices2;

    public void OnDetect()
    {
        Console.WriteLine("De detectielus detecteert iets");

        foreach(IDevice device in devices) {
            device.Trigger();
        }
    }

    public void OnDetect2() {
        Console.WriteLine("De detectielus detecteert iets");
        devices2?.Invoke();
    }

    public void ConnectDevice(IDevice device)
    {
        devices.Add(device);
    }
}
