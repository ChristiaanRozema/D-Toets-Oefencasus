namespace DeelMobiel;

// Extra abstracte klasse: alles wat Scooter en ElektrischeStep gemeen hebben
// (accu + opladen), zodat we dat niet twee keer schrijven.
public abstract class ElektrischVoertuig : Voertuig, IOplaadbaar
{
    private int _accuPercentage;

    // 2C.5: validatie in de setter. Alleen deze klasse mag de waarde zetten.
    public int AccuPercentage
    {
        get => _accuPercentage;
        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(AccuPercentage), value,
                    "Het accupercentage moet tussen 0 en 100 liggen.");
            _accuPercentage = value;
        }
    }

    protected ElektrischVoertuig(string id, string merk, int accuPercentage) : base(id, merk)
    {
        AccuPercentage = accuPercentage; // gaat via de setter, dus gevalideerd
    }

    public void LaadOp()
    {
        AccuPercentage = 100;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, accu {AccuPercentage}%";
    }
}
