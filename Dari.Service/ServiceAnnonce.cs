using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dari.ServicePattern;


namespace Dari.Service
{
    public class ServiceAnnonce : Service<Annonce>, IServiceAnnonce
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public ServiceAnnonce() : base(Uok)
        {

        }

        /*public IEnumerable<Annonce> ListeAnnonce()
        {
            
        }*/
    }
}
