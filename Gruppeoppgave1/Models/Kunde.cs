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

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Oppgi fornavn!")]
        public String Fornavn { get; set; }


        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Oppgi etternavn!")]
        public String Etternavn { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Oppgi email!")]
        [EmailAddress(ErrorMessage ="Ugyldig email addresse!")]
        public String Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Oppgi Telefon!")]
        [StringLength(8,ErrorMessage = "Telefon numer ma vaere 8 tall lang", MinimumLength = 8)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input ma innholde bare tall")]
        public String Telefon { get; set; }
    }
}