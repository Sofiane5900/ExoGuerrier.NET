using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET.Histoire;

namespace ExoGuerrier.NET.Donjon
{
    internal class MenuDonjon
    {
        private Introduction introduction;
 
        public MenuDonjon()
        {
            this.introduction = new Introduction(); 
        }

        

        public void LancerDonjon()
        {
            Console.Clear();
            introduction.ChoisirNomHero();
            introduction.LancerPrologue();

            
        }
    }
}