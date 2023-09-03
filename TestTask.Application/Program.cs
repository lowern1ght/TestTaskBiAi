using Serilog;
using TestTask.Application.Services;
using TestTask.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options
    => options.LowercaseUrls = true);

builder.Services.AddControllers();

builder.Services
    .AddScoped<ISummaryArrayService<Int32>, SummaryArrayService>()
    .AddScoped<IPalindromeService, PalindromeService>()
    .AddScoped<ISortingService, SortingService>();

builder.Logging.ClearProviders()
    .AddSerilog();

if (builder.Environment.IsDevelopment())
{
    builder.Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen();
}

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application
        .UseSwagger()
        .UseSwaggerUI();
}

application.UseRouting();

application.MapGet("/", () => "Hello, this test application it's working");

application.MapDefaultControllerRoute();

application.Run();