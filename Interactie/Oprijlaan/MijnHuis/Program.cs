using DoomsdayPreppers;
using Heras;
using Infrac;
using Philips;

Lamp lamp = new Lamp();
Hek hek = new Hek();
Valkuil kuil = new Valkuil();
Detectielus lus = new Detectielus();

// Op basis van een interface
// lus.ConnectDevice(lamp);
// lus.ConnectDevice(hek);
// lus.ConnectDevice(kuil);

// lus.OnDetect();


// Op basis van event zonder interface
lus.devices2 += lamp.Aan;
lus.devices2 += hek.Open;
lus.devices2 += kuil.Open;

lus.OnDetect2();

