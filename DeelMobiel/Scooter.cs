namespace DeelMobiel;

// Scooter: EUR 1,00 starttarief + EUR 0,25 per minuut.
public class Scooter : ElektrischVoertuig
{
    public string Kenteken { get; }

    public Scooter(string id, string merk, string kenteken, int accuPercentage)
        : base(id, merk, accuPercentage)
    {
        Kenteken = kenteken;
    }

    public override decimal BerekenPrijs(int minuten)
    {
        return 1.00m + 0.25m * minuten;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, scooter met kenteken {Kenteken}";
    }
}
