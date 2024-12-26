using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGuerrier.NET
{
    internal class Nain : Guerrier
    {
        private bool _armureLourde;

        public bool ArmureLourde
        {
            get => _armureLourde;
            set => _armureLourde = value;
        }

        public Nain(string Nom, int PointsDeVie, int NbDesAttaque, bool ArmureLourde)
            : base(Nom, PointsDeVie, NbDesAttaque)
        {
            _armureLourde = ArmureLourde;
        }

        public void SubirDegats(int degats)
        {
            if (_armureLourde = true)
            {
                degats /= 2;
            }
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
