

using AutoMapper;
using Moq;
using Plateform_RH__Finlogik.Application.UnitTests.Mocks;
using Plateform_RH_Finlogik.Application.Application.Profiles;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Plateform_RH__Finlogik.Application.UnitTests.Roles.Commands
{
    public class CreateRoleTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Employee>> _mockEmployeeRepository;

        /* public CreateRoleTests()
         {
             _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
             var configurationProvider = new MapperConfiguration(cfg =>
             {
                 cfg.AddProfile<MappingProfile>();
             });

             _mapper = configurationProvider.CreateMapper();
         }

         [Fact]
         public async Task Handle_ValidEmployee_AddedToEmployeesRepo()
         {
             var handler = new CreateEmployeeCommandHandler(_mapper, _mockEmployeeRepository.Object);

             await handler.Handle(new CreateEmployeeCommand() {  }, CancellationToken.None);

             var allEmployees = await _mockEmployeeRepository.Object.GetAllAsync();
             allEmployees.;
         }
     }*/
    }
}
    

