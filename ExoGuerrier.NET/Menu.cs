using System.Text.Json;
using ExoGuerrier.NET.Donjon;
using ExoGuerrier.NET.Histoire;
using Spectre.Console;

namespace ExoGuerrier.NET
{
    internal class Menu
    {
        private List<Hero> listHeros;
        private Sauvegarde sauvegarde;
        private MenuDonjon menuDonjon;

        public Menu(List<Hero> listHeros, Sauvegarde sauvegarde, MenuDonjon menuDonjon)
        {
            this.listHeros = listHeros;
            this.sauvegarde = sauvegarde;
            this.menuDonjon = menuDonjon;
        }

        public void AfficherMenu()
        {
            while (true)
            {
                sauvegarde.ChargerHeros(out listHeros);
                AnsiConsole.Write(
                    new FigletText("Donjon & Heros").LeftJustified().Color(Color.Red)
                );
                var affichageMenu = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("=== Menu ===")
                        .PageSize(5)
                        .AddChoices(
                            new[]
                            {
                                "Ajouter un hero",
                                "Afficher tous les heros",
                                "Lancer un tournoi",
                                "Entre dans le mode donjon",
                                "Quitter",
                            }
                        )
                );

                int choixMenu = affichageMenu switch
                {
                    "Ajouter un hero" => 1,
                    "Afficher tous les heros" => 2,
                    "Lancer un tournoi" => 3,
                    "Entre dans le mode donjon" => 4,
                    "Quitter" => 0,
                    _ => -1,
                };

                switch (choixMenu)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        AjoutHero();
                        sauvegarde.SauvegarderHeros(listHeros);
                        break;
                    case 2:
                        Utils.AfficherListeHeros(listHeros, sauvegarde);
                        break;
                    case 3:
                        Console.Clear();
                        LancerTournoi();
                        break;
                    case 4:
                        Console.Clear();
                        menuDonjon.LancerDonjon();
                        break;
                    default:
                        Utils.InterditSaisie();
                        break;
                }
            }
        }

        public void AjoutHero()
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Creation de Hero").LeftJustified().Color(Color.Red));

            var choixAjoutPrompt = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("=== Sélectionnez une [green]option[/] pour créer un personnage : ===")
                    .AddChoices("Guerrier", "Nain", "Elfe", "Retour")
            );

            int choixAjoutMenu = choixAjoutPrompt switch
            {
                "Guerrier" => 1,
                "Nain" => 2,
                "Elfe" => 3,
                "Retour" => 0,
                _ => -1,
            };

            switch (choixAjoutMenu)
            {
                case 0:
                    Console.Clear();
                    return;
                case 1:
                    AjouterPersonnage("Guerrier");
                    break;
                case 2:
                    AjouterPersonnage("Nain");
                    break;
                case 3:
                    AjouterPersonnage("Elfe");
                    break;
                default:
                    Utils.InterditSaisie();
                    break;
            }
        }

        public void AjouterPersonnage(string classePersonnage)
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText($"Creation de {classePersonnage}").LeftJustified().Color(Color.Red)
            );

            string nom = AnsiConsole.Ask<string>(
                $"Quel est le [green]nom[/] de votre {classePersonnage} ?"
            );
            if (string.IsNullOrWhiteSpace(nom))
            {
                Utils.InterditSaisie();
                return;
            }

            int pv = AnsiConsole.Prompt(
                new TextPrompt<int>(
                    $"Combien de [red]points de vie[/] pour le {classePersonnage} ?"
                )
                    .DefaultValue(30)
                    .Validate(value =>
                        value > 0
                            ? ValidationResult.Success()
                            : ValidationResult.Error(
                                "[red]Les points de vie doivent être supérieurs à 0.[/]"
                            )
                    )
            );

            int nbATQ = AnsiConsole.Prompt(
                new TextPrompt<int>($"Nombre d'[green]attaques[/] pour le {classePersonnage} ?")
                    .DefaultValue(5)
                    .Validate(value =>
                        value > 0
                            ? ValidationResult.Success()
                            : ValidationResult.Error(
                                "[red]Le nombre d'attaques doit être supérieur à 0.[/]"
                            )
                    )
            );

            bool porteArmure = false;
            if (classePersonnage == "Nain")
            {
                porteArmure = AnsiConsole.Confirm(
                    "Le Nain porte-t-il une [yellow]armure lourde[/] ?"
                );
            }

            Hero nouveauHero = null;
            switch (classePersonnage)
            {
                case "Guerrier":
                    nouveauHero = new Hero(nom, pv, nbATQ, false);
                    break;
                case "Nain":
                    nouveauHero = new Nain(nom, pv, nbATQ, porteArmure);
                    break;
                case "Elfe":
                    nouveauHero = new Elfe(nom, pv, nbATQ, false);
                    break;
            }

            listHeros.Add(nouveauHero); // Ajoute directement au même objet listHeros

            // Sauvegarde après ajout
            sauvegarde.SauvegarderHeros(listHeros);

            Console.Clear();
            Utils.AfficherListeHeros(listHeros, sauvegarde);
            AnsiConsole.MarkupLine($"[green]{classePersonnage} {nom} ajouté avec succès ![/]");
        }

        private void LancerTournoi()
        {
            Console.Clear();
            Console.WriteLine("=== Lancer un tournoi ===");

            if (listHeros.Count < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il faut au moins deux heros pour lancer un tournoi.");
                Console.ResetColor();
                Console.Write("Appuyez sur n'importe quelle touche pour retourner au menu : ");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Création d'une liste de participants en clonant les heros originaux
            List<Hero> participants = new List<Hero>();
            foreach (Hero hero in listHeros)
            {
                participants.Add((Hero)hero.Clone());
            }

            Random randomHero = new Random();

            while (participants.Count > 1)
            {
                int index1 = randomHero.Next(participants.Count);
                Hero hero1 = participants[index1];
                participants.RemoveAt(index1);

                int index2 = randomHero.Next(participants.Count);
                Hero hero2 = participants[index2];
                participants.RemoveAt(index2);

                Console.WriteLine($"Combat entre {hero1.GetNom()} et {hero2.GetNom()}");

                Thread.Sleep(1000);

                Hero gagnant = Hero.Duel(hero1, hero2);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Le gagnant du duel est {gagnant.GetNom()}\n");
                Console.ResetColor();

                participants.Add(gagnant);
            }

            Hero champion = participants[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Le champion du tournoi est {champion.GetNom()} !");
            Console.ResetColor();

            Console.Write("Voulez-vous lancer un autre tournoi ? (o/n) : ");
            string choixTournoi = Console.ReadLine().ToLower();
            if (choixTournoi == "o")
            {
                LancerTournoi();
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
