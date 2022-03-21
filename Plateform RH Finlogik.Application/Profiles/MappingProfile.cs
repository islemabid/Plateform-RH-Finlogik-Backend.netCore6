﻿using AutoMapper;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.CreateDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Commands.UpdateDepartement;
using Plateform_RH_Finlogik.Application.Features.Departements.Queries.GetDepartementsList;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.DeleteEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateEmployee;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Commands.createEmployeePost;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetEmployeesPostsList;
using Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetPostsByEmployeeIDList;
using Plateform_RH_Finlogik.Application.Features.HistoryContrats.Queries.GetHistoryContratsByEmployeeIDList;
using Plateform_RH_Finlogik.Application.Features.Posts.Commands.CreatePost;
using Plateform_RH_Finlogik.Application.Features.Posts.Commands.updatePost;
using Plateform_RH_Finlogik.Application.Features.Posts.Queries.GetPostsList;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.CreateRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Commands.UpdateRole;
using Plateform_RH_Finlogik.Application.Features.Roles.Queries.GetRolesList;
using Plateform_RH_Finlogik.Domain.Entities;

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
            //mapping EmployeePost
            CreateMap<EmployeePost, EmployeePostListVm>().ReverseMap();
            CreateMap<EmployeePost, PostListByIDEmployeeVm>().ReverseMap();
            CreateMap<EmployeePost, CreateEmployeePostCommand>().ReverseMap();
            //mapping Role
            CreateMap<Role, RolesListVm>().ReverseMap();
            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<Role, UpdateRoleCommand>().ReverseMap();
            //mapping Post
            CreateMap<Post, PostListVm>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            //mapping Departement
            CreateMap<Departement, DepartementsListVm>().ReverseMap();
            CreateMap<Departement, CreateDepartementCommand>().ReverseMap();
            CreateMap<Departement, UpdateDepartementCommand>().ReverseMap();
            //mapping HistoryContrats
            CreateMap<HistoryContrat, HistoryContratsListByEmployeeIDVm>().ReverseMap();


        }
    }
}
