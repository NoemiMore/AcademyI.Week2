using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.Classi
{
    class LaMiaClasse
    {
        // Campi

        public int count;
        public string nome;

        public int id;
        public int eta;

        // Proprietà

        public int Id { get; set; }
        public int Eta
        {
            get
            {
                // 30
                return eta;
            }
            set
            {
                // 2021 - 1991
                eta = DateTime.Now.Year - value;
            }
        }

        public int IdEsplicito
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Nome { get; private set; }

        public string Cognome { private get; set; }

        // Costruttori
        // Se non definisco construttori, il costruttore "base" esiste implicitamente
        public LaMiaClasse()
        {

        }

        public LaMiaClasse(int id)
        {
            Id = id;
        }

        // Metodi

        public string StampaNome()
        {
            return $"{Nome}";
        }

        // Distruttori
        ~LaMiaClasse()
        {
            //lmc = null;
        }

    }
}
