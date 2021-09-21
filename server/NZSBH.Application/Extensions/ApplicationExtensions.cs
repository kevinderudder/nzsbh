using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NZSBH.Application.Dxos;
using NZSBH.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void RegisterApplication(this IServiceCollection services) {
            services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationExtensions)));
            services.AddScoped<IBooksDxos, BooksDxos>();

            AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>().ForEach(pair => {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
                services.Add(ServiceDescriptor.Transient(pair.ValidatorType, pair.ValidatorType));
            });
        }
    }
}
