using ExoGuerrier.NET;


Hero galahad = new Hero("Galahad", 30, 1, false);
Hero lancelot = new Hero("Lancelot", 30, 1, false);
Nain gimli = new Nain("Gimli", 30, 1, true);
Elfe legolas = new Elfe("Legolas", 30, 1, false);
List<Hero> listHeros = new List<Hero> { galahad, lancelot, gimli, legolas };
Sauvegarde sauvegarde = new Sauvegarde(listHeros);
Creation creation = new Creation(listHeros, sauvegarde);
Menu menu = new Menu(listHeros, sauvegarde, creation);
menu.AfficherMenu();
