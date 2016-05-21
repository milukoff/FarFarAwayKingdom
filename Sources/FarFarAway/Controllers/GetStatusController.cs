using FarFarAway.Models;
using FarFarAway.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FarFarAway.Controllers
{
    public class GetStatusController : ApiController
    {
        private FarFarAwayDbContext db = new FarFarAwayDbContext();

        public StatusApiModel Get()
        {
            StatusApiModel statusApiModel = new StatusApiModel
            {
                Status = 0
            };
            try
            {
                var q = (from s in db.Status
                         select new StatusApiModel
                         {
                             Status = s.Status,
                             Date = s.Date
                         }).FirstOrDefault();
                if (q != null) return q;
            }
            catch
            {

            }
            return statusApiModel;
        }
    }
}
