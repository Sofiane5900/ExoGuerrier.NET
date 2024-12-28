using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ExoGuerrier.NET.Histoire
{
    internal class Introduction
    {
        private Hero hero;
        private string nomHero;

        public string NomHero
        {
            get => nomHero;
            set => nomHero = value;
        }
        public Hero Hero
        {
            get => hero;
            set => hero = value;
        }

        public Introduction()
        {
            this.nomHero = string.Empty;
            this.hero = null;
        }

        public void CreationHero()
        {
            Console.Clear();
            while (true)
            {
                AnsiConsole.Write(new FigletText("Prologue").LeftJustified().Color(Color.Red));
                AnsiConsole.WriteLine("=== Création du personnage ===\n");
                AnsiConsole.Write("Quel est votre nom, aventurier ? : ");
                string nomHero = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nomHero))
                {
                    Console.Clear();
                    AnsiConsole.WriteLine("Vous devez entrer un nom pour continuer.");
                    continue;
                }
                else
                {
                    NomHero = nomHero;
                }
                string choixCreationPrompt = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("=== Sélectionnez une [green]classe[/] pour votre Hero : ===")
                        .AddChoices("Guerrier", "Nain", "Elfe", "Retour")
                );
                switch (choixCreationPrompt)
                {
                    case "Guerrier":
                        Hero = new Hero(nomHero, 30, 5, false);
                        break;
                    case "Nain":
                        Hero = new Nain(nomHero, 30, 5, false);
                        break;
                    case "Elfe":
                        Hero = new Elfe(nomHero, 30, 5, false);
                        break;
                    case "Retour":
                        Console.Clear();
                        continue;
                    default:
                        break;
                }
                Console.Clear();
                AnsiConsole.WriteLine($"Bienvenue {NomHero}, chargement....");
                Thread.Sleep(2000);
                break;
            }
        }

        public void LancerPrologue()
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Prologue").LeftJustified().Color(Color.Red));
            AnsiConsole.WriteLine("=== Prologue - Le début de l'aventure ===\n");
            // Description du village
            AnsiConsole.MarkupLine(
                "[yellow]Vous vous tenez dans le petit village de Valombre.[/] Les maisons en pierre sont anciennes, et l'air frais du matin vous donne une sensation de calme."
            );
            AnsiConsole.MarkupLine(
                "[yellow]La place du village est animée par quelques marchands et villageois,[/] mais quelque chose ne va pas. Les murmures se propagent parmi les habitants."
            );
            AnsiConsole.MarkupLine(
                "\nUne rumeur court : [red]des créatures mystérieuses ont été aperçues[/] près de la forêt voisine, et un mal ancien semble renaître..."
            );

            // Appel du maire
            AnsiConsole.MarkupLine(
                "\n  [blue]Le Maire[/] du village, un vieil homme, vous appelle."
            );
            AnsiConsole.MarkupLine(
                $"[blue]Le Maire :[/] \"{NomHero}, nous avons besoin de vous. Notre village est en danger. Les créatures des ténèbres se rassemblent à la [magenta]Crypte Obscure[/], à l'est. Seul un courageux aventurier comme vous peut espérer stopper cette menace.\""
            );

            AnsiConsole.MarkupLine(
                "[blue]Le Maire[/] [white] vous tend une carte du village et de la région environnante,[/] avec la [magenta]Crypte Obscure[/] marquée d'un symbole étrange."
            );
            AnsiConsole.MarkupLine(
                "\n[blue]Le Maire :[/] \"Je vous en prie, allez à la [magenta]Crypte[/], explorez les lieux, et si vous en avez la force, détruisez ce mal avant qu'il ne soit trop tard. Le destin de Valombre repose entre vos mains.\""
            );

            // Choix du joueur
            var choixMission = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Acceptez-vous cette mission ?[/]")
                    .AddChoices("Oui", "Non")
            );

            if (choixMission == "Oui")
            {
                AnsiConsole.MarkupLine(
                    "\n[blue]Le Maire :[/] \"Parfait, je savais que je pouvais compter sur vous ! Allez, et que la chance soit avec vous. Les ténèbres ne feront que croître si nous ne réagissons pas.\""
                );
                AnsiConsole.MarkupLine(
                    "[yellow]Vous prenez la carte et vous vous dirigez vers l'est, prêt à explorer la [magenta]Crypte Obscure[/].[/]"
                );
            }
            else
            {
                Console.Clear();
                AnsiConsole.MarkupLine(
                    "\n[blue]Le Maire :[/] \"Je comprends... mais sachez que le mal grandit chaque jour. Revenez lorsque vous serez prêt, le village aura besoin de vous.\""
                );
                AnsiConsole.MarkupLine(
                    "[yellow]Vous vous éloignez, mais un sentiment d'inquiétude vous habite. Vous savez que tôt ou tard, vous devrez affronter ce mal.[/]"
                );
            }
        }
    }
}
