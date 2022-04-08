
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;

namespace Plateform_RH_Finlogik.Application.Features.HubClient
{
    public  class BroadcastHub : Hub<IHubClient>
    {
    }
}
