using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Kredittkort
    {
        public int ID { get; set; }

        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Oppgi kredittkortnummer")]
        [StringLength(16, ErrorMessage = "Kredittkortnummer må være 16 tall", MinimumLength = 16)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input må innholde bare tall")]
        public String Kortnummer { get; set; }

        [Required(ErrorMessage = "Oppgi utløpsdato")]
        [RegularExpression(@"^\d{2}\/\d{2}$", ErrorMessage = "Må være slik: xx/xx")]
        public String Utlopsdato { get; set; }

        [Display(Name = "CVC")]
        [Required(ErrorMessage = "Oppgi CVC")]
        [StringLength(3, ErrorMessage = "CVC må være 3 tall", MinimumLength = 3)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Input må innholde bare tall")]
        public String Cvc { get; set; }
    }
}