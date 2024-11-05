using Application.Beheviors;
using Application.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
            service.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
