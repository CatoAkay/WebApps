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
        [Required(ErrorMessage = "Oppgi fornavn")]
        public String Fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Oppgi etternavn")]
        public String Etternavn { get; set; }

        [Required(ErrorMessage = "Oppgi email")]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@(?:(?:[a-zA-Z0-9-]+\.)?[a-zA-Z]+\.)?(hotmail|gmail)\.(com|no)$", ErrorMessage ="Skriv inn riktig domene (gmail/hotmail)")]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}", ErrorMessage = "Skriv inn riktig format: abc@mail.com")]
        public String Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Oppgi Telefon!")]
        [StringLength(8,ErrorMessage = "Telefonnummer være 8 tall", MinimumLength = 8)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input må innholde bare tall")]
        public String Telefon { get; set; }

        public virtual Kredittkort Kredittkort { get; set; }
    }
}