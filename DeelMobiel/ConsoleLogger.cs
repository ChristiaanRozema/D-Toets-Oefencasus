namespace DeelMobiel;

public class ConsoleLogger : ILogger
{
    public void Info(string melding)
    {
        Console.WriteLine($"[INFO] {melding}");
    }

    public void Fout(string melding)
    {
        Console.WriteLine($"[FOUT] {melding}");
    }
}
