namespace DeelMobiel;

// Elektrische step: EUR 0,50 starttarief + EUR 0,20 per minuut.
public class ElektrischeStep : ElektrischVoertuig
{
    public int MaximumSnelheid { get; } // km/u

    public ElektrischeStep(string id, string merk, int maximumSnelheid, int accuPercentage)
        : base(id, merk, accuPercentage)
    {
        MaximumSnelheid = maximumSnelheid;
    }

    public override decimal BerekenPrijs(int minuten)
    {
        return 0.50m + 0.20m * minuten;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, elektrische step (max {MaximumSnelheid} km/u)";
    }
}
