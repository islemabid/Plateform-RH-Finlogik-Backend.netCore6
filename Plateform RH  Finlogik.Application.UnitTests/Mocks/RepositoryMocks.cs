

using Moq;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System.Collections.Generic;

namespace Plateform_RH__Finlogik.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        /*public static Mock<IAsyncRepository<Employee>> GetEmployeeRepository()
        {
           

            var employees = new List<Employee>
            {
                new Employee { 
                    Id = 1, FirstName="ghazi", LastName="ghassara", Adress="sfax"
                },

                new Employee {
                    Id = 2, FirstName="salma", LastName="ghassara", Adress="sfax"
                },
                 new Employee {
                    Id = 5, FirstName="ons", LastName="ghassara", Adress="sfax"
                },

            };

            var mockEmployeeRepository = new Mock<IAsyncRepository<Employee>>();
            mockEmployeeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            mockEmployeeRepository.Setup(repo => repo.AddAsync(It.IsAny<Employee>())).ReturnsAsync(
                (Employee employee) =>
                {
                    employees.Add(employee);
                    return employee;
                });

            return mockEmployeeRepository;
        }
    }*/
}
}
