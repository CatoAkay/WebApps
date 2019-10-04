using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave1.Models
{
    public class Reise
    {
        public int ID { get; set; }
		[Required(ErrorMessage ="Du må velge en strekning")]
		public String Fra { get; set; }
		[Required(ErrorMessage = "Du må velge en strekning")]
		public String Til { get; set; }
		[Required(ErrorMessage = "Du må velge dato")]
		public String Dato { get; set; }
		[Required(ErrorMessage = "Du må velge tid")]
		public String Tid { get; set; }



        public Double Pris { get; set; }
        public String Spor { get; set; }
        public String Tog { get; set; }
        public int Bytter { get; set; }
        public String Avgang { get; set; }
        public String Ankomst { get; set; }

    }
} 