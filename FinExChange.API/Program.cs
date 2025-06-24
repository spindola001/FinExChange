using AutoMapper;
using FinExChange.Application.Commands.Users;
using FinExChange.Application.Profiles;
using FinExChange.Domain.Interfaces;
using FinExChange.Infrastructure.DataAccess;
using FinExChange.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FinExChange.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseKestrel((context, options) =>
            {
                options.Configure(context.Configuration.GetSection("Kestrel"));
            });

            builder.Services.AddDbContext<FinExChangeDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings__DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ConnectionStrings__DefaultConnection' not found.")));

            // Add services to the container.
            builder.Services.AddAutoMapper(Assembly.Load("FinExChange.Application"));
            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("FinExChange.Application"));
            });
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Lê a versão da API a partir do segmento da URL
            });
            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FinExChange API",
                    Description = "API para gerenciamento de transacões de câmbio no sistema FinExChange",
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Habilita o Swagger no ambiente de desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }

                    options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
