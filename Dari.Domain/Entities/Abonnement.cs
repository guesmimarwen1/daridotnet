using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
    public class Abonnement
    {

         [Key]
         [Column(Order = 1)]
        public int Clientfk { get; set; }
         [Key]
         [Column(Order = 2)]
        public int Productfk { get; set; }
      
        
        [Display(Name = "Date "), DataType(DataType.DateTime)]
       
        public DateTime DateAchat { get; set; }
        public DateTime DateFin { get; set; }
        public Client Client { get; set; }

    }
}
