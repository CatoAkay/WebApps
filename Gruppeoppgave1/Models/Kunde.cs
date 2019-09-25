using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Kunde
    {
        public int ID { get; set; }
        public String Fornavn { get; set; }
        public String Etternavn { get; set; }
        public int Fodselsdato { get; set; }

    }
}