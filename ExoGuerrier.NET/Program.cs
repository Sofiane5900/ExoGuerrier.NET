using ExoGuerrier.NET;

Guerrier galahad = new Guerrier("Galahad", 30, 6);
Guerrier lancelot = new Guerrier("Lancelot", 30, 6);
Nain gimli = new Nain("Gimli", 35, 3, true);

int degats = galahad.Attaquer();
galahad.Attaquer();
gimli.SubirDegats(degats);
degats = gimli.Attaquer();
galahad.SubirDegats(degats);

gimli.AfficherInfos();
