

using AutoMapper;
using Moq;
using Plateform_RH__Finlogik.Application.UnitTests.Mocks;
using Plateform_RH_Finlogik.Application.Application.Profiles;
using Plateform_RH_Finlogik.Application.Features.Employees;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Plateform_RH__Finlogik.Application.UnitTests.Employees.Queries
{
    public class GetEmployeesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Employee>> _mockEmployeeRepository;

        public GetEmployeesListQueryHandlerTests()
        {
            _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetEmployeesListTest()
        {
            var handler = new GetEmployeesListQueryHandler(_mapper, _mockEmployeeRepository.Object);

            var result = await handler.Handle(new GetEmployeesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<EmployeeListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
