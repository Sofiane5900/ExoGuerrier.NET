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
            isGameOver = false;
            Console.Clear();
            introduction.CreationHero();
            this.hero = introduction.Hero; // Le hero de ma classe est maintenant celui de la classe Introduction
            introduction.LancerPrologue();
            // Je verifie pour chaque chapitre si le bool isGameOver est false
            if (!MenuHistoire.isGameOver)
            {
                foret.LancerForet(this.hero);
            }
            if (!MenuHistoire.isGameOver)
            {
                crypte.LancerCrypte(this.hero);
            }
            if (!MenuHistoire.isGameOver)
            {
                boss.LancerBoss(this.hero);
            }
            if (!MenuHistoire.isGameOver)
            {
                final.LancerFinal(this.hero);
            }
        }
    }
}
