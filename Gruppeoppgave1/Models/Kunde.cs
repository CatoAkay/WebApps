using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        [Display(Name ="Fornavn")]
        [Required(ErrorMessage ="Oppgi fornavn!")]
        public string Fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Oppgi etternavn!")]
        public string Etternavn { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Oppgi adresse!")]
        public string Adresse { get; set; }

        [Display(Name = "Postnummer")]
        [Required(ErrorMessage = "Oppgi postnummer (4 tall)!")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage ="Postnummer er nødt til å være 4 tall!")]
        public int Postnummer { get; set; }

        [Display(Name = "Poststed")]
        [Required(ErrorMessage = "Oppgi poststed!")]
        public string Poststed { get; set; }

    }

 
}