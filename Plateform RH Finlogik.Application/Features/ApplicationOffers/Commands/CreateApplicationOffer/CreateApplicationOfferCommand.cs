using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer
{
    public class CreateApplicationOfferCommand : IRequest<int>
    {
        public int IdOffer { get; set; }
        public int IdCandidat { get; set; }
        public DateTime AssignmentDate { get; set; }=DateTime.Now;
        public string CvUrl { get; set; }

        public string CoverLetter { get; set; }
    }
}
