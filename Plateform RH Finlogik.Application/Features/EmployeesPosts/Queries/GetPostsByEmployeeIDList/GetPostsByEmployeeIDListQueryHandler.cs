using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetPostsByEmployeeIDList
{
    public class GetPostsByEmployeeIDListQueryHandler : IRequestHandler<GetPostsByEmployeeIDListQuery, List<PostListByIDEmployeeVm>>
    {
        private readonly IEmployeePostRepository _employeePostRepository;
        private readonly IMapper _mapper;

        public GetPostsByEmployeeIDListQueryHandler(IMapper mapper, IEmployeePostRepository employeePostRepository)
        {
            _mapper = mapper;
            _employeePostRepository = employeePostRepository;
        }

        public async Task<List<PostListByIDEmployeeVm>> Handle(GetPostsByEmployeeIDListQuery request, CancellationToken cancellationToken)
        {
            var allEmployeePostsByEmployeeID = (_employeePostRepository.GetAllEmployeesPostsByEmployeeID(request.IdEmployee).OrderBy(x => x.StartDate));
            return _mapper.Map<List<PostListByIDEmployeeVm>>(allEmployeePostsByEmployeeID);
        }

    }
}

   

