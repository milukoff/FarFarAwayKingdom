using FarFarAway.Models;
using FarFarAway.Models.Edit;
using FarFarAway.Models.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FarFarAway.Controllers
{
    public class AdminStatusController : Controller
    {
        private FarFarAwayDbContext db = new FarFarAwayDbContext();
        // GET: AdminStatus
        public ActionResult Index()
        {
            EditStatusViewModel editStatusViewModel = new EditStatusViewModel
            {
                Date = DateTime.Now,
                Status = 0
            };
            try
            {
                var q = (from s in db.Status
                         select new EditStatusViewModel
                         {
                             Id = s.Id,
                             Status = s.Status,
                             Date = s.Date
                         }).FirstOrDefault();

                if (q != null) editStatusViewModel = q;
                if (q.Date == DateTime.MinValue)
                {
                    editStatusViewModel.Date = DateTime.Now;
                }
                List<SelectListItem> StatusList = StatusListModel.StatusList;
                ViewBag.StatusList = StatusList;
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
            return View(editStatusViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EditStatusViewModel editStatusViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (editStatusViewModel != null && editStatusViewModel.Id == 0)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    StatusModel statusModel = db.Status.Find(editStatusViewModel.Id);
                    if (statusModel == null)
                    {
                        return HttpNotFound();
                    }

                    statusModel.Status = editStatusViewModel.Status;
                    statusModel.Date = editStatusViewModel.Date;
                    db.Entry(statusModel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");

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
            List<SelectListItem> StatusList = StatusListModel.StatusList;
            ViewBag.StatusList = StatusList;
            return View(editStatusViewModel);
        }
        
    }
}