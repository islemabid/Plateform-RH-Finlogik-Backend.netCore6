using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Helpers;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.DeleteTimeOffBalances
{
     class DeleteTimeOffBalancesCommandHandler : IRequestHandler<DeleteTimeOffBalancesCommand>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveBalancesRepository _LeaveBalancesRepository;
      


        public DeleteTimeOffBalancesCommandHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository, ILeaveBalancesRepository LeaveBalancesRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
            _LeaveBalancesRepository = LeaveBalancesRepository;
           
        }

        public async Task<Unit> Handle(DeleteTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {
            var timeoffbalancesToDelete = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalancesToDelete == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances), request.Id);
            }
            if (timeoffbalancesToDelete.State == "Waiting")
            {
                timeoffbalancesToDelete.State = "canceled";
                _mapper.Map(request, timeoffbalancesToDelete, typeof(DeleteTimeOffBalancesCommand), typeof(TimeOffBalances));

                await _timeoffbalanceRepository.UpdateAsync(timeoffbalancesToDelete);
            

                return Unit.Value;
            }
            if (timeoffbalancesToDelete.State == "validated")
            {
                if (timeoffbalancesToDelete.StartDate > DateTime.Now)
                {
                    var @leaveBalance = await _LeaveBalancesRepository.GetLeaveBalanceByIDEmployee_IDLeaveType(timeoffbalancesToDelete.IdEmployee, timeoffbalancesToDelete.IdLeaveType);
                 
                        float NbDays = 0;
                        if (timeoffbalancesToDelete.StartDate == timeoffbalancesToDelete.EndDate)
                        {
                            if (timeoffbalancesToDelete.StartDateQuantity.Equals("afternoon") || timeoffbalancesToDelete.StartDateQuantity.Equals("morning"))
                            {
                                NbDays = (float)0.5;
                            }
                            else if (timeoffbalancesToDelete.StartDateQuantity.Equals("full day"))
                            {
                                NbDays = 1;

                            }
                        }
                        else  {

                            if (timeoffbalancesToDelete.StartDateQuantity.Equals("afternoon"))
                            {
                                NbDays += (float)0.5;
                            }
                            else if (timeoffbalancesToDelete.StartDateQuantity.Equals("full day"))
                            {
                                NbDays += 1;

                            }
                            if (timeoffbalancesToDelete.EndDateQuantity.Equals("morning"))
                            {
                                NbDays += (float)0.5;
                            }
                            else if (timeoffbalancesToDelete.EndDateQuantity.Equals("full day"))
                            {
                                NbDays += 1;

                            }
                            DayOfWeek DayOfWeek = DateTime.Now.DayOfWeek;

                            foreach (DateTime day in Helper.EachDay(timeoffbalancesToDelete.StartDate.AddDays(1), timeoffbalancesToDelete.EndDate.AddDays(-1)))
                            {
                                DayOfWeek t = day.DayOfWeek;
                                if (!t.Equals(DayOfWeek.Sunday) && !t.Equals(DayOfWeek.Saturday))
                                    NbDays += 1;
                            }


                        }
                        @leaveBalance.numberDays+= NbDays;
                        _LeaveBalancesRepository.UpdateAsync(leaveBalance);
                       timeoffbalancesToDelete.State = "canceled";
                      _mapper.Map(request, timeoffbalancesToDelete, typeof(DeleteTimeOffBalancesCommand), typeof(TimeOffBalances));

                        await _timeoffbalanceRepository.UpdateAsync(timeoffbalancesToDelete);
  

                    return Unit.Value;


                    }
                  
                
            }
            return Unit.Value;
        }

    }


}


