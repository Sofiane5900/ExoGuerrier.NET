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

        public Guerrier(string Nom, int PointsDeVie, int NBDesAttaque)
        {
            _nom = Nom;
            _pointsDeVie = PointsDeVie;
            _nbDesAttaque = NBDesAttaque;
        }

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

        public void SetPointsDeVie(int PointsDeVie) { }
    }
}
