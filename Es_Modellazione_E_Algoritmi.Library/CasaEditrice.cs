using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Modellazione_E_Algoritmi.Library
{
    public class CasaEditrice
    {
        public List<Abbonato> Abbonati = new();
        public List<PuntoVendita> PuntiVendita = new();
        public List<Pubblicazione> Pubblicazioni = new();

        public List<Abbonamento> AbbonamentiInScadenza(int mese, int anno)
        {
            if (mese < 1 || mese > 12)
                throw new ArgumentOutOfRangeException("ERRORE: mese non valido.");

            List<Abbonamento> abbonamentiInScadenza = new();

            foreach (var abbonato in Abbonati)
            {
                foreach (var abbonamento in abbonato.Abbonamenti)
                {
                    if (abbonamento.Scadenza.Month.Equals(mese)
                        && abbonamento.Scadenza.Year.Equals(anno))
                        abbonamentiInScadenza.Add(abbonamento);
                }
            }

            return abbonamentiInScadenza;
        }

        public bool ERinnovato(Abbonamento abbonamentoDaCercare)
        {
            TimeSpan differenzaTraDate;

            foreach (var abbonato in Abbonati)
            {
                if (abbonato.Abbonamenti.Contains(abbonamentoDaCercare))
                {
                    foreach (var abbonamento in abbonato.Abbonamenti)
                    {
                        differenzaTraDate = abbonamento.Inizio - abbonamentoDaCercare.Scadenza;
                        if (differenzaTraDate > TimeSpan.Zero
                            && abbonamento.Pubblicazione == abbonamentoDaCercare.Pubblicazione)
                            return true;
                    }
                }
            }

            return false;
        }

        public List<Abbonamento> AbbonamentiInScadenzaNonRinnovati(int mese, int anno)
        {
            if (mese < 1 || mese > 12)
                throw new ArgumentOutOfRangeException("ERRORE: mese non valido.");

            List<Abbonamento> abbonamentiInScadenza = AbbonamentiInScadenza(mese, anno);
            List<Abbonamento> abbonamentiInScadenzaNonRinnovati = new();

            foreach (var abbonamento in abbonamentiInScadenza)
            {
                if (!ERinnovato(abbonamento))
                    abbonamentiInScadenzaNonRinnovati.Add(abbonamento);
            }

            return abbonamentiInScadenzaNonRinnovati;
        }

        public decimal ImportoTotalePerAnno (int anno, string istitutoDiRicerca)
        {
            decimal importoTotalePerAnno = 0;

            foreach (var puntoVendita in PuntiVendita)
            {
                if (puntoVendita.IstitutoDiRicerca.ToLower() == istitutoDiRicerca.ToLower())
                    foreach (var ordine in puntoVendita.Ordini)
                        if (ordine.Data.Year.Equals(anno))
                            importoTotalePerAnno += ordine.Pubblicazione.PrezzoUnitario * ordine.Quantita;
            }

            return importoTotalePerAnno;
        }

        public Pubblicazione RivistaPiuCostosa()
        {
            decimal prezzoUnitarioMaggiore = 0;
            Pubblicazione rivistaPiuCostosa = null;

            foreach (var pubblicazione in Pubblicazioni) 
            {
                if (prezzoUnitarioMaggiore < pubblicazione.PrezzoUnitario)
                {
                    prezzoUnitarioMaggiore = pubblicazione.PrezzoUnitario;
                    rivistaPiuCostosa = pubblicazione;
                }
            }

            return rivistaPiuCostosa;
        }

        public StringBuilder ElencoRivisteDiUnAmbitoPerAnno (int anno, string ambito)
        {
            StringBuilder elencoRivisteDiUnAmbitoPerAnno = new();

            foreach(var pubblicazione in Pubblicazioni)
            {
                if (pubblicazione.Ambito.ToLower().Equals(ambito.ToLower())
                    && pubblicazione.Data.Year.Equals(anno))
                    elencoRivisteDiUnAmbitoPerAnno.AppendLine(pubblicazione.ToString());
            }

            return elencoRivisteDiUnAmbitoPerAnno;
        }
    }
}
