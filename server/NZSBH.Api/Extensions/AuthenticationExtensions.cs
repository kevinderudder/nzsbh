using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme   
            ).AddJwtBearer(options => {
                var sKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ServerSecret"]));
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = sKey,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Issuer"]
                };
            });
        }
    }
}
