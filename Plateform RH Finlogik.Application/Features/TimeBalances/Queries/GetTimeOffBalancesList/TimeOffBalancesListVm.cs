﻿using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffBalancesList
{
    public class TimeoffBalancesListVm
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int IdEmployee { get; set; }
        public EmployeeVm Employee { get; set; }
        public string? Comment { get; set; }
        public int IdLeaveType { get; set; }
        public LeaveType LeaveTypes { get; set; }
        public string state  { get; set; }
        public string StartDateQuantity { get; set; }
        public string EndDateQuantity { get; set; }
    }
}
