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
    public class ServiceClient : Service<Client>, IServiceClient
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public ServiceClient() : base(Uok)
        {

        }
    }
}
