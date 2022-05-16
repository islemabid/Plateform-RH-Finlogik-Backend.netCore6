using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Commands.CreatePointage
{
    public class CreatePointageCommandHandler : IRequestHandler<CreatePointageCommand, int>
    {
        private readonly IPointageRepository _pointageRepository;

        private readonly IWorkingHoursSummaryRepository _workingHoursSummaryRepository;
        private readonly IMapper _mapper;
        public CreatePointageCommandHandler(IMapper mapper, IWorkingHoursSummaryRepository workingHoursSummaryRepository, IPointageRepository pointageRepository)
        {
            _mapper = mapper;
            _pointageRepository = pointageRepository;
            _workingHoursSummaryRepository = workingHoursSummaryRepository;

        }

        public async Task<int> Handle(CreatePointageCommand request, CancellationToken cancellationToken)
        {
            var @pointage = _mapper.Map<Pointage>(request);
            pointage.IsCalculated = false;
            @pointage = await _pointageRepository.AddAsync(pointage);
            if (request.action.Equals("Out"))
            {
            Pointage pointageIn = await  _pointageRepository.GetPointageByIDEmployee(request.IdEmployee,request.dateAction);

                if( pointageIn !=null)
                {
                    double WorkingHours = (request.dateAction - pointageIn.dateAction).TotalHours;

                    WorkingHoursSummary workingHoursSummary = _workingHoursSummaryRepository.GetWorkingHoursSummaryByIDEmployee_Date(request.IdEmployee, request.dateAction).Result;
                    if(workingHoursSummary == null)
                    {
                        WorkingHoursSummary working = new WorkingHoursSummary
                        { date = request.dateAction, IdEmployee = request.IdEmployee, hours = (float)WorkingHours };
                        _workingHoursSummaryRepository.AddAsync(working);
                    }
                   else {
                        workingHoursSummary.hours +=(float) WorkingHours;

                        _workingHoursSummaryRepository.UpdateAsync(workingHoursSummary);
                    }


                }
            }


            return pointage.id;

        }

    }

}