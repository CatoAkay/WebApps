using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Reise
    {
        public String Fra { get; set; }
        public String Til { get; set; }
        public String Dato { get; set; }
        public String Tid { get; set; }
        public Double Pris { get; set; }
    }
}