using FarFarAway.Models;
using FarFarAway.Models.Edit;
using FarFarAway.Models.View;
using Resurces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarFarAway.Controllers
{
    public class HomeController : Controller
    {
        private FarFarAwayDbContext db = new FarFarAwayDbContext();
        public ActionResult Index()
        {
            StatusViewModel StatusViewModel = new StatusViewModel
            {
                Date = DateTime.Now,
                Status = 0,
                StatusName = null
            };
            try
            {
                List<SelectListItem> StatusList = StatusListModel.StatusList;
                var q = (from s in db.Status
                         select new EditStatusViewModel
                         {
                             Id = s.Id,
                             Status = s.Status,
                             Date = s.Date
                         }).FirstOrDefault();

                if (q != null)
                {
                    if (Statuses.StatusesDictionary.ContainsKey(q.Status))
                    {
                        StatusViewModel.StatusName = Statuses.StatusesDictionary[q.Status];
                    }
                    else StatusViewModel.StatusName = "Неизвестный статус";
                    StatusViewModel.Date = q.Date;
                    StatusViewModel.Status = q.Status;
                } 

            }
            catch (Exception exception)
            {
                Exception ie = exception;
                System.Text.StringBuilder sb = new System.Text.StringBuilder("Error. ");
                while (ie != null)
                {
                    sb.AppendFormat("{0} ", ie.Message);
                    ie = ie.InnerException;
                }
                throw new ApplicationException(sb.ToString());
            }
            return View(StatusViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Веб-сайт для оповещения пользоветелей о предстоящих и текущих регламентных работах интернет-сервиса ЛАРЕЦ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты разработчика";

            return View();
        }
    }
}