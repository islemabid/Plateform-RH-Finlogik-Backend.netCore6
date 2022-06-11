

using AutoMapper;
using Moq;
using Plateform_RH__Finlogik.Application.UnitTests.Mocks;
using Plateform_RH_Finlogik.Application.Application.Profiles;
using Plateform_RH_Finlogik.Application.Features.Offers.Commands.CreateOffer;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Plateform_RH__Finlogik.Application.UnitTests.OffersTest.Commands
{
    public  class CreateOfferTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Offer>> _mockOfferRepository;
        public CreateOfferTest()
        {
            _mockOfferRepository = RepositoryMocks.GetOfferRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_ValidCategory_AddedToOfferRepo()
        {
            var handler = new CreateOfferCommandHandler(_mapper, _mockOfferRepository.Object);

            await handler.Handle(new CreateOfferCommand() { OfferDescription="test"}, CancellationToken.None);

            var alloffers = await _mockOfferRepository.Object.GetAllAsync();
            Assert.Equal(5, alloffers.Count);
        }
    }
}
