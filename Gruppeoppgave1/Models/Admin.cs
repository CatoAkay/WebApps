using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Admin
    {
        public int ID { get; set; }

        [DisplayName("Brukernavn")]
        [Required(ErrorMessage = "Fyll inn brukernavn")]
        public string Brukernavn { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fyll inn passord")]
        public string Passord { get; set; }
        [NotMapped]
        public string LoginMsgError { get; set; }

    }
    
}