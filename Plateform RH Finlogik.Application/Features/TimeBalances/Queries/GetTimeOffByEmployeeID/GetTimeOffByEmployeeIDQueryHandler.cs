using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffByEmployeeID
{
    public class GetTimeOffByEmployeeIDQueryHandler : IRequestHandler<GetTimeOffByEmployeeIDQuery, List<ListTimeOffBalancesOfEmployeeVm>>
    {

        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public GetTimeOffByEmployeeIDQueryHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
        }

        public async Task<List<ListTimeOffBalancesOfEmployeeVm>> Handle(GetTimeOffByEmployeeIDQuery request, CancellationToken cancellationToken)
        {
            var allTimeoffBalancesOfEmployee = await _timeoffbalanceRepository.GetallTimeOffBalancesOfEmployee(request.IdEmployee);
            return _mapper.Map<List<ListTimeOffBalancesOfEmployeeVm>>(allTimeoffBalancesOfEmployee);
        }

    }
}
