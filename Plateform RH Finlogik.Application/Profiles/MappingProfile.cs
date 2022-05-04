using AutoMapper;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer;
using Plateform_RH_Finlogik.Application.Features.Candidats.Commands.CreateCandidat;
using Plateform_RH_Finlogik.Application.Features.Contrats.Commands.CreateContrat;
using Plateform_RH_Finlogik.Application.Features.Contrats.Commands.UpdateContrat;
using Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratByID;
using Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratsList;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.CreateDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.UpdateDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Queries.GetDepartementsList;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateProfil;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetEmployeesPostsList;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetPostsByEmployeeIDList;
using Plateform_RH_Finlogik.Application.Features.HistoryContrats.Queries.GetHistoryContratsByEmployeeIDList;
using Plateform_RH_Finlogik.Application.Features.Offers.Commands.CreateOffer;
using Plateform_RH_Finlogik.Application.Features.Posts.Commands.CreatePost;
using Plateform_RH_Finlogik.Application.Features.Offers.Commands.updateOffer;
using Plateform_RH_Finlogik.Application.Features.Posts.Commands.updatePost;
using Plateform_RH_Finlogik.Application.Features.Offers.Queries.GetOffersList;
using Plateform_RH_Finlogik.Application.Features.Posts.Queries.GetPostsList;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.CreateRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.UpdateRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Queries.GetRolesList;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.CreateTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.UpdateTimeOffBalances;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffBalancesList;
using Plateform_RH_Finlogik.Domain.Entities;
using Plateform_RH_Finlogik.Application.Features.Offers.Queries.GetOfferById;
using Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatsList;
using Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatByID;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOffersList;
using Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOfferByID;
using Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffByEmployeeID;
using Plateform_RH_Finlogik.Application.Features.LeaveTypes.Queries.GetListLeaveType;
using Plateform_RH_Finlogik.Application.Features.LeaveBalances.Queries.GetLeaveBalncesByIDEmpoyee_IDLeaveType;

namespace Plateform_RH_Finlogik.Application.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {   
            //mapping Employee
            CreateMap<Employee, EmployeeListVm>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeDetailVm>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateProfilCommand>().ReverseMap();
            //mapping EmployeePost
            CreateMap<EmployeePost, EmployeePostListVm>().ReverseMap();
            CreateMap<EmployeePost, PostListByIDEmployeeVm>().ReverseMap();
           
            //mapping Role
            CreateMap<Role, RolesListVm>().ReverseMap();
            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<Role, UpdateRoleCommand>().ReverseMap();

            //mapping Post
            CreateMap<Post, PostListVm>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();

            //mapping Offer
            CreateMap<Offer, OffersListVm>().ReverseMap();
            CreateMap<Offer, CreateOfferCommand>().ReverseMap();
            CreateMap<Offer, OfferVm>().ReverseMap();
            CreateMap<Offer, UpdateOfferCommand>().ReverseMap();

            //mapping Departement
            CreateMap<Departement, DepartementsListVm>().ReverseMap();
            CreateMap<Departement, CreateDepartementCommand>().ReverseMap();
            CreateMap<Departement, UpdateDepartementCommand>().ReverseMap();

            //mapping Contrat
            CreateMap<Contrat, ContratsListVm>().ReverseMap();
            CreateMap<Contrat, ContratByIDdetails>().ReverseMap();
            CreateMap<Contrat, CreateContratCommand>().ReverseMap();
            CreateMap<Contrat, UpdateContratCommand>().ReverseMap();

            //mapping Candidat 
            CreateMap<Candidat, CreateCandidatCommand>().ReverseMap();
            CreateMap<Candidat, CandidatsListVm>().ReverseMap();
            CreateMap<Candidat, CandidatDetails>().ReverseMap();

            //mapping ApplicationOffer
            CreateMap<ApplicationOffer, CreateApplicationOfferCommand>().ReverseMap();
            CreateMap<ApplicationOffer, ApplicationOffersListVm>().ReverseMap();
            CreateMap<ApplicationOffer, ApplicationOfferDetails>().ReverseMap();

            //mapping LeaveType 
            CreateMap<LeaveType, LeaveTypeListVm>().ReverseMap();

            //mapping LeaveBalances 
            CreateMap<LeaveBalance, LeaveBalancesVm>().ReverseMap();



            //mapping HistoryContrats
            CreateMap<HistoryContrat, HistoryContratsListByEmployeeIDVm>().ReverseMap();

            //mapping Timeoffbalances
            CreateMap<TimeOffBalances, TimeoffBalancesListVm>().ReverseMap();
            CreateMap<TimeOffBalances, CreateTimeOffBalancesCommand>().ReverseMap();
            CreateMap<TimeOffBalances, ListTimeOffBalancesOfEmployeeVm>().ReverseMap();
            CreateMap<TimeOffBalances,UpdateTimeOffBalancesCommand>().ReverseMap();


        }
    }
}
