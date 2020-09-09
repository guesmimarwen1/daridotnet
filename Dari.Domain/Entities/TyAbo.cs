using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{

    public class TyAbo
    {
        [Key]
        public int IdAbo { get; set; }
        public float Prix { get; set; }
        public string Libelle { get; set; }
        public string TypeAbo { get; set; }
        public string Description { get; set; }
        public int Dure { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Abonnement> Abonnements { get; set; }


    }
}
