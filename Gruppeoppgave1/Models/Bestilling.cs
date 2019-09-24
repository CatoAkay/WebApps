using System.ComponentModel.DataAnnotations;

namespace Gruppeoppgave1.Models
{
    public class Bestilling
    {
        [Key]
        public int bestillingID { get; set; }
        public int pris { get; set; }
        public string fra { get; set; }
        public string til { get; set; }
        public Kunde Kunde { get; set; }
    }
}