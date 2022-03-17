using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetEmployeesPostsList
{
    public class GetEmployeePostListQueryHandler : IRequestHandler<GetEmployeePostListQuery, List<EmployeePostListVm>>
    {
        private readonly IAsyncRepository<EmployeePost> _employeePostRepository;
        private readonly IMapper _mapper;

        public GetEmployeePostListQueryHandler(IMapper mapper, IAsyncRepository<EmployeePost> employeePostRepository)
        {
            _mapper = mapper;
            _employeePostRepository = employeePostRepository;
        }

        public async Task<List<EmployeePostListVm>> Handle(GetEmployeePostListQuery request, CancellationToken cancellationToken)
        {
            var allEmployeePosts = (await _employeePostRepository.GetAllAsync()).OrderBy(x => x.StartDate);
            return _mapper.Map<List<EmployeePostListVm>>(allEmployeePosts);
        }
    
    }
}
