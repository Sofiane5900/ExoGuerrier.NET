using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGuerrier.NET.Donjon
{
    internal class Loup : Ennemi
    {
        public Loup(string nomEnnemi, int pointsDeVie, int nbDesAttaque)
            : base(nomEnnemi, pointsDeVie, nbDesAttaque) { }
    }
}
