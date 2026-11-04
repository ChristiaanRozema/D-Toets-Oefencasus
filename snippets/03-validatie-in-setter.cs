// Waarde bewaken in de setter, met een eigen achterliggend veld.
private int _accuPercentage;

public int AccuPercentage
{
    get => _accuPercentage;
    private set
    {
        if (value < 0 || value > 100)
            throw new ArgumentOutOfRangeException(nameof(AccuPercentage), value,
                "Moet tussen 0 en 100 liggen.");
        _accuPercentage = value;      // 'value' = de waarde die wordt toegewezen
    }
}

// In de constructor: AccuPercentage = accu;   (NIET _accuPercentage = accu, anders sla je de controle over)

// ArgumentException            -> ongeldige waarde (bv. leeg id)
// ArgumentOutOfRangeException  -> getal buiten toegestaan bereik
// ArgumentNullException        -> null terwijl dat niet mag
