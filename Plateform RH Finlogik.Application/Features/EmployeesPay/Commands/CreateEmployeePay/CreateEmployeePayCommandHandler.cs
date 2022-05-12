using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Commands.CreateEmployeePay
{
    public class CreateEmployeePayCommandHandler : IRequestHandler<CreateEmployeePayCommand, int>
    {
        private readonly IEmployeePayRepository _payRepository;
        private readonly IMapper _mapper;
        public CreateEmployeePayCommandHandler(IMapper mapper, IEmployeePayRepository payRepository)
        {
            _mapper = mapper;
            _payRepository = payRepository;

        }

        public async Task<int> Handle(CreateEmployeePayCommand request, CancellationToken cancellationToken)
        {
            var @pay = _mapper.Map<EmployeePay>(request);

            @pay = await _payRepository.AddAsync(@pay);



            return @pay.Id;

        }


    }
}
