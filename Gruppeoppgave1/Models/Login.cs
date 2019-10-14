using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Login
    {
        public int ID { get; set; }
        [DisplayName("Brukernavn")]
        [Required(ErrorMessage ="Fyll inn brukernavn")]
        public String Brukernavn { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fyll inn passord")]
        public String Passord { get; set; }
        public string loginMsgError { get; set; }
    }
}