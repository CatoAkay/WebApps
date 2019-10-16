using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave1.Models
{

    public class KundeReise
    {
        public Kunde kunde { get; set; }
        public Reise reise { get; set; }

        public IEnumerable<SelectListItem> reiseTidene { get; set; }
    }
}