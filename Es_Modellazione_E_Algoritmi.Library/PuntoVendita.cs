using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Modellazione_E_Algoritmi.Library
{
    public class PuntoVendita
    {
        public List<Ordine> Ordini = new();
        public  string IstitutoDiRicerca { get; set; }
        public  string Nazione { get; set; }
    }
}
