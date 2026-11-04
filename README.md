# OOD / Programmeren – hulprepo diagnostische toets

Uitwerking van de testcasus **DeelMobiel** plus spiekbriefjes voor de toets.
Doel: de toets afleggen, geen perfectie.

> Let op: tijdens de toets mag je **geen AI** gebruiken, wel je eigen repo en bronnen op het internet.

## Inhoud

| Map / bestand | Waarvoor |
|---|---|
| `DeelMobiel/` | Complete uitwerking (C# consoleproject) van stap 2 en 3 |
| `uml-cheatsheet.md` | UML-notatie + het klassendiagram van stap 1 (Mermaid) |
| `snippets/` | Eén klein bestand per concept, om te kopiëren/naschrijven |
| `.gitignore` | Standaard voor Visual Studio / dotnet |

## Starten in één minuut (toetsdag)

```
dotnet new console -n DeelMobiel
cd DeelMobiel
dotnet run
```
Of in Visual Studio: *Create a new project → Console App* (C#), naam **DeelMobiel** (dan klopt de namespace meteen).
Nieuwe klasse = nieuw bestand: `Add → Class`, dezelfde namespace houden.

## Casus → patroon (lees dit eerst op de toetsdag)

1. **Zelfstandige naamwoorden** in de casus = klassen. **Werkwoorden** = methoden. **"Heeft een / kan"** = properties.
2. **Hebben ze gemeenschappelijke velden?** → abstracte basisklasse (`abstract class`).
3. **Elke soort rekent iets anders?** → `abstract` methode in de basis, `override` in de subklassen.
4. **Eigenschap die losstaat van de familie** (bv. oplaadbaar) → `interface`.
5. **Dubbele code in twee subklassen?** → extra abstracte tussenklasse.
6. **"Maar één object in het hele programma"** → Singleton.
7. **"Moet later ook naar bestand kunnen"** → interface (`ILogger`) + implementatie, klasse kent alleen de interface.
8. **"Foutmelding / niet toegestaan"** → eigen `Exception` (of `ArgumentException` bij foute invoer).
9. **Lijst intern, niet aanpasbaar naar buiten** → `private List<T>` + `public IReadOnlyList<T>`.

## Volgorde op de toets (advies uit de opdracht: 10 / 40 / 10 min)

1. UML (10 min), netjes maar niet mooi. Pijlen en zichtbaarheid (`+ - #`) moeten kloppen.
2. Code in de volgorde van de deelopdrachten (2A → 2F). Elke stap bouwt voort op de vorige.
3. `Program.cs` (10 min): precies volgens de genummerde lijst.
4. Tijd tekort? Zet in commentaar wat je had willen doen (`// TODO: ...`). Ook dat telt als informatie.
5. Inleveren: klassendiagram + projectmap als `.zip` (zonder `bin/` en `obj/` is prima).

## Veelgemaakte fouten

- `override` vergeten bij `ToString` / `BerekenPrijs`.
- `base(...)` vergeten in de constructor van een subklasse (dan een compileerfout: de basis heeft geen lege constructor).
- Validatie in de constructor in plaats van in de **setter** als de opdracht "in de setter" zegt.
- `decimal`-getallen zonder `m` (`0.10` is een double; `0.10m` is een decimal).
- Een methode die al in de superklasse staat nogmaals declareren zonder dat je hem overridet.
- Exception wel gooien maar niet loggen (of andersom): lees `2F` goed.
- Klasse die direct `ConsoleLogger` gebruikt in plaats van `ILogger`.
- Singleton: constructor niet `private`, of een publieke setter op `Instance`.

## Handige links

- C# overerving: <https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance>
- Interfaces: <https://learn.microsoft.com/dotnet/csharp/fundamentals/types/interfaces>
- Exceptions: <https://learn.microsoft.com/dotnet/csharp/fundamentals/exceptions/>
- Singleton in C#: <https://csharpindepth.com/articles/singleton>
- LINQ `OfType`: <https://learn.microsoft.com/dotnet/api/system.linq.enumerable.oftype>

## Oefenen

1. Bekijk eerst de uitwerking in `DeelMobiel/`.
2. Verwijder alles behalve `Voertuig.cs` + `Fiets.cs` en bouw de rest zelf opnieuw met een timer.
3. Doe daarna dezelfde opdracht voor een andere casus (bibliotheek: Boek / Dvd / Tijdschrift; parkeergarage; gamewinkel).

## Aannames bij deze uitwerking

- Extra abstracte klasse heet `ElektrischVoertuig` (Scooter en ElektrischeStep erven daarvan, en daarmee van `Voertuig`).
- `Retourneer` met een onbekend id gooit ook een `VoertuigNietBeschikbaarException`.
- `Verhuurbedrijf.Logger` staat standaard op `ConsoleLogger`.
- Doelversie is `net8.0`; pas `TargetFramework` in `DeelMobiel.csproj` aan als school een andere versie gebruikt.
