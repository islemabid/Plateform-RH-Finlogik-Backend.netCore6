

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.Holiday.Commands.CreateHoliday
{
     public  class CreateHolidayCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
