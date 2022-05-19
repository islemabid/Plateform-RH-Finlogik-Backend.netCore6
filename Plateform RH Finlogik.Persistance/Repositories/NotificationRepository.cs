using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationMessage;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        private readonly PlateformRHDbcontext _context;
        public NotificationRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<int> GetNotificationCount()
        {

            var count = await (from notif in _context.Notifications
                               where notif.Status == true
                               select notif).CountAsync();
            return count;
        }

        public async Task<List<NotificationResult>> GetNotificationMessage()

        {
            
            
            var results = from message in _context.Notifications
                          where message.Status == true
                          orderby message.Id descending

                          select new NotificationResult
                          {  Id=message.Id,
                              Message = message.Message,
                           
                              

                          };

            return results.ToList();

        }

    }
}
