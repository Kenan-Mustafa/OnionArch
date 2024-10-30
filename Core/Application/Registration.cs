using Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection service)
        {
            var assembly = Assembly.GetExecutingAssembly();
            service.AddTransient<ExceptionMiddleware>();
            service.AddMediatR(x=>x.RegisterServicesFromAssembly(assembly));
        }
    }
}
