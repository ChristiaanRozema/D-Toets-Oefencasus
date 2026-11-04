// Eigen exception: erft van Exception, geeft de melding door aan de basis.
public class VoertuigNietBeschikbaarException : Exception
{
    public string VoertuigId { get; }

    public VoertuigNietBeschikbaarException(string voertuigId, string melding) : base(melding)
    {
        VoertuigId = voertuigId;
    }
}

// Gooien:
throw new VoertuigNietBeschikbaarException(id, "Voertuig is niet beschikbaar.");

// Afvangen (specifiekste exception eerst):
try
{
    bedrijf.Huur("T1");
}
catch (VoertuigNietBeschikbaarException ex)
{
    Console.WriteLine($"Sorry: {ex.Message}");   // ex.VoertuigId is ook beschikbaar
}
