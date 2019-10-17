using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    public class Reise
    {
        public int ID { get; set; }
		[Required(ErrorMessage ="Du må velge en strekning")]
		public String Fra { get; set; }
		[Required(ErrorMessage = "Du må velge en strekning")]
		public String Til { get; set; }
		[Required(ErrorMessage = "Du må velge dato")]
		public String Dato { get; set; }
		[Required(ErrorMessage = "Du må velge tid")]
		public String Tid { get; set; }

        public Double Pris { get; set; }
        public String Spor { get; set; }
        public String Tog { get; set; }
        public int Bytter { get; set; }
        public String Avgang { get; set; }
        public String Ankomst { get; set; }


        public IEnumerable<String> getAlleTider()
        {
            return new List<String>
            {
                "00:00",
                "01:00",
                "02:00",
                "03:00",
                "04:00",
                "05:00",
                "06:00",
                "07:00",
                "08:00",
                "09:00",
                "10:00",
                "11:00",
                "12:00",
                "13:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00",
                "18:00",
                "19:00",
                "20:00",
                "21:00",
                "22:00",
                "23:00",
            };
        }

        public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<String> tider)
        {
            var valgteListe = new List<SelectListItem>();
            foreach (var tid in tider)
            {
                valgteListe.Add(new SelectListItem
                {
                    Value = tid,
                    Text = tid
                });
            }
            return valgteListe;
        }

    }
}