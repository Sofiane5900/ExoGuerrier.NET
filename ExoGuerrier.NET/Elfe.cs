using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGuerrier.NET
{
    internal class Elfe : Hero
    {
        public Elfe(string Nom, int PointsDeVie, int NbDesAttaque, bool ArmureLourde)
            : base(Nom, PointsDeVie, NbDesAttaque, ArmureLourde) { }

        public int Attaquer()
        {
            int degats = NbDesAttaque;
            return degats;
        }
    }
}
