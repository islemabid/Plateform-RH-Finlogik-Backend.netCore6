

using AutoMapper;
using Moq;
using Plateform_RH__Finlogik.Application.UnitTests.Mocks;
using Plateform_RH_Finlogik.Application.Application.Profiles;
using Plateform_RH_Finlogik.Application.Features.LeaveTypes.Queries.GetListLeaveType;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Plateform_RH__Finlogik.Application.UnitTests.LeaveTypeTest.Queries
{
    public class GetLeaveTypeListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<LeaveType>> _mockLeavetypeRepository;

        public GetLeaveTypeListQueryHandler()
        {
            _mockLeavetypeRepository = RepositoryMocks.GetLeaveRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetleaveTypeListTest()
        {
            var handler = new GetListLeaveTypeQueryHandler(_mapper, _mockLeavetypeRepository.Object);

            var result = await handler.Handle(new GetListLeaveTypeQuery(), CancellationToken.None);


            Assert.Equal(4, result.Count);

        }
    }
}
