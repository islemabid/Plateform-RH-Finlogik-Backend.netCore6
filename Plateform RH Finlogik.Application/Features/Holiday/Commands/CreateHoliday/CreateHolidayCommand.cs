

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.Holiday.Commands.CreateHoliday
{
     public  class CreateHolidayCommand : IRequest<int>
    {
        public string  Title { get; set; }
        public DateTime Date { get; set; }
       
    }
}
