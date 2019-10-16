using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Logging
    {
        public int ID { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateChanged { get; set; }

    }
}