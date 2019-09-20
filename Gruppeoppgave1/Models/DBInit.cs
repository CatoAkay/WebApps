using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var nyKunde = new Kunde
            {
                Fornavn = "Cato"
            };
            context.Kunder.Add(nyKunde);
            base.Seed(context);
        }
    }
}