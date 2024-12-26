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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous n'étes pas autorisée a effectuer cette action.");
            Console.ResetColor();
        }

        switch (choixMenu)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
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
    int choixAjoutMenu;
    bool successChoixAjoutMenu = int.TryParse(Console.ReadLine(), out choixAjoutMenu);
    if (!successChoixAjoutMenu)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Vous n'étes pas autorisée a effectuer cette action.");
        Console.ResetColor();
    }

    switch (choixAjoutMenu)
    {
        case 0:
            break;
        case 1:
            Console.Write("Nom du guerrier :");
            Console.ReadLine.
    }
}
