using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Admin
    {
        public int ID { get; set; }
        [DisplayName("Brukernavn")]
        [Required(ErrorMessage = "Fyll inn brukernavn")]
        public String Brukernavn { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fyll inn passord")]
        public String Passord { get; set; }
        [NotMapped]
        public string loginMsgError { get; set; }

    }
}