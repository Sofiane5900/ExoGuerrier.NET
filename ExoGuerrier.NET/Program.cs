using ExoGuerrier.NET;

Guerrier galahad = new Guerrier("Galahad", 30, 5);
Guerrier lancelot = new Guerrier("Lancelot", 30, 5);
Nain gimli = new Nain("Gimli", 35, 2, true);
Elfe legolas = new Elfe("Legolas", 25, 7);
int degats;
degats = legolas.Attaquer();
gimli.SubirDegats(degats);
degats = gimli.Attaquer();
legolas.SubirDegats(degats);

gimli.AfficherInfos();

void AfficherMenu()
{
    while (true)
    {
        Console.WriteLine("=== Menu ⚔︎ ===\n");
        Console.WriteLine("1-- Ajouter un guerrier");
        Console.WriteLine("2-- Afficher tout les guerriers");
        Console.WriteLine("3-- Lancer un tournoi");
        Console.Write("Faites votre choix : ");
        int choixMenu;
        bool successChoixMenu = int.TryParse(Console.ReadLine(), out choixMenu);
        if (!successChoixMenu)
        {
            Console.WriteLine("Vous n'étes pas autorisée a effectuer cette action.");
        }
    }
}
