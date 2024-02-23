using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Repositories
{
    internal sealed class MeetRepository : Repository<Meet>, IMeetRepository
    {
        public MeetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
