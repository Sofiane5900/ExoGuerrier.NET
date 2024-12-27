using System.Drawing;
using ExoGuerrier.NET;

Guerrier galahad = new Guerrier("Galahad", 30, 5);
Guerrier lancelot = new Guerrier("Lancelot", 30, 5);
Nain gimli = new Nain("Gimli", 35, 2, true);
Elfe legolas = new Elfe("Legolas", 30, 5);
List<Guerrier> listGuerriers = new List<Guerrier>();
listGuerriers.Add(galahad);
listGuerriers.Add(lancelot);
listGuerriers.Add(gimli);
listGuerriers.Add(legolas);
AfficherMenu();
void AfficherMenu()
{
    while (true)
    {
        Console.WriteLine("=== Menu Duel ===\n");
        Console.WriteLine("1-- Ajouter un guerrier");
        Console.WriteLine("2-- Afficher tout les guerriers");
        Console.WriteLine("3-- Lancer un tournoi");
        Console.WriteLine("0-- Quitter");

        Console.Write("Faites votre choix : ");
        int choixMenu;
        bool successChoixMenu = int.TryParse(Console.ReadLine(), out choixMenu);
        if (!successChoixMenu)
        {
            InterditSaisie();
        }

        switch (choixMenu)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                AjoutGuerrier();
                break;
            case 2:
                Console.Clear();
                AfficherListeGuerriers();
                break;
            case 3:
                LancerTournoi();
                break;
            default:
                InterditSaisie();
                break;
        }
    }
}

void AjoutGuerrier()
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
        InterditSaisie();
    }

    switch (choixAjoutMenu)
    {
        case 0:
            Console.Clear();
            break;
        case 1:
            Console.Write("Nom du guerrier :");
            string nomAjoutGuerrier = Console.ReadLine();
            Console.Write("PV du guerrier :");
            int pvAjoutGuerrier;
            bool successPvAjoutGuerrier = int.TryParse(Console.ReadLine(), out pvAjoutGuerrier);
            if (!successPvAjoutGuerrier || pvAjoutGuerrier <= 0)
            {
                InterditSaisie();
                break;
            }
            Console.Write("Nombre d'ATQ du guerrier :");
            int nbATQAjoutGuerrier;
            bool successnbATQAjoutGuerrier = int.TryParse(
                Console.ReadLine(),
                out nbATQAjoutGuerrier
            );
            if (!successnbATQAjoutGuerrier || nbATQAjoutGuerrier <= 0)
            {
                InterditSaisie();
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
            Console.WriteLine("Guerrier ajouté avec success !");
            Console.ResetColor();
            break;
        case 2:
            Console.Write("Nom du Nain :");
            string nomAjoutNain = Console.ReadLine();
            Console.Write("PV du Nain :");
            int pvAjoutNain;
            bool successpvAjoutNain = int.TryParse(Console.ReadLine(), out pvAjoutNain);
            if (!successpvAjoutNain || pvAjoutNain <= 0)
            {
                InterditSaisie();
                break;
            }
            Console.Write("Nombre d'ATQ du Nain :");
            int nbATQAjoutNain;
            bool successnbATQAjoutNain = int.TryParse(Console.ReadLine(), out nbATQAjoutNain);
            if (!successnbATQAjoutNain || nbATQAjoutNain <= 0)
            {
                InterditSaisie();
                break;
            }
            Console.Write("Le Nain porte t'il une armure lourde ? (true/false) :");
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
                InterditSaisie();
                break;
            }
            break;
        case 3:
            Console.Write("Nom de l'Elfe :");
            string nomAjoutElfe = Console.ReadLine();
            Console.Write("PV de l'Elfe :");
            int pvAjoutElfe;
            bool successPvAjoutElfe = int.TryParse(Console.ReadLine(), out pvAjoutElfe);
            if (!successPvAjoutElfe || pvAjoutElfe <= 0)
            {
                InterditSaisie();
                break;
            }
            Console.Write("Nombre d'ATQ de l'Elfe :");
            int nbATQAjoutElfe;
            bool succesNbATQAjoutElfe = int.TryParse(Console.ReadLine(), out nbATQAjoutElfe);
            if (!succesNbATQAjoutElfe || nbATQAjoutElfe <= 0)
            {
                InterditSaisie();
                break;
            }
            Elfe elfeAjout = new Elfe(nomAjoutElfe, pvAjoutElfe, nbATQAjoutElfe);
            listGuerriers.Add(elfeAjout);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Elfe {nomAjoutElfe} ajouté avec success !");
            Console.ResetColor();
            break;
        default:
            InterditSaisie();
            break;
    }
}

void InterditSaisie()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Vous n'étes pas autorisée a effectuer cette action.");
    Console.ResetColor();
}

void AfficherListeGuerriers()
{
    Console.Clear();
    Console.WriteLine("=== Afficher tout les guerriers ===");
    foreach (Guerrier guerrier in listGuerriers)
    {
        guerrier.GetNom();
    }
}

void LancerTournoi()
{
    Console.Clear();
    Console.WriteLine("=== Lancer un tournoi ===");

    if (listGuerriers.Count < 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Il faut au moins deux guerriers pour lancer un tournoi.");
        Console.ResetColor();
    }

    // Création d'une copie de la liste des guerriers pour les participants
    List<Guerrier> participants = new List<Guerrier>(listGuerriers);
    Random randomGuerrier = new Random();

    while (participants.Count > 1)
    {
        // Sélection aléatoire de deux guerriers
        int index1 = randomGuerrier.Next(participants.Count);
        // Je selectionne un guerrier aleatoire
        Guerrier guerrier1 = participants[index1];
        // Je le retire de ma liste des participants pour éviter toute selection multiples
        participants.RemoveAt(index1);

        int index2 = randomGuerrier.Next(participants.Count);
        Guerrier guerrier2 = participants[index2];
        participants.RemoveAt(index2);

        Console.WriteLine($"Combat entre {guerrier1.GetNom()} et {guerrier2.GetNom()}");
        Thread.Sleep(1000);

        Guerrier gagnant = Guerrier.Duel(guerrier1, guerrier2);
        Console.WriteLine($"Le gagnant est {gagnant.GetNom()}\n");

        // Je re-ajoute le gagnant a la liste des participants
        participants.Add(gagnant);
    }

    // Le dernier guerrier restant est le champion
    Guerrier champion = participants[0];
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Le champion du tournoi est {champion.GetNom()} !");
    Console.ResetColor();
}
