using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetHistoryPayOfEmployee
{
    public  class HistoryPayVm
    {
        public string Year { get; set; }
        public string Mounth { get; set; }
        public long FixedSalary { get; set; }
        public int? MealTicket { get; set; }
        public int? TicketPassGift { get; set; }
        public float? Prime { get; set; }
        public string status { get; set; }
    }
}
