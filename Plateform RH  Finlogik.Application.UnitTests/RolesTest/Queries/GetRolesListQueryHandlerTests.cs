

using AutoMapper;
using Moq;
using Plateform_RH__Finlogik.Application.UnitTests.Mocks;
using Plateform_RH_Finlogik.Application.Application.Profiles;
using Plateform_RH_Finlogik.Application.Features.Employees;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;
using Plateform_RH_Finlogik.Application.Features.Roles.Queries.GetRolesList;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Plateform_RH__Finlogik.Application.UnitTests.Roles.Queries
{
    public class GetRolesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Role>> _mockRoleRepository;

        public GetRolesListQueryHandlerTests()
        {
            _mockRoleRepository = RepositoryMocks.GetRoleRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetRolesListTest()
        {
            var handler = new GetRolesListQueryHandler(_mapper, _mockRoleRepository.Object);

            var result = await handler.Handle(new GetRolesListQuery(), CancellationToken.None);


            Assert.Equal(3, result.Count);

        }
    }
}
