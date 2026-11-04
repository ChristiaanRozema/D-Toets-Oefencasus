namespace DeelMobiel;

// 2A. Abstracte klasse: basis voor alle voertuigen.
public abstract class Voertuig
{
    public string Id { get; }                       // alleen get
    public string Merk { get; }                     // alleen get
    public bool IsBeschikbaar { get; set; } = true; // get en set

    // protected: alleen subklassen mogen hem aanroepen (via base(...))
    protected Voertuig(string id, string merk)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Het id mag niet leeg zijn.", nameof(id));

        Id = id;
        Merk = merk;
        IsBeschikbaar = true; // een nieuw voertuig is altijd beschikbaar
    }

    // Abstract: elke soort voertuig rekent zelf zijn prijs uit.
    public abstract decimal BerekenPrijs(int minuten);

    public override string ToString()
    {
        string status = IsBeschikbaar ? "beschikbaar" : "niet beschikbaar";
        return $"{Id} ({Merk}) - {status}";
    }
}
