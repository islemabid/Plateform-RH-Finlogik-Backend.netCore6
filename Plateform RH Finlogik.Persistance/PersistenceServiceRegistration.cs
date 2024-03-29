﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Plateform_RH_Finlogik.Persistance.Repositories;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;

namespace Plateform_RH_Finlogik.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlateformRHDbcontext >(options =>
             options.UseSqlServer("Server=localhost;Database=PlateFormRHFinlogik;Trusted_Connection=True;"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IEmployeePostRepository, EmployeePostRepository>();
            services.AddScoped< IRoleRepository, RoleRepository >();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IHistoryContratRepository, HistoryContratRepository>();
            services.AddScoped<IContratRepository, ContratRepository>();
            services.AddScoped<IDepartementRepository, DepartementRepository>();
            services.AddScoped<ItimeoffBalancesRepository, TimeoffBalancesRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<ICandidatRepository, CandidatRepository>();
            services.AddScoped<IApplicationOfferRepository, ApplicationOfferRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveBalancesRepository, LeaveBalancesRepository>();
            services.AddScoped<IEmployeePayRepository, EmployeePayRepository>();
            services.AddScoped<IPointageRepository, PointageRepositroy>();
            services.AddScoped<IWorkingHoursSummaryRepository, WorkingHoursSummaryRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();

            







            return services;
        }
    }
}

