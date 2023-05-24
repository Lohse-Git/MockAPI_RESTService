using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MockAPI.Controllers;
using MockAPI.Data;
using MockAPI.Repositories;
using MockAPI.UDP;
using System.Configuration;

namespace MockAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            void ConfigureServices(IServiceCollection services)
            {
                // Other service configurations

                // Bypass SSL certificate validation
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;

                // Add additional services
            }
            builder.Services.AddDbContextPool<MockDataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MockContext"));
            });

            builder.Services.AddDbContextPool<MockDataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MockContext") ?? throw new InvalidOperationException("Connection string 'MockContext' not found.")));

            //builder.Services.AddScoped<MockRepos>();
            //builder.Services.AddScoped<MockDataController>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();
            //Task.Run(UDP_Receiver.MainTask);
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