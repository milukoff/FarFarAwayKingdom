using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarFarAway.Models.Data
{
    public abstract class Base
    {
        [Key()]
        public int Id { get; set; }

    }
}