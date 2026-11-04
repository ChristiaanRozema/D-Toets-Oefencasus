# UML-cheatsheet

## Notatie

| Symbool | Betekenis |
|---|---|
| `+` | public |
| `-` | private |
| `#` | protected |
| `naam: type` | property/veld (type achteraan) |
| `Methode(param: type): returntype` | methode |
| `{get}` / `{get; set}` | read-only / lezen en schrijven |
| *cursief* of `{abstract}` | abstracte methode |
| `«abstract»` boven de naam | abstracte klasse |
| `«interface»` boven de naam | interface |
| onderstreept | static |

## Pijlen

| Relatie | Lijn | Pijlpunt | Voorbeeld |
|---|---|---|---|
| Overerving (`: Basis`) | doorgetrokken | holle driehoek naar de basisklasse | Fiets → Voertuig |
| Implementatie (`: IX`) | **gestippeld** | holle driehoek naar de interface | ConsoleLogger ⇢ ILogger |
| Associatie ("heeft") | doorgetrokken | open pijl (+ multipliciteit `0..*`) | Verhuurbedrijf → Voertuig |
| Afhankelijkheid ("gebruikt/gooit") | gestippeld | open pijl | Verhuurbedrijf ⇢ VoertuigNietBeschikbaarException |

## Het klassendiagram van stap 1 (Mermaid, rendert op GitHub)

```mermaid
classDiagram
    direction TB

    class Verhuurbedrijf {
        -static _instance : Verhuurbedrijf
        -_voertuigen : List~Voertuig~
        +static Instance : Verhuurbedrijf  «get»
        +Voertuigen : IReadOnlyList~Voertuig~  «get»
        +Logger : ILogger  «get; set»
        -Verhuurbedrijf()
        +VoegToe(voertuig : Voertuig) void
        +Huur(id : string) void
        +Retourneer(id : string, minuten : int) decimal
        +LaadAllesOp() void
    }

    class Voertuig {
        <<abstract>>
        +Id : string  «get»
        +Merk : string  «get»
        +IsBeschikbaar : bool  «get; set»
        #Voertuig(id : string, merk : string)
        +BerekenPrijs(minuten : int)* decimal
        +ToString() string
    }

    class Fiets {
        +Versnellingen : int  «get»
        +Fiets(id, merk : string, versnellingen : int)
        +BerekenPrijs(minuten : int) decimal
        +ToString() string
    }

    class ElektrischVoertuig {
        <<abstract>>
        +AccuPercentage : int  «get; private set»
        #ElektrischVoertuig(id, merk : string, accuPercentage : int)
        +LaadOp() void
        +ToString() string
    }

    class Scooter {
        +Kenteken : string  «get»
        +Scooter(id, merk, kenteken : string, accuPercentage : int)
        +BerekenPrijs(minuten : int) decimal
        +ToString() string
    }

    class ElektrischeStep {
        +MaximumSnelheid : int  «get»
        +ElektrischeStep(id, merk : string, maximumSnelheid : int, accuPercentage : int)
        +BerekenPrijs(minuten : int) decimal
        +ToString() string
    }

    class IOplaadbaar {
        <<interface>>
        +AccuPercentage : int  «get»
        +LaadOp() void
    }

    class VoertuigNietBeschikbaarException {
        +VoertuigId : string  «get»
        +VoertuigNietBeschikbaarException(voertuigId : string, melding : string)
    }

    class ILogger {
        <<interface>>
        +Info(melding : string) void
        +Fout(melding : string) void
    }

    class ConsoleLogger {
        +Info(melding : string) void
        +Fout(melding : string) void
    }

    Verhuurbedrijf --> "0..*" Voertuig
    Verhuurbedrijf --> "1" ILogger : Logger
    Verhuurbedrijf ..> VoertuigNietBeschikbaarException : gooit
    Verhuurbedrijf ..> IOplaadbaar : LaadAllesOp
    Voertuig <|-- Fiets
    Voertuig <|-- ElektrischVoertuig
    ElektrischVoertuig <|-- Scooter
    ElektrischVoertuig <|-- ElektrischeStep
    IOplaadbaar <|.. ElektrischVoertuig
    ILogger <|.. ConsoleLogger
    Exception <|-- VoertuigNietBeschikbaarException
```

## Waar ze op letten

- Alleen **echt nieuwe of overridden** leden in een subklasse tekenen. `LaadOp` en `AccuPercentage` staan dus alleen in `ElektrischVoertuig`.
- Singleton: private constructor, `static _instance`, `static Instance` (onderstrepen op papier).
- Constructor protected in een abstracte klasse: `#Voertuig(...)`.
- Op papier is zelf een nette tekening met correcte pijlen belangrijker dan een mooie tekening.
