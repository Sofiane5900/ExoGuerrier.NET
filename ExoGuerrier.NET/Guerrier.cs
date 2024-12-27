using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGuerrier.NET
{
    internal class Guerrier
    {
        private string _nom;
        private int _pointsDeVie;
        private int _nbDesAttaque;

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

        public Guerrier(string Nom, int PointsDeVie, int NbDesAttaque)
        {
            this.Nom = Nom;
            this.PointsDeVie = PointsDeVie;
            this.NbDesAttaque = NbDesAttaque;
        }

        // Méthodes publique

        public string GetNom() => Nom;

        public int GetPointsDeVie() => PointsDeVie;

        public int GetNbDesAttaque() => NbDesAttaque;

        // Méthodes essentielles
        public void AfficherInfos()
        {
            GetNom();
            GetPointsDeVie();
            GetNbDesAttaque();
        }

        public int Attaquer()
        {
            Random random = new Random();
            int dice;
            int degats = 0;
            for (int i = 0; i < NbDesAttaque; i++)
            {
                dice = random.Next(0, 6);
                degats += dice;
            }
            return degats;
        }

        public virtual void SubirDegats(int degats)
        {
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

        public static Guerrier Duel(Guerrier guerrier1, Guerrier guerrier2)
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

            // Idéalement cette ligne ne devrait jamais étre atteinte
            return null;
        }
    }
}
