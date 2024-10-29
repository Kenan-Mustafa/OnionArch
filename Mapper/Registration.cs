using Application.Interface.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection service)
        {
            service.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
