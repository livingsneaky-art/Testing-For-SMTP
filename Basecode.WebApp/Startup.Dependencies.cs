﻿using Basecode.WebApp.Authentication;
using Basecode.Data;
using Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;

namespace Basecode.WebApp
{
    public partial class Startup
    {
        private void ConfigureDependencies(IServiceCollection services)
        {
            // Common
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ClaimsProvider, ClaimsProvider>();

            // Services 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IJobOpeningService, JobOpeningService>();
            services.AddScoped<IApplicationService, ApplicationService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IJobOpeningRepository, JobOpeningRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
        }
    }
}