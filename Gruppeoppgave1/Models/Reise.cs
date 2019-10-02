using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Reise
    {
        public int ID { get; set; }
        public String Fra { get; set; }
        public String Til { get; set; }
        public String Dato { get; set; }
        public String Tid { get; set; }
        public Double Pris { get; set; }

        /*
        public Reise(int iD, string fra, string til, string dato, string tid, double pris)
        {
            ID = iD;
            Fra = fra;
            Til = til;
            Dato = dato;
            Tid = tid;
            Pris = pris;
        }
        */
    }
}