using Resurces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarFarAway.Models
{
    public static class StatusListModel
    {
        public static List<SelectListItem> StatusList = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = Statuses.StatusesDictionary[1] },
            new SelectListItem { Value = "2", Text = Statuses.StatusesDictionary[2] },
            new SelectListItem { Value = "3", Text = Statuses.StatusesDictionary[3] }
        };
    }
}