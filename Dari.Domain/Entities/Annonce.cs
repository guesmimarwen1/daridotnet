using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dari.Domain.Entities
{
    public enum TypeAn { Vente, Location }

    public class Annonce
    {
        [Key]
        public int AnnonceId { get; set; }
        public TypeAn TypeAn { get; set; }
        public string Description { get; set; }
        public string address { get; set; }
        public float surface { get; set; }
        public int chambres { get; set; }
        public int clientId { get; set; }
        public Client client { get; set; }
        public string images { get; set; }
        public virtual ICollection<RDV> RDVS { get; set; }



    }
}
