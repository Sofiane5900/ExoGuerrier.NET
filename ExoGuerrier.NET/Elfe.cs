using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGuerrier.NET
{
    internal class Elfe : Guerrier
    {
        public Elfe(string Nom, int PointsDeVie, int NbDesAttaque)
            : base(Nom, PointsDeVie, NbDesAttaque) { }

        public int Attaquer()
        {
            int totalDegats = 0;
            totalDegats = Math.Max(totalDegats, NbDesAttaque);
            return totalDegats;
        }
    }
}
