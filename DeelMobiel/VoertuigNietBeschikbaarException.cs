namespace DeelMobiel;

// 2D. Eigen exception. Wordt gegooid in Verhuurbedrijf.Huur (en Retourneer bij onbekend id).
public class VoertuigNietBeschikbaarException : Exception
{
    public string VoertuigId { get; }

    public VoertuigNietBeschikbaarException(string voertuigId, string melding) : base(melding)
    {
        VoertuigId = voertuigId;
    }
}
