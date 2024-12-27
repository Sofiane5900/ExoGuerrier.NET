using System.Text.Json;
using Spectre.Console;

namespace ExoGuerrier.NET
{
    public class Menu
    {
        private List<Hero> listHeros;
        private Sauvegarde sauvegarde;

        public Menu(List<Hero> listHeros, Sauvegarde sauvegarde)
        {
            this.listHeros = listHeros;
            this.sauvegarde = sauvegarde;
        }

        public void AfficherMenu()
        {
            sauvegarde.SauvegarderHeros(listHeros);
            sauvegarde.ChargerHeros(out listHeros);

            while (true)
            {
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
                                "Entrez dans le mode donjon",
                                "Quitter",
                            }
                        )
                );

                int choixMenu = affichageMenu switch
                {
                    "Ajouter un hero" => 1,
                    "Afficher tous les heros" => 2,
                    "Lancer un tournoi" => 3,
                    "Entrez dans le mode donjon" => 4,
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
                        Utils.AfficherListeHeros(listHeros);
                        break;
                    case 3:
                        Console.Clear();
                        LancerTournoi();
                        break;
                    case 4:
                        break;
                    default:
                        Utils.InterditSaisie();
                        break;
                }
            }
        }

        private void AjoutHero()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter un hero ===");
            Console.WriteLine("1-- hero");
            Console.WriteLine("2-- Nain");
            Console.WriteLine("3-- Elfe");
            Console.WriteLine("0-- Retour");
            Console.Write("Faites votre choix :");
            int choixAjoutMenu;
            bool successChoixAjoutMenu = int.TryParse(Console.ReadLine(), out choixAjoutMenu);
            if (!successChoixAjoutMenu)
            {
                Utils.InterditSaisie();
            }

            switch (choixAjoutMenu)
            {
                case 0:
                    Console.Clear();
                    break;
                case 1:
                    Console.Write("Nom du hero : ");
                    string nomAjouthero = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(nomAjouthero))
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("PV du hero : ");
                    int pvAjouthero;
                    bool successPvAjouthero = int.TryParse(Console.ReadLine(), out pvAjouthero);
                    if (!successPvAjouthero || pvAjouthero <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("Nombre d'ATQ du hero : ");
                    int nbATQAjouthero;
                    bool successnbATQAjouthero = int.TryParse(
                        Console.ReadLine(),
                        out nbATQAjouthero
                    );
                    if (!successnbATQAjouthero || nbATQAjouthero <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Hero heroAjout = new Hero(nomAjouthero, pvAjouthero, nbATQAjouthero, false);
                    listHeros.Add(heroAjout);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("hero ajouté avec succès !");
                    sauvegarde.SauvegarderHeros(listHeros);
                    Console.ResetColor();
                    break;
                case 2:
                    Console.Write("Nom du Nain : ");
                    string nomAjoutNain = Console.ReadLine();
                    Console.Write("PV du Nain : ");
                    int pvAjoutNain;
                    bool successpvAjoutNain = int.TryParse(Console.ReadLine(), out pvAjoutNain);
                    if (!successpvAjoutNain || pvAjoutNain <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("Nombre d'ATQ du Nain : ");
                    int nbATQAjoutNain;
                    bool successnbATQAjoutNain = int.TryParse(
                        Console.ReadLine(),
                        out nbATQAjoutNain
                    );
                    if (!successnbATQAjoutNain || nbATQAjoutNain <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("Le Nain porte-t-il une armure lourde ? (true/false) :");
                    string armureLourdeNain = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(armureLourdeNain))
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    if (armureLourdeNain == "true" || armureLourdeNain == "false")
                    {
                        bool porteArmureLourde = bool.Parse(armureLourdeNain);
                        Nain nainAjout = new Nain(
                            nomAjoutNain,
                            pvAjoutNain,
                            nbATQAjoutNain,
                            porteArmureLourde
                        );
                        listHeros.Add(nainAjout);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Nain {nomAjoutNain} ajouté avec succès !");
                        sauvegarde.SauvegarderHeros(listHeros);
                        Console.ResetColor();
                    }
                    else
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    break;
                case 3:
                    Console.Write("Nom de l'Elfe : ");
                    string nomAjoutElfe = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(nomAjoutElfe))
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("PV de l'Elfe : ");
                    int pvAjoutElfe;
                    bool successPvAjoutElfe = int.TryParse(Console.ReadLine(), out pvAjoutElfe);
                    if (!successPvAjoutElfe || pvAjoutElfe <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("Nombre d'ATQ de l'Elfe : ");
                    int nbATQAjoutElfe;
                    bool succesNbATQAjoutElfe = int.TryParse(
                        Console.ReadLine(),
                        out nbATQAjoutElfe
                    );
                    if (!succesNbATQAjoutElfe || nbATQAjoutElfe <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Elfe elfeAjout = new Elfe(nomAjoutElfe, pvAjoutElfe, nbATQAjoutElfe, false);
                    listHeros.Add(elfeAjout);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Elfe {nomAjoutElfe} ajouté avec succès !");
                    sauvegarde.SauvegarderHeros(listHeros);
                    Console.ResetColor();
                    break;
                default:
                    Utils.InterditSaisie();
                    break;
            }
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
