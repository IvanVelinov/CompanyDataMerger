using CompanyDataMerger.Application.Interfaces;
using CompanyDataMerger.Application.Services;
using CompanyDataMerger.Domain.Interfaces;
using CompanyDataMerger.Infrastructure.Data;
using CompanyDataMerger.Infrastructure.Readers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting Company Data Merge Application...");

    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


    var services = new ServiceCollection();

    // Add DbContext
    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                         ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
    });

    // Register Repositories
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    // Register Services
    services.AddScoped<ICompanyMergeService, CompanyMergeService>();
    // Register Provider
    services.AddScoped<ICompanyDataProvider, CompanyDataProvider>();
    // Register Readers
    services.AddScoped<ICompanyReader, Source1Reader>();
    services.AddScoped<ICompanyReader, Source2Reader>();
    services.AddScoped<ICompanyReader, Source3Reader>();


    services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog();
    });

    var serviceProvider = services.BuildServiceProvider();


    // Execute the merge
    var mergeService = serviceProvider.GetRequiredService<ICompanyMergeService>();
    await mergeService.MergeAndSaveCompaniesAsync();

    Log.Information("Data Merge completed successfully.");


}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred during execution.");
}
finally
{
    Log.CloseAndFlush();
}

