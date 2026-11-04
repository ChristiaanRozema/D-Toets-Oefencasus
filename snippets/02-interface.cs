// Interface: een "contract". Geen velden, geen body (behalve default-implementaties, die je niet nodig hebt).
public interface IOplaadbaar
{
    int AccuPercentage { get; }
    void LaadOp();
}

// Erven en implementeren combineren: eerst de basisklasse, dan de interface(s).
public class Scooter : Voertuig, IOplaadbaar
{
    public int AccuPercentage { get; private set; }
    public void LaadOp() => AccuPercentage = 100;
    // ...
}

// Upcasting via de interface:
IOplaadbaar x = scooter;
List<IOplaadbaar> lijst = voertuigen.OfType<IOplaadbaar>().ToList(); // filtert op type
