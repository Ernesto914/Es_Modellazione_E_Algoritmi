using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Modellazione_E_Algoritmi.Library
{
    public class Ordine
    {
        public DateTime Data { get; set; }
        public int Quantita { get; set; }
        public Pubblicazione Pubblicazione { get; set; }
    }
}
