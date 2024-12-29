using ExoGuerrier.NET.Donjon;
using Spectre.Console;

namespace ExoGuerrier.NET.ModeHistoire.Histoire
{
    internal class Crypte
    {
        private Ennemi squelette;
        private Ennemi zombie;

        public Crypte()
        {
            squelette = new Ennemi("Squelette", 15, 2);
            zombie = new Ennemi("Zombie", 20, 3);
        }

        public void LancerCrypte(Hero hero)
        {
            if (hero == null)
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[red]Erreur : le héros n'a pas été créé.[/]");
                return;
            }

            AnsiConsole.MarkupLine(
                "[bold purple]Vous trouvez la porte de la crypte oubliée et décider la franchir...\n[/]"
            );
            Thread.Sleep(2000);

            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Crypte").LeftJustified().Color(Color.Purple));
            AnsiConsole.MarkupLine("=== Crypte Oubliée ===\n");

            AnsiConsole.MarkupLine(
                "Les murs sont recouverts de mousse, et l'air sent l'humidité et la poussière."
            );
            AnsiConsole.MarkupLine(
                "L'atmosphère est oppressante et vous entendez des bruits étranges provenant des ténèbres."
            );
            AnsiConsole.MarkupLine("Au fond du couloir, trois chemins s'offrent à vous :");
            AnsiConsole.MarkupLine(
                "[yellow]1. Prendre le chemin droit qui mène à l'entrée principale de la crypte.[/]"
            );
            AnsiConsole.MarkupLine(
                "[plum2]2. S'engager dans un passage étroit à gauche, où il fait sombre et silencieux.[/]"
            );
            AnsiConsole.MarkupLine(
                "[red]3. Explorer le passage mystérieux à droite qui semble mener à un tombeau ancien.[/]"
            );

            // Choix du joueur
            string choixCrypte = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Que faites-vous ?[/]")
                    .AddChoices("Aller tout droit", "Passage à gauche", "Passage à droite")
            );

            switch (choixCrypte)
            {
                case "Aller tout droit":
                    squelette.EvenementAleatoire(10, hero, squelette);
                    break;
                case "Passage à gauche":
                    hero.RecevoirPotions();
                    AnsiConsole.MarkupLine(
                        "[bold green]Vous trouvez une [plum2] potion de soin[/] dans le passage sombre ![/]"
                    );
                    break;
                case "Passage à droite":
                    zombie.EvenementAleatoire(10, hero, zombie);
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Option invalide. Essayez de nouveau.[/]");
                    break;
            }

            AnsiConsole.MarkupLine(
                "[italic purple]Vous continuez votre exploration de la crypte...[/]"
            );
            Thread.Sleep(4000);
        }
    }
}
