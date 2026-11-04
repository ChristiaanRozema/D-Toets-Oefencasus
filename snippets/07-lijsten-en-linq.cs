// Lijst intern aanpasbaar, naar buiten alleen-lezen (upcasting naar IReadOnlyList).
private readonly List<Voertuig> _voertuigen = new List<Voertuig>();
public IReadOnlyList<Voertuig> Voertuigen => _voertuigen;

// Zoeken op id (null als niet gevonden):
Voertuig? v = _voertuigen.FirstOrDefault(x => x.Id == id);
if (v == null) throw new VoertuigNietBeschikbaarException(id, "Bestaat niet.");

// Type-filter (alleen de oplaadbare):
List<IOplaadbaar> oplaadbaar = _voertuigen.OfType<IOplaadbaar>().ToList();

// Type-check met pattern matching:
if (v is IOplaadbaar o && o.AccuPercentage < 20) { /* te leeg */ }

// Overig handig:
_voertuigen.Where(x => x.IsBeschikbaar).ToList();
_voertuigen.Any(x => x.Id == id);
foreach (Voertuig x in bedrijf.Voertuigen) Console.WriteLine(x);

// Geldbedragen: decimal en een m-suffix
decimal prijs = 1.00m + 0.25m * minuten;
Console.WriteLine($"€ {prijs:F2}");   // 2 decimalen
