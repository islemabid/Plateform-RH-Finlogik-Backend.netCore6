
using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetEmployeePointage
{
    public class GetEmployeePointageQueryHandler : IRequestHandler<GetEmployeePointageQuery, EmployeePointageVm>
    {

        private readonly IPointageRepository _pointageRepository;
        private readonly IMapper _mapper;

        public GetEmployeePointageQueryHandler(IMapper mapper, IPointageRepository pointageRepository)
        {
            _mapper = mapper;
            _pointageRepository = pointageRepository;

        }
        //mast79ithech
        public async Task<EmployeePointageVm> Handle(GetEmployeePointageQuery request, CancellationToken cancellationToken)
        {
            var pointagesList = await _pointageRepository.GetAllAsync();

            for (DateTime date = request.startDate; request.endDate.CompareTo(date) > 0; date = date.AddDays(1.0))
            {
                var pointageDay = pointagesList.Where(a => a.dateAction.Date == date.Date).OrderBy(a => a.dateAction).ToList();
                {
                    float WorkingHour = 0;
                    if (pointageDay.Count > 1 )
                    {
                        for(int i=0;i<pointageDay.Count;i++)
                        {  
                            if(pointageDay[0].action.Equals("In"))
                            {


                            }


                        }

                    }

                }
                
            }
            return null;
        }
    }
}
