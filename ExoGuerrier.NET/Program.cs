using ExoGuerrier.NET;

Sauvegarde sauvegarde = new Sauvegarde();
Guerrier galahad = new Guerrier("Galahad", 30, 5);
Guerrier lancelot = new Guerrier("Lancelot", 30, 5);
Nain gimli = new Nain("Gimli", 35, 2, true);
Elfe legolas = new Elfe("Legolas", 30, 5);
List<Guerrier> listGuerriers = new List<Guerrier> { galahad, lancelot, gimli, legolas };

Menu menu = new Menu(listGuerriers, sauvegarde);
menu.AfficherMenu();
