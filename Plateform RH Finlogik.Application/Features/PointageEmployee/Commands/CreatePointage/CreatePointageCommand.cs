

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Commands.CreatePointage
{
    public class CreatePointageCommand : IRequest<int>
    {
      

        public DateTime dateAction { get; set; }

        public string action { get; set; }

        public int IdEmployee { get; set; }
    }
}
