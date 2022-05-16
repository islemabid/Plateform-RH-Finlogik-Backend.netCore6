

using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.Holiday.Commands.CreateHoliday
{
    public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, int>
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mapper;
        public CreateHolidayCommandHandler(IMapper mapper, IHolidayRepository holidayRepository)
        {
            _mapper = mapper;
            _holidayRepository = holidayRepository;

        }

        public async Task<int> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
        {
            var @holiday = _mapper.Map<Holidays>(request);

            @holiday = await _holidayRepository.AddAsync(@holiday);



            return holiday.Id;
        }
    }
}
