using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Containers;

public abstract class Container : IContainer
{
    public int MasaLadunkuKg { get; set; }
    public int WysokoscCm { get; set; }
    public int WagaWlasnaKg { get; set; }
    public int GlebokoscCm { get; set; }
    public string NumerSeryjny { get; set; }
    public int MaksymalnaLadownosc { get; set; }


    public void Unload()
    {
        MasaLadunkuKg = 0;
    }

    public void Load(int Masa)
    {
        if (MasaLadunkuKg + Masa > MaksymalnaLadownosc)
        {
            throw new OverfillException("Too much kg in container");
        }
        MasaLadunkuKg += Masa;
    }
}