using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
    public enum Etat { neuf, ancien }
    public enum Disponibilite { dispo, indispo }
    public enum Livraison { oui, non }
    public class Meuble
    {
        [Key]
        public int IdMeuble { get; set; }
        public string Titre { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public Livraison Livraison { get; set; }
        public Etat Etat { get; set; }

        public Disponibilite Disponibilite { get; set; }

        public Client Client { get; set; }



    }
}
