using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    [TrackChanges]
    public class Billett
	{
		public int ID { get; set; }
	    public virtual Reise Reise { get; set; }
        public virtual Kunde Kunde { get; set; }
	}
}