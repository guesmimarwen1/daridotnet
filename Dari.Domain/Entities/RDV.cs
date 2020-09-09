using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{

    public enum stateRDV
    {
        demand, accepted, refused, canceled
    }

    public class RDV
    {
        [Key]
        public int id { get; set; }

        public DateTime date { get; set; }
        public int visiteurID { get; set; }
        public int annonceID { get; set; }
        public stateRDV state { get; set; }
        public virtual Annonce annonce { get; set; }
        public virtual Client visiteur { get; set; }
    }
}
