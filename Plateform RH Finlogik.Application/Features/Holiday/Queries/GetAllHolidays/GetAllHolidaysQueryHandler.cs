
using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;


namespace Plateform_RH_Finlogik.Application.Features.Holiday.Queries.GetAllHolidays
{
    public class GetAllHolidaysQueryHandler : IRequestHandler<GetAllHolidaysQuery, List<HolidayVm>>
    {

        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mapper;

        public GetAllHolidaysQueryHandler(IMapper mapper, IHolidayRepository holidayRepository)
        {
            _mapper = mapper;
            _holidayRepository = holidayRepository;
        }

        public async Task<List<HolidayVm>> Handle(GetAllHolidaysQuery request, CancellationToken cancellationToken)
        {
            var allholidays = (await _holidayRepository.GetAllAsync()).OrderByDescending(x=>x.Id);
            return _mapper.Map<List<HolidayVm>>(allholidays);
        }
    }
}
