using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Modellazione_E_Algoritmi.Library
{
    public class Abbonato
    {
        public List<Abbonamento> Abbonamenti = new();
        public string Nome { get; set; }
        public string Cognome {  get; set; }
        public string Residenza { get; set; }
        public string Telefono { get; set; }
        public string CF { get; set; }
    }
}
