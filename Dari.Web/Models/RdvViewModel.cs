using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dari.Domain.Entities;

namespace Dari.Web.Models
{
    public class RdvViewModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int visiteurID { get; set; }
        public int annonceID { get; set; }
        public stateRDV state { get; set; }
        public virtual Annonce annonce { get; set; }
        public virtual Client visiteur { get; set; }
    }
}