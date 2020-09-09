using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dari.Domain.Entities;

namespace Dari.Data
{
    public class CustomUserStore : UserStore<Client, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(Context context) : base(context)
        {
        }
    }
}
