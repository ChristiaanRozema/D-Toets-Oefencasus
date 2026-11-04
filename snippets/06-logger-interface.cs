// Loggen via een interface: de klasse weet niet WAARHEEN er gelogd wordt.
public interface ILogger
{
    void Info(string melding);
    void Fout(string melding);
}

public class ConsoleLogger : ILogger
{
    public void Info(string melding) => Console.WriteLine($"[INFO] {melding}");
    public void Fout(string melding) => Console.WriteLine($"[FOUT] {melding}");
}

// Later zonder aanpassing in Verhuurbedrijf:
public class BestandLogger : ILogger
{
    private readonly string _pad;
    public BestandLogger(string pad) => _pad = pad;
    public void Info(string melding) => File.AppendAllText(_pad, $"[INFO] {melding}{Environment.NewLine}");
    public void Fout(string melding) => File.AppendAllText(_pad, $"[FOUT] {melding}{Environment.NewLine}");
}

// In de klasse die logt:
public ILogger Logger { get; set; } = new ConsoleLogger();   // alleen het type ILogger gebruiken
// ...
Logger.Info("Voertuig toegevoegd");
Logger.Fout("Voertuig niet beschikbaar");

// Wisselen: bedrijf.Logger = new BestandLogger("log.txt");
