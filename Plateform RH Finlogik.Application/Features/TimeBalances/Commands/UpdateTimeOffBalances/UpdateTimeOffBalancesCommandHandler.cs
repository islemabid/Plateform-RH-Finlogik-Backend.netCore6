﻿using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Helpers;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.UpdateTimeOffBalances
{
    public class UpdateTimeOffBalancesCommandHandler : IRequestHandler<UpdateTimeOffBalancesCommand>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public UpdateTimeOffBalancesCommandHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
        }

        public async Task<Unit> Handle(UpdateTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {

            var timeoffbalnceToUpdate = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalnceToUpdate == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances), request.Id);
            }

            timeoffbalnceToUpdate.State = "validated";
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
            _mapper.Map(request, timeoffbalnceToUpdate, typeof(UpdateTimeOffBalancesCommand), typeof(TimeOffBalances));

                await _timeoffbalanceRepository.UpdateAsync(timeoffbalnceToUpdate);

                return Unit.Value;
            }

        }

    }

