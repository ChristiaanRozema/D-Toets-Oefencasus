// Singleton: precies één instantie in het hele programma.
public class Verhuurbedrijf
{
    private static readonly Verhuurbedrijf _instance = new Verhuurbedrijf(); // 1 object, aangemaakt bij start
    public static Verhuurbedrijf Instance => _instance;                      // enige toegang van buiten

    private Verhuurbedrijf() { }                                             // private: geen "new" van buitenaf
}

// Gebruik:
var a = Verhuurbedrijf.Instance;
var b = Verhuurbedrijf.Instance;
Console.WriteLine(ReferenceEquals(a, b));   // True

// Dat is design pattern "Singleton". Noem dat in een commentaar erbij.
