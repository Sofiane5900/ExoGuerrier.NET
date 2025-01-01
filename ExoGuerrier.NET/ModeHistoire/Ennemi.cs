using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET;
using ExoGuerrier.NET.ModeHistoire;
using ExoGuerrier.NET.ModeHistoire.Histoire;
using Spectre.Console;

namespace ExoGuerrier.NET.Donjon
{
    internal class Ennemi
    {
        private string _nomEnnemi;
        private int _pointsDeVie;
        private int _nbDesAttaque;

        public string NomEnnemi
        {
            get => _nomEnnemi;
            set => _nomEnnemi = value;
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

        public Ennemi(string nomEnnemi, int pointsDeVie, int nbDesAttaque)
        {
            this.NomEnnemi = nomEnnemi;
            this.PointsDeVie = pointsDeVie;
            this.NbDesAttaque = nbDesAttaque;
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

        public void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            if (PointsDeVie < 0)
            {
                PointsDeVie = 0;
            }
            Console.WriteLine(
                $"{NomEnnemi} a subi {degats} dégâts, il lui reste {PointsDeVie} PV."
            );
            if (PointsDeVie == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{NomEnnemi} est mort.");
                Console.ResetColor();
            }
        }
    }
}
