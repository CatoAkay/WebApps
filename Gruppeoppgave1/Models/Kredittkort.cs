using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Kredittkort
    {
        public int ID { get; set; }

        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Oppgi kredittkortnummer")]
        [StringLength(16, ErrorMessage = "Kredittkortnummer må være 16 tall", MinimumLength = 16)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input må innholde bare tall")]
        public String Kortnummer { get; set; }

        [Display(Name = "Utløpsdato")]
        [Required(ErrorMessage = "Oppgi utløpsdato")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input må innholde bare tall")]
        public String Utløpsdato { get; set; }

        [Display(Name = "CVC")]
        [Required(ErrorMessage = "Oppgi CVC")]
        [StringLength(3, ErrorMessage = "CVC må være 3 tall", MinimumLength = 3)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input må innholde bare tall")]
        public String Cvc { get; set; }
    }
}