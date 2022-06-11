



using Moq;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Collections.Generic;

namespace Plateform_RH__Finlogik.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Role>> GetRoleRepository()
        {
           

            var roles = new List<Role>
            {
                new Role { 
                    Id = 1, Name="employee"
                },
                new Role {
                    Id = 2, Name="consultant"
                },
                   new Role {
                    Id = 3, Name="testeur"
                },




            };

            var mockRoleRepository = new Mock<IAsyncRepository<Role>>();
            mockRoleRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(roles);

            mockRoleRepository.Setup(repo => repo.AddAsync(It.IsAny<Role>())).ReturnsAsync(
                (Role role) =>
                {
                    roles.Add(role);
                    return role;
                });

            return mockRoleRepository;
        }
        public static Mock<IAsyncRepository<Offer>> GetOfferRepository()
        {


            var offers = new List<Offer>
            {
                new Offer {
                    Id = 1, OfferDescription="Offer1"
                },
                new Offer {
                    Id = 2, OfferDescription="Offer2"
                },
                   new Offer {
                    Id = 3, OfferDescription="Offer3"
                },
                   new Offer {
                    Id = 4, OfferDescription="Offer4"
                },





            };

            var mockOfferRepository = new Mock<IAsyncRepository<Offer>>();
            mockOfferRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(offers);

            mockOfferRepository.Setup(repo => repo.AddAsync(It.IsAny<Offer>())).ReturnsAsync(
                (Offer offer) =>
                {
                    offers.Add(offer);
                    return offer;
                });

            return mockOfferRepository;
        }
        public static Mock<IAsyncRepository<LeaveType>> GetLeaveRepository()
        {


            var leaves = new List<LeaveType>
            {
                new LeaveType {
                    Id = 1,Description="test"
                },
                new LeaveType {
                    Id = 2,  Description="test2"
                },
                   new LeaveType {
                    Id = 3,Description="test3"
                },
                new LeaveType {
                    Id = 4,  Description="test4"
                },






            };

            var mockLeaveRepository = new Mock<IAsyncRepository<LeaveType>>();
            mockLeaveRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(leaves);

            mockLeaveRepository.Setup(repo => repo.AddAsync(It.IsAny<LeaveType>())).ReturnsAsync(
                (LeaveType l) =>
                {
                    leaves.Add(l);
                    return l;
                });

            return mockLeaveRepository;
        }
    }
}

