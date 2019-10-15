using System.Collections.Generic;
using System.Web.Mvc;

namespace Model
{
    public class KundeReise
    {
        public Kunde kunde { get; set; }
        public Reise reise { get; set; }

        public IEnumerable<SelectListItem> reiseTidene { get; set; }
    }
}