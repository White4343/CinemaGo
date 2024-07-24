
using Application;
using Infrastructure;
using Presentation;
using Serilog;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adds the services from the Application, Infrastructure, and Presentation layers
            builder.Services
                .AddApplication()
                .AddInfrastructure()
                .AddPresentation();

            // Adds Serilog reading from the appsettings.json configuration
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Uses Serilog to log HTTP requests
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}