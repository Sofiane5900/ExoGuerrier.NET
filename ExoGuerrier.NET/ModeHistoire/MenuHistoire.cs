﻿using ExoGuerrier.NET.ModeHistoire.Histoire;

namespace ExoGuerrier.NET.Donjon
{
    internal class MenuHistoire
    {
        private Introduction introduction;
        private Foret foret;
        private Hero hero;

        public MenuHistoire()
        {
            this.introduction = new Introduction();
            this.foret = new Foret();
            this.hero = null;
        }

        public void StartModeHistoire()
        {
            Console.Clear();
            introduction.CreationHero();
            this.hero = introduction.Hero;
            introduction.LancerPrologue();
            foret.LancerForet(this.hero);
        }
    }
}
