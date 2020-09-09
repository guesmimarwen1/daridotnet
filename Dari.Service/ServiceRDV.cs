using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using Dari.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Service
{
    public class ServiceRDV : Service<RDV>, IServiceRDV
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public ServiceRDV() : base(Uok)
        {

        }


    }
}
