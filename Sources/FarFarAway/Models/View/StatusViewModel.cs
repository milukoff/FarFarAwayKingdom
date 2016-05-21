using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarFarAway.Models.View
{
    public class StatusViewModel
    {
        [Display(Name = "Статус")]
        public string StatusName { get; set; }
        public int Status { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
    }
}