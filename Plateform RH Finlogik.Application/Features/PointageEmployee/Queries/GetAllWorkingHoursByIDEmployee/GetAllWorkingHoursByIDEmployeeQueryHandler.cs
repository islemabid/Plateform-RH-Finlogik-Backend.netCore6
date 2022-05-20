

using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetAllWorkingHoursByIDEmployee
{
    public class GetAllWorkingHoursByIDEmployeeQueryHandler : IRequestHandler<GetAllWorkingHoursByIDEmployeeQuery, List<AllWorkingHoursOfEmployeeVm>>
    {

        private readonly IWorkingHoursSummaryRepository _workingHoursSummaryRepository;
        private readonly IMapper _mapper;
        public GetAllWorkingHoursByIDEmployeeQueryHandler(IMapper mapper, IWorkingHoursSummaryRepository workingHoursSummaryRepository, IPointageRepository pointageRepository)
        {
            _mapper = mapper;

            _workingHoursSummaryRepository = workingHoursSummaryRepository;

        }

        public async Task<List<AllWorkingHoursOfEmployeeVm>> Handle(GetAllWorkingHoursByIDEmployeeQuery request, CancellationToken cancellationToken)
        {
            var allWorkingHoursofEmployee =  _workingHoursSummaryRepository.GetWorkingHoursSummaryByIDEmployee(request.IdEmployee);
            return _mapper.Map<List<AllWorkingHoursOfEmployeeVm>>(allWorkingHoursofEmployee);
        }
    }
}
