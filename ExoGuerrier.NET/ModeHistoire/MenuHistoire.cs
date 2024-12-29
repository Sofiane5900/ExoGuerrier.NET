using ExoGuerrier.NET.ModeHistoire.Histoire;

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
            this.hero = null; // Le hero de ma classe est null tant qu'il n'est pas crée
        }

        public void StartModeHistoire()
        {
            Console.Clear();
            introduction.CreationHero();

            this.hero = introduction.Hero; // Le hero de ma classe est maintenant celui de la classe Introduction
            introduction.LancerPrologue();
            foret.LancerForet(this.hero);
        }
    }
}
