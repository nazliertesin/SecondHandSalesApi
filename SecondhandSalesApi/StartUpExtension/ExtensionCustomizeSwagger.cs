using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SecondhandSalesApi.StartUpExtension
{
    public static class ExtensionCustomizeSwagger
    {
        public static void AddCustomizeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Secondhand Sales Api Management", Version = "v2.0" });
                c.OperationFilter<ExtensionSwaggerFileOperationFilter>();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Pyc Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
        }
    }
}
