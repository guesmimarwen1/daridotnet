using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Dari.Data;
using Dari.Domain.Entities;
using Dari.Service;

namespace Dari.Web.Controllers
{
    public enum FlashMessageType
    {
        Success, Warning, Error
    }


    public class RDVsController : Controller
    {


        public void SetFlash(FlashMessageType type, string text)
        {
            TempData["FlashMessage.Type"] = type;
            TempData["FlashMessage.Text"] = text;
        }


        private Context db = new Context();
        IServiceRDV rs = new ServiceRDV();
        IServiceAnnonce sa = new ServiceAnnonce();

        // GET: RDVs
        public ActionResult Index()
        {
            var rDV = db.RDV.Include(r => r.annonce).Include(r => r.visiteur);
            return View(rDV.ToList());
        }

        // GET: RDVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RDV rDV = rs.GetById((int)id);
            if (rDV == null)
            {
                return HttpNotFound();
            }
            return View(rDV);
        }

        // GET: RDVs/Create
        public ActionResult Create(int annonceId)
        {
            ViewBag.annonceID = annonceId;
            //  ViewBag.visiteurID = new SelectList(db.Clients, "Id", "Nom");
            return View();
        }


        public ActionResult Accept(int rdvID)
        {
            RDV rdv = rs.GetById(rdvID);
            if (rdv.state.Equals(stateRDV.demand))
            {
                rdv.state = stateRDV.accepted;
                rs.Update(rdv);
                rs.Commit();
                SetFlash(FlashMessageType.Success, "RDV Accepted");
            }
            else
            {
                SetFlash(FlashMessageType.Warning, "Can't Accept RDV");
            }
            return RedirectToAction("Index");
        }





        public ActionResult Calender()
        {
            TempData["idUser"] = User.Identity.GetUserId();
            return View();
        }

        public JsonResult GetRDVs()
        {

            int userconnect = Int32.Parse(User.Identity.GetUserId());
            var events = rs.GetAll().Where(t => t.visiteurID == userconnect);

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetRDVse(int id)
        {


            var events = rs.GetAll().Where(t => t.visiteurID == id);

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
































        public ActionResult Cancel(int rdvID)
        {
            RDV rdv = rs.GetById(rdvID);
            if (rdv.state.Equals(stateRDV.accepted))
            {
                DateTime d1 = DateTime.Now;
                DateTime d2 = d1.AddDays(1);
                int res = DateTime.Compare(d2, rdv.date);
                if (res < 0)
                {
                    rdv.state = stateRDV.canceled;
                    rs.Update(rdv);
                    rs.Commit();
                    SetFlash(FlashMessageType.Success, "RDV canceled");
                }
                else
                {
                    SetFlash(FlashMessageType.Error, "Too Late to cancel RDV");
                }

            }

            else
            {
                SetFlash(FlashMessageType.Warning, "Can't cancele RDV");
            }
            return RedirectToAction("Index");
        }


        public ActionResult Refus(int rdvID)
        {
            RDV rdv = rs.GetById(rdvID);
            if (rdv.state.Equals(stateRDV.demand))
            {
                rdv.state = stateRDV.refused;
                rs.Update(rdv);
                rs.Commit();
                SetFlash(FlashMessageType.Success, "RDV refused");
            }
            else
            {
                SetFlash(FlashMessageType.Warning, "Can't refused RDV");
            }
            return RedirectToAction("Index");
        }

        // POST: RDVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int annonceId, [Bind(Include = "date")] RDV rDV)
        {
            if (ModelState.IsValid)
            {
                int connectedUserID = User.Identity.GetUserId<int>();
                rDV.annonceID = annonceId;
                rDV.state = stateRDV.demand;
                rDV.visiteurID = connectedUserID;
                rs.Add(rDV);
                rs.Commit();
                return RedirectToAction("Index", "Annoce");
            }

            ViewBag.annonceID = new SelectList(db.Annonces, "AnnonceId", "Description", rDV.annonceID);
            //ViewBag.visiteurID = new SelectList(db.Clients, "Id", "Nom", rDV.visiteurID);
            return View(rDV);
        }

        // GET: RDVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RDV rDV = db.RDV.Find(id);
            if (rDV == null)
            {
                return HttpNotFound();
            }
            ViewBag.annonceID = new SelectList(db.Annonces, "AnnonceId", "Description", rDV.annonceID);
            // ViewBag.visiteurID = new SelectList(db.Clients, "Id", "Nom", rDV.visiteurID);
            return View(rDV);
        }

        // POST: RDVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,visiteurID,annonceID,state")] RDV rDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.annonceID = new SelectList(db.Annonces, "AnnonceId", "Description", rDV.annonceID);
            //   ViewBag.visiteurID = new SelectList(db.Clients, "Id", "Nom", rDV.visiteurID);
            return View(rDV);
        }

        // GET: RDVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RDV rDV = db.RDV.Find(id);
            if (rDV == null)
            {
                return HttpNotFound();
            }
            return View(rDV);
        }

        // POST: RDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RDV rDV = db.RDV.Find(id);
            db.RDV.Remove(rDV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
