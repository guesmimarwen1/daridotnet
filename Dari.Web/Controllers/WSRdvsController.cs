using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dari.Domain.Entities;
using Dari.Service;
using Dari.Data;

namespace Dari.Web.Controllers
{
    public class WSRdvsController : Controller
    {

        ServiceClient cs = new ServiceClient();
        IServiceRDV rs = new ServiceRDV();
        IServiceAnnonce sa = new ServiceAnnonce();
        private Context db = new Context();
        public JsonResult Login()
        {
            List<Client> users = db.Users.ToList();
            return new JsonResult { Data = users, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult getAllAnnonces()
        {
            List<Annonce> annonces = db.Annonces.ToList();
            return new JsonResult { Data = annonces, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult GetMesRendezVous(int id)
        {
            List<RDV> rdvs = db.RDV.Where(t => t.visiteurID == id).ToList();
            return new JsonResult { Data = rdvs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult addRendezVous(int annonceId,int userId, string date)
        {
            RDV rDV = new RDV();
            int connectedUserID = userId;
            rDV.annonceID = annonceId;
            rDV.state = stateRDV.demand;
            rDV.visiteurID = connectedUserID;
            DateTime dd = DateTime.Parse(date);
            rDV.date = dd;
            db.RDV.Add(rDV);
            db.SaveChanges();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult editRendezVous(int id, int userId, [Bind(Include = "date")] RDV rDV)
        {
            rDV = db.RDV.Find(id);
            rDV.state = stateRDV.demand;
            db.RDV.Attach(rDV);
            db.SaveChanges();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult cancelRendezVous(int id)
        {
            RDV rDV = db.RDV.Find(id);
            rDV.state = stateRDV.canceled;
            rs.Update(rDV);
            rs.Commit();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult acceptRendezVous(int id)
        {
            RDV rDV = db.RDV.Find(id);
            rDV.state = stateRDV.accepted;
            rs.Update(rDV);
            rs.Commit();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult refusRendezVous(int id)
        {
            RDV rDV = db.RDV.Find(id);
            rDV.state = stateRDV.refused;
            rs.Update(rDV);
            rs.Commit();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}