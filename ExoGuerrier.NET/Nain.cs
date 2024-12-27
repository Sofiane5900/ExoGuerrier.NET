using ExoGuerrier.NET;

public class Nain : Hero
{
    private bool _armureLourde;

    public bool ArmureLourde
    {
        get => _armureLourde;
        set => _armureLourde = value;
    }

    public Nain(string Nom, int PointsDeVie, int NbDesAttaque, bool ArmureLourde)
        : base(Nom, PointsDeVie, NbDesAttaque, ArmureLourde)
    {
        this.ArmureLourde = ArmureLourde;
    }
}
