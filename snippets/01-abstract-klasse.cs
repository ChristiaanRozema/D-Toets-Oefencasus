// Abstracte klasse: kun je niet "new"-en, alleen erven.
public abstract class Dier
{
    public string Naam { get; }                 // alleen get: zet je in de constructor
    public bool IsWakker { get; set; } = true;  // get + set

    protected Dier(string naam)                 // protected: alleen subklassen
    {
        if (string.IsNullOrWhiteSpace(naam))
            throw new ArgumentException("Naam mag niet leeg zijn.", nameof(naam));
        Naam = naam;
    }

    public abstract string Geluid();            // zonder body: subklasse MOET dit invullen

    public override string ToString() => $"{Naam} ({(IsWakker ? "wakker" : "slaapt")})";
}

public class Hond : Dier
{
    public int Leeftijd { get; }

    public Hond(string naam, int leeftijd) : base(naam)   // base(...) verplicht
    {
        Leeftijd = leeftijd;
    }

    public override string Geluid() => "Woef";            // override verplicht

    public override string ToString() => $"{base.ToString()}, hond van {Leeftijd} jaar";
}
