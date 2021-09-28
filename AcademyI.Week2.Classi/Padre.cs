using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.Classi
{
    public abstract class Padre
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Stampa()
        {
            return $"{Id} - {Nome}";
        }

        public abstract void CalcolaEta(); // I figli DEVONO avere e implemetare il metodo

        public virtual string Saluta()  // Do la possibilita di eseguire l'override 
        {
            return $"Ciao a tutti";
        }
    }
}
