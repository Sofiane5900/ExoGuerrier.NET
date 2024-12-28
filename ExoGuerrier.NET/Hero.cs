using System;
using System.Text.Json.Serialization;

namespace ExoGuerrier.NET
{
    internal class Hero : ICloneable
    {
        private string _nom;
        private int _pointsDeVie;
        private int _nbDesAttaque;
        private bool _armureLourde;
        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }
        public int PointsDeVie
        {
            get => _pointsDeVie;
            set => _pointsDeVie = value;
        }
        public int NbDesAttaque
        {
            get => _nbDesAttaque;
            set => _nbDesAttaque = value;
        }
        public bool ArmureLourde
        {
            get => _armureLourde;
            set => _armureLourde = value;
        }

        public Hero(string Nom, int PointsDeVie, int NbDesAttaque, bool ArmureLourde)
        {
            this.Nom = Nom;
            this.PointsDeVie = PointsDeVie;
            this.NbDesAttaque = NbDesAttaque;
            this.ArmureLourde = ArmureLourde;
        }

        // Méthodes publiques
        public string GetNom() => Nom;

        public int GetPointsDeVie() => PointsDeVie;

        public int GetNbDesAttaque() => NbDesAttaque;

        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Nom: {Nom}, PV: {PointsDeVie}, ATQ: {NbDesAttaque}");
        }

        public int Attaquer()
        {
            Random random = new Random();
            int degats = 0;
            for (int i = 0; i < NbDesAttaque; i++)
            {
                degats += random.Next(1, 7); // Dés de 1 à 6
            }
            return degats;
        }

        public virtual void SubirDegats(int degats)
        {
            if (ArmureLourde)
            {
                degats /= 2;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    $"{Nom} porte une armure lourde, les dégâts sont réduits de moitié !"
                );
                Console.ResetColor();
            }
            PointsDeVie -= degats;
            if (PointsDeVie < 0)
            {
                PointsDeVie = 0;
            }
            Console.WriteLine($"{Nom} a subi {degats} dégâts, il lui reste {PointsDeVie} PV.");
            if (PointsDeVie == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Nom} est mort.");
                Console.ResetColor();
            }
        }

        public static Hero Duel(Hero guerrier1, Hero guerrier2)
        {
            while (guerrier1.PointsDeVie > 0 && guerrier2.PointsDeVie > 0)
            {
                int degats = guerrier1.Attaquer();
                guerrier2.SubirDegats(degats);

                if (guerrier2.PointsDeVie <= 0)
                {
                    Console.WriteLine($"{guerrier1.Nom} a gagné le duel !");
                    return guerrier1;
                }

                degats = guerrier2.Attaquer();
                guerrier1.SubirDegats(degats);

                if (guerrier1.PointsDeVie <= 0)
                {
                    Console.WriteLine($"{guerrier2.Nom} a gagné le duel !");
                    return guerrier2;
                }
            }

            return null; // Cette ligne ne devrait jamais être atteinte
        }

        public object Clone()
        {
            return new Hero(this.Nom, this.PointsDeVie, this.NbDesAttaque, this.ArmureLourde);
        }
    }
}
