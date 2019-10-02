using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class KundeReise
    {
        public Kunde kunde { get; set; }
        public Reise reise { get; set; }

        /*public KundeReise(Reise reise)
        {
            this.reise = reise;
        }
        */
    }
}