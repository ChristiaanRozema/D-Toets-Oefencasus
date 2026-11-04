namespace DeelMobiel;

// Singleton: er mag maar één Verhuurbedrijf bestaan.
public class Verhuurbedrijf
{
    // 1. Static veld met de enige instantie
    private static readonly Verhuurbedrijf _instance = new Verhuurbedrijf();

    // 2. Static property om hem op te halen
    public static Verhuurbedrijf Instance => _instance;

    // 3. Private constructor: niemand kan zelf "new Verhuurbedrijf()" doen
    private Verhuurbedrijf() { }

    // 2E.2: intern een List, naar buiten een IReadOnlyList (upcasting)
    private readonly List<Voertuig> _voertuigen = new List<Voertuig>();
    public IReadOnlyList<Voertuig> Voertuigen => _voertuigen;

    // 2F.3/4: alleen de interface, nooit ConsoleLogger. Zo kan later een BestandLogger.
    public ILogger Logger { get; set; } = new ConsoleLogger();

    // 2E.3
    public void VoegToe(Voertuig voertuig)
    {
        _voertuigen.Add(voertuig);
        Logger.Info($"Toegevoegd: {voertuig}");
    }

    // 2E.4
    public void Huur(string id)
    {
        Voertuig? voertuig = _voertuigen.FirstOrDefault(v => v.Id == id);

        if (voertuig == null)
            Weiger(id, $"Voertuig {id} bestaat niet.");

        if (!voertuig!.IsBeschikbaar)
            Weiger(id, $"Voertuig {id} is niet beschikbaar.");

        if (voertuig is IOplaadbaar oplaadbaar && oplaadbaar.AccuPercentage < 20)
            Weiger(id, $"Voertuig {id} heeft een te lege accu ({oplaadbaar.AccuPercentage}%, minimaal 20% nodig).");

        voertuig.IsBeschikbaar = false;
        Logger.Info($"Verhuurd: {voertuig.Id}");
    }

    // 2E.5
    public decimal Retourneer(string id, int minuten)
    {
        Voertuig? voertuig = _voertuigen.FirstOrDefault(v => v.Id == id);

        if (voertuig == null)
            Weiger(id, $"Voertuig {id} bestaat niet.");

        voertuig!.IsBeschikbaar = true;
        decimal prijs = voertuig.BerekenPrijs(minuten);
        Logger.Info($"Retour: {voertuig.Id} na {minuten} minuten, prijs EUR {prijs:0.00}");
        return prijs;
    }

    // 2E.6: upcasting via de interface, met LINQ OfType<T>()
    public void LaadAllesOp()
    {
        List<IOplaadbaar> oplaadbaar = _voertuigen.OfType<IOplaadbaar>().ToList();

        foreach (IOplaadbaar voertuig in oplaadbaar)
        {
            voertuig.LaadOp();
        }

        Logger.Info($"{oplaadbaar.Count} voertuigen opgeladen.");
    }

    // Hulpmethode: eerst loggen als Fout, dan de exception gooien (2F.3)
    private void Weiger(string id, string melding)
    {
        Logger.Fout(melding);
        throw new VoertuigNietBeschikbaarException(id, melding);
    }
}
