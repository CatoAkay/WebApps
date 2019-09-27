using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
	public class Billett
	{
		public int ID { get; set; }
		public String To { get; set; }
		public String From { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-YYYY}", ApplyFormatInEditMode = true)]
		public DateTime Date { get; set; }
		public virtual Kunde Kunde { get; set; }
	}
}