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
            Console.WriteLine($"{Nom} a subi {degats} dégâts, il lui reste {PointsDeVie} PV.");
            if (PointsDeVie < 0)
            {
                PointsDeVie = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Nom} est mort.");
                Console.ResetColor();
            }
        }
    }
}
