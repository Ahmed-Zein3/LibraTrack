using LibraTrack.Data;
using LibraTrack.Demos;
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
            using var app = builder.Build();
            using var scope = app.Services.CreateScope();

            var catalog = scope.ServiceProvider.GetRequiredService<Catalog>();
            //await CatalogDemo.TestStoredProcedureCheckout(catalog);
            //await TestOpenLoansQuery(catalog);
            //await TestCatalogCheckout(catalog, 1, 1);
            //await CatalogDemo.TestCatalogReturn(catalog, 1, 2);
            //await CatalogDemo.TestCatalogAdd(catalog);

            //await TestCatalogGetAll(catalog);
            //DisplayLibraryItems();

            //Console.WriteLine();

            //ValueReferenceDemo.Run();

            //Console.WriteLine();

            //TryCatchTests();

            //Console.WriteLine();

            //TestLoanLimit();

            //Console.WriteLine();

            //TestCheckoutAndReturn();
            //await TestAddMember();
            //await TestGetMembers();
            //await TestFindMember();

        }

         
       

    }
}
