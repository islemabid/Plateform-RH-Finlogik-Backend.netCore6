using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Contracts.Interfaces
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
