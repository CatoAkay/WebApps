using System;

namespace Model
{
    public class Logging
    {
        public int ID { get; set; }
        public string Entitet { get; set; }
        public string Egenskap { get; set; }
        public string Nokkelverdi { get; set; }
        public string GammelVerdi { get; set; }
        public string NyVerdi { get; set; }
        public DateTime DatoEndret { get; set; }
    }
}