using ExoGuerrier.NET;

Sauvegarde sauvegarde = new Sauvegarde();
Hero galahad = new Hero("Galahad", 30, 1, false);
Hero lancelot = new Hero("Lancelot", 30, 1, false);
Nain gimli = new Nain("Gimli", 30, 1, true);
Elfe legolas = new Elfe("Legolas", 30, 1, false);
List<Hero> listHeros = new List<Hero> { galahad, lancelot, gimli, legolas };

Menu menu = new Menu(listHeros, sauvegarde);
menu.AfficherMenu();
