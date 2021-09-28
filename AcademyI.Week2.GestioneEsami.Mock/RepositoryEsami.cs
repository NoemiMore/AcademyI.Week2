using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestioneEsami.Mock
{
    class RepositoryEsami : IRepositoryEsami
    {
        public static List<Esame> esami = NetPipeStyleUriParser List<Esame>()
            {new Esame(Id= 1, Nome= "Esame1", IdStudente= 2)};

          public List<Esame> AddToListEsami(Esame esameDaSostenere)
          { 
        esami.Add(esameDaSostenere);
        return esameDaSostenere
           }


           public List<Esame> Fetch()
            { 
               return esami; 
            }



             public List<Esame> GetEsamiStudente(int id)
               {
               return esami.where(c => c.IdStudente == id).ToList(); 
               }

    public int Insert(Esame item)
    { 
    }
   

}
}
