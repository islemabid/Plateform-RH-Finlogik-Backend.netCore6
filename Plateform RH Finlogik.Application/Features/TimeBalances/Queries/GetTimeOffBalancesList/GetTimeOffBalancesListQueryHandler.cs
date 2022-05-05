using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffBalancesList
{
    public class GetTimeOffBalancesListQueryHandler : IRequestHandler<GetTimeOffBalancesListQuery, List<TimeoffBalancesListVm>>
    {

        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public GetTimeOffBalancesListQueryHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
        }

        public async Task<List<TimeoffBalancesListVm>> Handle(GetTimeOffBalancesListQuery request, CancellationToken cancellationToken)
        {
            var allTimeoffBalances= (await _timeoffbalanceRepository.GetAllAsync()).Where(x=>x.IsActive==true);
            return _mapper.Map<List<TimeoffBalancesListVm>>(allTimeoffBalances);
        }


    }
}
