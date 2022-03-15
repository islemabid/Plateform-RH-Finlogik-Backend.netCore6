using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Contracts.Persistance
{
    public  interface ITerminatedEmployeeRepository : IAsyncRepository<TerminatedEmployee>
    {
    }
}
