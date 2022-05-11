using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.ValidateTimeOffBalances;
using Plateform_RH_Finlogik.Application.Helpers;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.VaidateTimeOffBalances
{
    public class ValidateTimeOffBalancesCommandHandler : IRequestHandler<ValidateTimeOffBalancesCommand>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly ILeaveBalancesRepository _leaveBalancesRepository;

        private readonly IMapper _mapper;

        public ValidateTimeOffBalancesCommandHandler(IMapper mapper, ILeaveBalancesRepository leaveBalancesRepository, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
            _leaveBalancesRepository = leaveBalancesRepository;

        }

        public async Task<Unit> Handle(ValidateTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {

            var timeoffbalnceToUpdate = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalnceToUpdate == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances), request.Id);
            }

            request.State = "validated";
            float NbDays = 0;
            if (timeoffbalnceToUpdate.StartDate == timeoffbalnceToUpdate.EndDate)
            {
                if (timeoffbalnceToUpdate.StartDateQuantity.Equals("afternoon") || timeoffbalnceToUpdate.StartDateQuantity.Equals("morning"))
                {
                    NbDays = (float)0.5;
                }
                else if (timeoffbalnceToUpdate.StartDateQuantity.Equals("full day"))
                {
                    NbDays = 1;

                }
            }
            else
            {
              
                    if (timeoffbalnceToUpdate.StartDateQuantity.Equals("afternoon"))
                    {
                        NbDays += (float)0.5;
                    }
                    else if (timeoffbalnceToUpdate.StartDateQuantity.Equals("full day"))
                    {
                        NbDays += 1;

                    }
                    if (timeoffbalnceToUpdate.EndDateQuantity.Equals("morning"))
                    {
                       NbDays += (float)0.5;
                    }
                    else if (timeoffbalnceToUpdate.EndDateQuantity.Equals("full day"))
                    {
                      NbDays += 1;

                    }
                DayOfWeek DayOfWeek = DateTime.Now.DayOfWeek;

                foreach (DateTime day in Helper.EachDay(timeoffbalnceToUpdate.StartDate.AddDays(1), timeoffbalnceToUpdate.EndDate.AddDays(-1)))
                {DayOfWeek t=day.DayOfWeek;
                    if( !t.Equals(DayOfWeek.Sunday) && !t.Equals( DayOfWeek.Saturday))
                    NbDays +=1;
                }

            }
            LeaveBalance leaveBalance = await _leaveBalancesRepository.GetLeaveBalanceByIDEmployee_IDLeaveType(request.IdEmployee, request.IdLeaveType);
            leaveBalance.numberDays -= NbDays;
            await _leaveBalancesRepository.UpdateAsync(leaveBalance);

            _mapper.Map(request, timeoffbalnceToUpdate, typeof(ValidateTimeOffBalancesCommand), typeof(TimeOffBalances));

                await _timeoffbalanceRepository.UpdateAsync(timeoffbalnceToUpdate);

                return Unit.Value;
            }

        }

    }

