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
             options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PlateFormRHFinlogik;Trusted_Connection=True;"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IEmployeePostRepository, EmployeePostRepository>();
            services.AddScoped<ITerminatedEmployeeRepository, TerminatedEmployeeRepository>();

            services.AddScoped< IRoleRepository, RoleRepository >();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IHistoryContratRepository, HistoryContratRepository>();
            services.AddScoped<IContratRepository, ContratRepository>();
            services.AddScoped<IDepartementRepository, DepartementRepository>();
            services.AddScoped<ItimeoffBalancesRepository, TimeoffBalancesRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();





            return services;
        }
    }
}

