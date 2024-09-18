using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinExChange.API.Data;

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

            builder.Services.AddDbContext<FinExChangeAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings__DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ConnectionStrings__DefaultConnection' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
