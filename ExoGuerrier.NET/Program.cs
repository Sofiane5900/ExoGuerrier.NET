using ExoGuerrier.NET;

Guerrier galahad = new Guerrier("Galahad", 30, 5);
Guerrier lancelot = new Guerrier("Lancelot", 30, 5);
Nain gimli = new Nain("Gimli", 35, 2, true);
Elfe legolas = new Elfe("Legolas", 25, 7);
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
        Console.WriteLine("=== Menu ⚔︎ ===\n");
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
            if (!successPvAjoutGuerrier)
            {
                InterditSaisie();
            }
            Console.Write("Nombre d'ATQ du guerrier :");
            int nbATQAjoutGuerrier;
            bool successnbATQAjoutGuerrier = int.TryParse(
                Console.ReadLine(),
                out nbATQAjoutGuerrier
            );
            if (!successnbATQAjoutGuerrier)
            {
                InterditSaisie();
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
            Console.Write("Nom du nain :");
            string nomAjoutNain = Console.ReadLine();
            Console.Write("PV du nain :");
            int pvAjoutNain;
            bool successpvAjoutNain = int.TryParse(Console.ReadLine(), out pvAjoutNain);
            if (!successpvAjoutNain || pvAjoutNain <= 0)
            {
                InterditSaisie();
                break;
            }
            Console.Write("Nombre d'ATQ du nain :");
            int nbATQAjoutNain;
            bool successnbATQAjoutNain = int.TryParse(Console.ReadLine(), out nbATQAjoutNain);
            if (!successnbATQAjoutNain || nbATQAjoutNain <= 0)
            {
                InterditSaisie();
                break;
            }
            Console.Write("Le nain porte t'il une armure lourde ? (true/false) :");
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
                Console.WriteLine("Nain ajouté avec succès !");
                Console.ResetColor();
            }
            else
            {
                InterditSaisie();
            }
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
