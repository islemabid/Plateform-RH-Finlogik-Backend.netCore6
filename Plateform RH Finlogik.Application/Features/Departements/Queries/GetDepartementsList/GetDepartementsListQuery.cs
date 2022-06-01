using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.Departements.Queries.GetDepartementsList
{
    public class GetDepartementsListQuery : IRequest<List<DepartementsListVm>>
    {
    }
}
