using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Modellazione_E_Algoritmi.Library
{
    public class Abbonamento
    {
        public Periodicita Periodicita { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Scadenza { get; set; }
        public Abbonato Abbonato { get; set; }
        public Pubblicazione Pubblicazione { get; set; }

        public override string ToString()
        {
            return $"{Abbonato.Nome}; {Periodicita}; {Scadenza};";
        }
    }
}
