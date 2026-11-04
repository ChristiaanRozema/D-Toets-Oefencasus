namespace DeelMobiel;

// 2B. Interface: alles wat een accu heeft en opgeladen kan worden.
public interface IOplaadbaar
{
    int AccuPercentage { get; }
    void LaadOp();
}
