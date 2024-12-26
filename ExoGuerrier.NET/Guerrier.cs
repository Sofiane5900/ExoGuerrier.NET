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
            _nom = Nom;
            _pointsDeVie = PointsDeVie;
            _nbDesAttaque = NbDesAttaque;
        }

        // Méthodes publique
        public string GetNom()
        {
            Console.WriteLine($"Nom: {Nom}");
            return Nom;
        }

        public int GetPointsDeVie()
        {
            Console.WriteLine($"PV: {PointsDeVie}");
            return PointsDeVie;
        }

        public void SetPointsDeVie(int setPointsDeVie)
        {
            PointsDeVie = setPointsDeVie;
        }

        public int GetNbDesAttaque()
        {
            Console.WriteLine($"Nombres des attaques : {NbDesAttaque}");
            return NbDesAttaque;
        }

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
            int totalDegats = 0;
            for (int i = 0; i < NbDesAttaque; i++)
            {
                dice = random.Next(1, 6);
                totalDegats += dice;
            }
            return totalDegats;
        }

        // J'utilise une méthode virtual, qui peut étre override dans une autre classe
        public void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            Console.WriteLine($"{Nom} a subi {degats} dégâts, il lui reste {PointsDeVie} PV.");
            if (PointsDeVie <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Nom} est mort.");
                Console.ResetColor();
            }
        }
    }
}
