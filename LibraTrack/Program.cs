using LibraTrack.Core.Interfaces;
using LibraTrack.Infrastructure.Data;
using LibraTrack.Infrastructure.Repositories;
using LibraTrack.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace LibraTrack
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddDbContext<LibraryDbContext>();

            builder.Services.AddScoped<Catalog>();
            builder.Services.AddScoped<ILoanRepository, LoanRepository>();
            builder.Services.AddScoped<LoanService>();
            builder.Services.AddScoped<ReportingService>();

            using var app = builder.Build();

            using var scope = app.Services.CreateScope();

            var catalog = scope.ServiceProvider.GetRequiredService<Catalog>();
            var loanService = scope.ServiceProvider.GetRequiredService<LoanService>();
            var reportingService = scope.ServiceProvider
                                        .GetRequiredService<ReportingService>();


            Console.WriteLine("LoanService resolved successfully.");

            

        }

         
       

    }
}
