using Microsoft.Extensions.DependencyInjection;
using NZSBH.Application.Dxos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using NZSBH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZSBH.Api
{
    public static class IoCExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services) {
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IRepository<Book>, Repository<Book>>();
        }
    }
}
