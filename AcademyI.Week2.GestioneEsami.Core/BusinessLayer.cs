using AcademyI.Week2.GestioneEsami.Core.Entities;
using AcademyI.Week2.GestioneEsami.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyI.Week2.GestioneEsami.Core
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryCorsiDiLaurea corsiDiLaureaRepo;
        private readonly IRepositoryImmatricolazione immatricolazioneRepo;
        private readonly IRepositoryStudente studenteRepo;
        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiDiLaurea corsiDiLaurea, 
            IRepositoryImmatricolazione immatricolazione, IRepositoryStudente studente)
        {
            corsiRepo = corsi;
            corsiDiLaureaRepo = corsiDiLaurea;
            immatricolazioneRepo = immatricolazione;
            studenteRepo = studente;
        }

        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInizio = DateTime.Now;
            imm._CorsoDiLaurea = GetCorsi(cdl);

            int ore = imm.DataInizio.Hour;
            int minuti = imm.DataInizio.Minute;
            var secondi = imm.DataInizio.Second;
            var matricola = String.Concat(ore, minuti, secondi);

            imm.Matricola = Convert.ToInt32(matricola);

            immatricolazioneRepo.Insert(imm);
            imm = immatricolazioneRepo.GetByDate(imm);

            s.IdImmatricolazione = imm.Id;
            s._Immatricolazione = imm;

            studenteRepo.Insert(s);

            return s;
        }

        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRepo.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRepo.GetCorsiByCorsoDiLaurea(cdl);
            cdl.Corsi = corsi;
            var cfuTotali = corsi.Sum(c => c.CreditiFormativi);
            cdl.Cfu = cfuTotali;
            return cdl;
        }

        public bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s)
        {
            var cfuOk = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi <= s._Immatricolazione._CorsoDiLaurea.Cfu;
            if (cfuOk && !s.LaureaRichiesta)
                return true;
            else
                return false;
        }

        public Esame AggiungiEsame(Esame esameDaSostenere)
        { return esameRepo.AddToListEsami(EsameDaSostenere); }


        public bool RandomEsamePassato(Esame esameDaSostenere, Studente s)
        { List<Corso> corsi = corsiRepo.Fetch();
            var cfuPerCorso = 0;
            foreach (var c in corsi)
            { if (c.Nome == esameDaSostenere.Nome)
                { cfuPerCorso = c.CreditiFormativi; }
                var yes = s._Immatricolazione.CfuAccumulati += cfuPerCorso;

                if (yes == s._Immatricolazione._CorsoDiLaurea.Cfu
                    )
                { s.LaureaRichiesta = true; }
                return true;
                        
                        }
        }
    }
}
