using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;


namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetEmployeePayList
{
    public class GetEmployeePayListQueryHandler:IRequestHandler<GetEmployeePayListQuery, List<EmployeePayListVm>>
    {

        private readonly IEmployeePayRepository _payRepository;
    private readonly IMapper _mapper;

    public GetEmployeePayListQueryHandler(IMapper mapper, IEmployeePayRepository payRepository)
    {
        _mapper = mapper;
        _payRepository = payRepository;
    }

    public async Task<List<EmployeePayListVm>> Handle(GetEmployeePayListQuery request, CancellationToken cancellationToken)
    {
        var allPays = await _payRepository.GetAllAsync();
        return _mapper.Map<List<EmployeePayListVm>>(allPays);
    }
}
    
    }
