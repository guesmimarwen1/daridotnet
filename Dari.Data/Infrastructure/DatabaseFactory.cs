using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        Context ctxt;
        public DataBaseFactory()
        {
            ctxt = new Context();
        }
        public Context Ctxt { get { return ctxt; } }
        public override void DisposeCore()
        {
            if (ctxt != null)
                ctxt.Dispose();
        }
    }
}
