using System.Globalization;
using DeelMobiel;

var nl = CultureInfo.GetCultureInfo("nl-NL");

// 1. Singleton: twee keer ophalen, zelfde object?
var bedrijf = Verhuurbedrijf.Instance;
var bedrijf2 = Verhuurbedrijf.Instance;
Console.WriteLine($"Zelfde object? {ReferenceEquals(bedrijf, bedrijf2)}");
Console.WriteLine();

// 2. Voertuigen aanmaken en toevoegen (step heeft 10% accu)
var fiets = new Fiets("F1", "Gazelle", 7);
var scooter = new Scooter("S1", "Niu", "12-AB-34", 80);
var step = new ElektrischeStep("T1", "Xiaomi", 25, 10);

bedrijf.VoegToe(fiets);
bedrijf.VoegToe(scooter);
bedrijf.VoegToe(step);
Console.WriteLine();

// 3. Fiets: huren, na 30 minuten retourneren (verwacht EUR 3,00)
bedrijf.Huur("F1");
decimal prijsFiets = bedrijf.Retourneer("F1", 30);
Console.WriteLine($"Prijs fiets: € {prijsFiets.ToString("F2", nl)}");
Console.WriteLine();

// 4. Scooter: huren, na 20 minuten retourneren (verwacht EUR 6,00)
bedrijf.Huur("S1");
decimal prijsScooter = bedrijf.Retourneer("S1", 20);
Console.WriteLine($"Prijs scooter: € {prijsScooter.ToString("F2", nl)}");
Console.WriteLine();

// 5. Step huren mislukt (accu 10%): exception afvangen, melding tonen
try
{
    bedrijf.Huur("T1");
}
catch (VoertuigNietBeschikbaarException ex)
{
    Console.WriteLine($"Sorry klant: {ex.Message}");
}
Console.WriteLine();

// 6. Alles opladen en de step opnieuw huren
bedrijf.LaadAllesOp();
bedrijf.Huur("T1");
Console.WriteLine("De step is nu wel verhuurd.");
Console.WriteLine();

// 7. Alle voertuigen tonen (overschreven ToString van elke subklasse)
foreach (Voertuig v in bedrijf.Voertuigen)
{
    Console.WriteLine(v);
}
