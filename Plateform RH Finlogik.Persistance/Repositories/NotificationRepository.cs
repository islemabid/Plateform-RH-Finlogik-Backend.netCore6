using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationMessage;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        private readonly PlateformRHDbcontext _context;
        public NotificationRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        { 
            _context = dbContext;
        }

        public    Task<int> GetNotificationCount()
        {

            var count = (from not in _context.Notifications
                         select not).CountAsync();
           return count;
        }

        public async Task<List<NotificationResult>> GetNotificationMessage()

        {
            var results = from message in _context.Notifications
                          orderby message.Id descending
                          select new NotificationResult
                          {
                              CandidatName = message.NameCandidat,
                             
                          };
            return await results.ToListAsync();
          
        }
    }
   
}
