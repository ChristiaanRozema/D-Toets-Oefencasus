namespace DeelMobiel;

// 2C. Fiets: erft van Voertuig. Tarief: EUR 0,10 per minuut.
public class Fiets : Voertuig
{
    public int Versnellingen { get; }

    public Fiets(string id, string merk, int versnellingen) : base(id, merk)
    {
        Versnellingen = versnellingen;
    }

    public override decimal BerekenPrijs(int minuten)
    {
        return 0.10m * minuten; // m = decimal-literal
    }

    public override string ToString()
    {
        return $"{base.ToString()}, fiets met {Versnellingen} versnellingen";
    }
}
