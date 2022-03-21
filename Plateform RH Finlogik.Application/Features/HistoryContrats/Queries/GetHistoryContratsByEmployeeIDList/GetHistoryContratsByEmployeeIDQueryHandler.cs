using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.HistoryContrats.Queries.GetHistoryContratsByEmployeeIDList
{
    public class GetHistoryContratsByEmployeeIDQueryHandler : IRequestHandler<GetHistoryContratsByEmployeeIDQuery, List<HistoryContratsListByEmployeeIDVm>>
    {
        private readonly IHistoryContratRepository _historyContratRepository;
        private readonly IMapper _mapper;

        public GetHistoryContratsByEmployeeIDQueryHandler(IMapper mapper, IHistoryContratRepository historyContratRepository)
        {
            _mapper = mapper;
            _historyContratRepository = historyContratRepository;
        }

    
    public async Task<List<HistoryContratsListByEmployeeIDVm>> Handle(GetHistoryContratsByEmployeeIDQuery request, CancellationToken cancellationToken)
        {
            var allHistoryContratsByEmployeeID = _historyContratRepository.GetAllHistoryContratByEmployeeID(request.IdEmployee).OrderBy(x => x.StartDate);
            return _mapper.Map<List<HistoryContratsListByEmployeeIDVm>>(allHistoryContratsByEmployeeID);
        }
    }
}
