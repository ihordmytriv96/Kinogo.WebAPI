using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Kinogo.WebAPI.Host.Common.Authentication
{
    public static class AuthenticationRegisterDepenedencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                ((IConfiguration)provider.GetService(typeof(IConfiguration))).GetSection("AppSettings:Token").Value)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
