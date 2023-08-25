using Serilog;
using TestTask.Application.Services;
using TestTask.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ISummaryArrayService<Int32>, SummaryArrayService>();

builder.Logging.ClearProviders()
    .AddSerilog();

builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseRouting();

application.MapGet("/", () => "Hello World!");

application.MapDefaultControllerRoute();

application.Run();