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
        public String Fra { get; set; }
        public String Til { get; set; }
        public String Dato { get; set; }

        [Required]
        [Display(Name = "Tid")]
        public String Tid { get; set; }
        public Double Pris { get; set; }
        public String Spor { get; set; }
        public String Tog { get; set; }
        public int Bytter { get; set; }
        public String Avgang { get; set; }
        public String Ankomst { get; set; }

    }
    /**    public tidar tider { get; set; }
    }
    public enum tidar
    { 

    }   */
} 