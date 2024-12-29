using ExoGuerrier.NET.ModeHistoire;
using ExoGuerrier.NET.ModeHistoire.Histoire;
using Spectre.Console;

namespace ExoGuerrier.NET.Donjon
{
    internal class MenuHistoire
    {
        private Introduction introduction;
        private Foret foret;
        private Hero hero;
        private Crypte crypte;
        private Boss boss;
        private Final final;

        public MenuHistoire()
        {
            this.introduction = new Introduction();
            this.hero = null; // Le hero de ma classe est null tant qu'il n'est pas crée
            this.foret = new Foret();
            this.crypte = new Crypte();
            this.boss = new Boss();
            this.final = new Final();
        }

        public static bool isGameOver = false;

        public static void GameOver()
        {
            isGameOver = true;
            Console.Clear();
            AnsiConsole.MarkupLine("[bold red]GAME OVER[/]");
            AnsiConsole.MarkupLine("[italic grey]Votre aventure se termine ici...[/]");
            AnsiConsole.MarkupLine(
                "[bold yellow]Réessayez, aventurier. Le monde a besoin de vous.[/]"
            );
        }

        public void StartModeHistoire()
        {
            Console.Clear();
            introduction.CreationHero();
            this.hero = introduction.Hero; // Le hero de ma classe est maintenant celui de la classe Introduction
            introduction.LancerPrologue();
            // Si le bool isGameOver est faux, alors on lance la suite du prologue
            if (!MenuHistoire.isGameOver)
            {
                foret.LancerForet(this.hero);
                crypte.LancerCrypte(this.hero);
                boss.LancerBoss(this.hero);
                final.LancerFinal(this.hero);
            }
        }
    }
}
