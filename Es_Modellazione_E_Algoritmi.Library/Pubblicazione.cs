namespace Es_Modellazione_E_Algoritmi.Library
{
    public enum Periodicita
    {
        Quindicinali,
        Mensili,
        Bimestrali,
        Semestrali
    }

    public class Pubblicazione
    {
        public  string Ambito { get; set; }
        public  decimal PrezzoUnitario { get; set; }
        public Periodicita Periodicita { get; set; }
        public DateTime Data { get; set; }

        static public bool operator ==(Pubblicazione pubblicazione, Pubblicazione other)
        {
            return (pubblicazione.Ambito.ToLower() == other.Ambito.ToLower()
                && pubblicazione.PrezzoUnitario == other.PrezzoUnitario
                && pubblicazione.Periodicita == other.Periodicita
                && pubblicazione.Data == other.Data);
        }

        static public bool operator !=(Pubblicazione pubblicazione, Pubblicazione other)
        {
            return !(pubblicazione == other);
        }

        public override string ToString()
        {
            return $"{Ambito}; {PrezzoUnitario}; {Periodicita}; {Data}";
        }
    }
}
