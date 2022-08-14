using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.Base;
using DataAccess.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess.Services
{
   public static class ServiceCollectionExtension
    {        
       public static IServiceCollection AddServices(this IServiceCollection services)
       {
            return services
           .AddScoped<IEmail, EmailService>()
           .AddScoped<IUser<Entities.User>, UserService<Entities.User>>();
        }
    }
}
