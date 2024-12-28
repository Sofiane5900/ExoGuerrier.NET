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
            Hero hero = introduction.Hero;
        }

        public void StartModeHistoire()
        {
            Console.Clear();
            introduction.CreationHero(hero);
            introduction.LancerPrologue();
            foret.LancerForet(hero);
        }
    }
}
