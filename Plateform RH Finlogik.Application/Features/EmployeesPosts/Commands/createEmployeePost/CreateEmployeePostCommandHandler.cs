using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Commands.createEmployeePost
{
    public class CreateEmployeePostCommandHandler : IRequestHandler<CreateEmployeePostCommand,int>
    {
        private readonly IEmployeePostRepository _employeePostRepository;
        private readonly IMapper _mapper;

        public CreateEmployeePostCommandHandler(IMapper mapper, IEmployeePostRepository employeePostRepository)
        {
            _mapper = mapper;
            _employeePostRepository = employeePostRepository;
        }

        public async Task<int> Handle(CreateEmployeePostCommand request, CancellationToken cancellationToken)
        {

           List<EmployeePost> allPostsByEmployeeID = _employeePostRepository.GetAllEmployeesPostsByEmployeeID(request.IdEmployee);

            foreach (EmployeePost p in allPostsByEmployeeID)
            {
                if (p.isActive == true)
                {
                    p.isActive = false;
                    await _employeePostRepository.UpdateAsync(p);
                }
            }
            var @post = _mapper.Map<EmployeePost>(request);

            @post = await _employeePostRepository.AddAsync(@post);
            return @post.Id;
        }

       
    }
    
}
