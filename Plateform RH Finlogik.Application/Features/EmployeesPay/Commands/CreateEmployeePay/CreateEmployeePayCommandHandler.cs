using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


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
            if (request != null && request.Mounth!="" && request.Year!="" && request.IdEmployee!=null && request.FixedSalary!=null)
            {
                var @pay = _mapper.Map<EmployeePay>(request);

                @pay = await _payRepository.AddAsync(@pay);
                return @pay.Id;
            }
            else
            {
                throw new Exception($"failed");
            }

           

        }


    }
}
