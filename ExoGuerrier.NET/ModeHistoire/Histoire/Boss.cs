using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET.Donjon;
using Spectre.Console;

namespace ExoGuerrier.NET.ModeHistoire.Histoire
{
    internal class Boss
    {
        private Ennemi ennemi;

        public Boss()
        {
            ennemi = new Ennemi("Seigneur Liche", 40, 3);
        }

        public void LancerBoss(Hero hero)
        {
            //TODO: Crée une methode dans une classe "UtilsHistoire" pour check si le hero est null
            if (hero == null)
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[red]Erreur : le héros n'a pas été créé.[/]");
                return;
            }
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Boss").LeftJustified().Color(Color.Purple));
            AnsiConsole.MarkupLine("=== Crypte Oubliée ===\n");
            AnsiConsole.MarkupLine(
                "[italic darkviolet]Vous avez trouvé la crypte du Seigneur Liche, le boss de ce donjon ![/]"
            );
            AnsiConsole.MarkupLine(
                "[yellow]Le Seigneur Liche apparaît dans une aura de ténèbres...\n[/]"
            );
            Thread.Sleep(2000);
            AnsiConsole.MarkupLine(
                "[bold darkviolet]Seigneur Liche :[/] [italic]\"Préparez-vous à affronter la mort, aventurier !\"[/]"
            );

            AnsiConsole.MarkupLine(
                $"[bold green]{hero.GetNom()} :[/] [italic]\"Je n'ai pas parcouru ce chemin pour reculer devant toi, créature des ténèbres ! Prépare-toi à être détruit.\"[/]"
            );

            AnsiConsole.MarkupLine(
                "[bold darkviolet]Seigneur Liche :[/] [italic]\"Pauvre fou... Tu oses me défier ? Je suis le maître des âmes perdues. Ton courage sera ta perte.\"[/]"
            );

            AnsiConsole.MarkupLine(
                $"[bold green]{hero.GetNom()} :[/] [italic]\"Le courage est tout ce qu'il me reste, et cela suffira pour te renvoyer d'où tu viens.\"[/]"
            );

            AnsiConsole.MarkupLine(
                "[bold darkviolet]Seigneur Liche :[/] [italic]\"Alors viens, mortel. Montre-moi de quoi tu es capable... avant que je ne prenne ton âme.\"[/]"
            );

            string choixBoss = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Que faites-vous ?[/]")
                    .AddChoices("Attaquer", "Fuir")
            );

            switch (choixBoss)
            {
                case "Attaquer":
                    ennemi.Combat(hero, ennemi);
                    break;
                case "Fuir":
                    Console.Clear();
                    AnsiConsole.MarkupLine(
                        "[italic]Vous avez fui le combat.... le village n'éxiste plus..[/]"
                    );
                    Thread.Sleep(3000);
                    MenuHistoire.GameOver();
                    break;
                default:
                    break;
            }
        }
    }
}
