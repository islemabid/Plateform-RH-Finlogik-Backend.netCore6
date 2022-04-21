using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
  

        public class ApplicationOfferRepository : BaseRepository<ApplicationOffer>, IApplicationOfferRepository
        {
            public ApplicationOfferRepository(PlateformRHDbcontext dbContext) : base(dbContext)
            {
            }
        public List<ApplicationOffer> GetAllApplicationOffers()
        {
            return _dbContext.Set<ApplicationOffer>().Include("Candidat").Include("Offer").ToList();
        }
        public ApplicationOffer GetApplicationOfferByID(int ID)
        {
            return (ApplicationOffer)_dbContext.Set<ApplicationOffer>().Include("Candidat").Include("Offer").Where(x=>x.Id==ID);
        }

    }
    
}
