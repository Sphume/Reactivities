using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Interfaces;
using Infrastructure.Security;


namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) // 'this' refers to where we use the method e.g. services
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
              services.AddEndpointsApiExplorer();
              services.AddSwaggerGen();
              services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
              services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
              services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
              //assembly locates all the mappingprofiles that are being used inside the project
              services.AddAutoMapper(typeof(MappingProfiles).Assembly); 
              services.AddFluentValidationAutoValidation();
              services.AddValidatorsFromAssemblyContaining<Create>();
              services.AddHttpContextAccessor();
              services.AddScoped<IUserAccessor, UserAccessor>();

              return services;
        }
    }
}