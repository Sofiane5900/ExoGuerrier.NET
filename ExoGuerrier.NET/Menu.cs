using Spectre.Console;

namespace ExoGuerrier.NET
{
    public class Menu
    {
        private List<Guerrier> listGuerriers;

        public Menu(List<Guerrier> guerriers)
        {
            listGuerriers = guerriers;
        }

        public void AfficherMenu()
        {
            while (true)
            {
                AnsiConsole.Write(
                    new FigletText("Duel de Guerrier").LeftJustified().Color(Color.Red)
                );
                var affichageMenu = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("=== Menu Duel ===")
                        .PageSize(4)
                        .AddChoices(
                            new[]
                            {
                                "Ajouter un guerrier",
                                "Afficher tous les guerriers",
                                "Lancer un tournoi",
                                "Quitter",
                            }
                        )
                );

                int choixMenu = affichageMenu switch
                {
                    "Ajouter un guerrier" => 1,
                    "Afficher tous les guerriers" => 2,
                    "Lancer un tournoi" => 3,
                    "Quitter" => 0,
                };

                switch (choixMenu)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        AjoutGuerrier();
                        break;
                    case 2:
                        Utils.AfficherListeGuerriers(listGuerriers);
                        break;
                    case 3:
                        Console.Clear();
                        LancerTournoi();
                        break;
                    default:
                        Utils.InterditSaisie();
                        break;
                }
            }
        }

        private void AjoutGuerrier()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter un guerrier ===");
            Console.WriteLine("1-- Guerrier");
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
                    Console.Write("Nom du guerrier : ");
                    string nomAjoutGuerrier = Console.ReadLine();
                    Console.Write("PV du guerrier : ");
                    int pvAjoutGuerrier;
                    bool successPvAjoutGuerrier = int.TryParse(
                        Console.ReadLine(),
                        out pvAjoutGuerrier
                    );
                    if (!successPvAjoutGuerrier || pvAjoutGuerrier <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Console.Write("Nombre d'ATQ du guerrier : ");
                    int nbATQAjoutGuerrier;
                    bool successnbATQAjoutGuerrier = int.TryParse(
                        Console.ReadLine(),
                        out nbATQAjoutGuerrier
                    );
                    if (!successnbATQAjoutGuerrier || nbATQAjoutGuerrier <= 0)
                    {
                        Utils.InterditSaisie();
                        break;
                    }
                    Guerrier guerrierAjout = new Guerrier(
                        nomAjoutGuerrier,
                        pvAjoutGuerrier,
                        nbATQAjoutGuerrier
                    );
                    listGuerriers.Add(guerrierAjout);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Guerrier ajouté avec succès !");
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
                    string armureLourdeNain = Console.ReadLine();
                    if (armureLourdeNain == "true" || armureLourdeNain == "false")
                    {
                        bool porteArmureLourde = bool.Parse(armureLourdeNain);
                        Nain nainAjout = new Nain(
                            nomAjoutNain,
                            pvAjoutNain,
                            nbATQAjoutNain,
                            porteArmureLourde
                        );
                        listGuerriers.Add(nainAjout);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Nain {nomAjoutNain} ajouté avec succès !");
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
                    string nomAjoutElfe = Console.ReadLine();
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
                    Elfe elfeAjout = new Elfe(nomAjoutElfe, pvAjoutElfe, nbATQAjoutElfe);
                    listGuerriers.Add(elfeAjout);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Elfe {nomAjoutElfe} ajouté avec succès !");
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

            if (listGuerriers.Count < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il faut au moins deux guerriers pour lancer un tournoi.");
                Console.ResetColor();
                Console.Write("Appuyez sur n'importe quelle touche pour retourner au menu : ");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Création d'une liste de participants en clonant les guerriers originaux
            List<Guerrier> participants = new List<Guerrier>();
            foreach (Guerrier guerrier in listGuerriers)
            {
                // Je crée des clones de chaque guerrier présent
                participants.Add((Guerrier)guerrier.Clone());
            }

            // Création d'une copie de la liste des guerriers pour les participants
            Random randomGuerrier = new Random();

            while (participants.Count > 1)
            {
                // Sélection aléatoire de deux guerriers
                int index1 = randomGuerrier.Next(participants.Count);
                Guerrier guerrier1 = participants[index1];
                participants.RemoveAt(index1);

                int index2 = randomGuerrier.Next(participants.Count);
                Guerrier guerrier2 = participants[index2];
                participants.RemoveAt(index2);

                Console.WriteLine($"Combat entre {guerrier1.GetNom()} et {guerrier2.GetNom()}");
                Thread.Sleep(1000);

                Guerrier gagnant = Guerrier.Duel(guerrier1, guerrier2);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Le gagnant du duel est {gagnant.GetNom()}\n");
                Console.ResetColor();

                participants.Add(gagnant);
            }

            Guerrier champion = participants[0];
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
