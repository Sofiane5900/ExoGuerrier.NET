using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ExoGuerrier.NET.Histoire
{
    internal class Foret
    {
        public Foret() { }

        public void LancerForet()
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Foret").LeftJustified().Color(Color.Green));
            AnsiConsole.WriteLine("=== Chemin Forestier  ===\n");
            AnsiConsole.MarkupLine(
                "[white]Vous entrez dans une forêt dense, où l'air est frais mais lourd de mystère. Les arbres forment une voûte naturelle qui assombrit le chemin devant vous.[/]"
            );
            AnsiConsole.MarkupLine(
                "[grey]Des bruits légers de branches qui craquent et des chuchotements du vent brisent le silence. Vous sentez que vous n'êtes pas seul.[/]"
            );
            AnsiConsole.MarkupLine(
                "[italic silver]À chaque pas, vos bottes s'enfoncent légèrement dans le sol humide, et un frisson vous parcourt l'échine.[/]"
            );
            AnsiConsole.MarkupLine(
                "\nUn ancien panneau à moitié effacé vous avertit : [red bold]\"Danger : créatures hostiles.\"[/]"
            );
            AnsiConsole.MarkupLine(
                "[yellow]Le chemin devant vous semble s'étirer sans fin, et vous hésitez sur la direction à prendre...[/]"
            );
            // Choix du chemin
            var choixForet = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Quel chemin choisissez-vous ?[/]")
                    .AddChoices(
                        "Chemin sûr mais plus long",
                        "Chemin rapide mais risqué",
                        "Explorer la forêt à l'aveugle"
                    )
            );

            switch (choixForet)
            {
                case "Chemin sûr mais plus long":
                    EvenementAleatoire(5);
                    break;
                case "Chemin rapide mais risqué":
                    EvenementAleatoire(10);
                    break;
                case "Explorer la forêt à l'aveugle":
                    EvenementAleatoire(19);
                    break;
                default:
                    break;
            }
        }

        private void EvenementAleatoire(int chance)
        {
            Random random = new Random();
            int aleatoire = random.Next(1, 20);
            if (aleatoire <= chance)
            {

            }
        }

        }
    }
}
