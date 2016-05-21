using FarFarAway.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarFarAway.Models
{
    public class StatusBase : Base
    {
        [Display(Name = "Статус")]
        [Required]
        public int Status { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
  
        public DateTime Date { get; set; }
    }
}