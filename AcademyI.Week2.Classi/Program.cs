using System;

namespace AcademyI.Week2.Classi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Padre p = new Padre();
            //p.Id = 1;
            //p.Nome = "Padre";

            Figlio f = new Figlio();
            f.Id = 2;
            f.Nome = "Figlio";
            f.Cognome = "Cognome del figlio";

            //p.Stampa();
            f.Stampa();






            LaMiaClasse lmc = new LaMiaClasse(); // Costruttore senza parametri

            lmc.Id = 3; // Set -> "salvami" il valore 3 alla proprietà Id

            int id = lmc.Id;   // Get -> dammi il valore della proprietà Id

            lmc.Eta = 1991;

            var eta = lmc.Eta;

            var nome = lmc.Nome; // -> get
            //lmc.Nome = "Arianna";  // -> set

            //var cognome = lmc.Cognome; // -> get
            lmc.Cognome = "Bolzoni";

            lmc = null;
        }
    }
}
