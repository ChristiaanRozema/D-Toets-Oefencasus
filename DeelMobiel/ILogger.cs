namespace DeelMobiel;

// 2F. Abstractie voor logging: Verhuurbedrijf kent alleen deze interface.
public interface ILogger
{
    void Info(string melding);
    void Fout(string melding);
}
