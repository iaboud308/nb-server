
using Microsoft.AspNetCore.HttpLogging;
using server.Models;
using server.Services;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up...");


try {


    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.AddSerilog();
    builder.Host.UseSerilog((context, config) =>
    {
        config.WriteTo.Console();
        config.Enrich.FromLogContext();
    });

    // Add services to the container.
    builder.Services.AddCors(options => options.AddDefaultPolicy(
        b => b.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
    ));



    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();



    builder.Services.AddDbContext<BankContext>();
    builder.Services.AddScoped<FinanceService>();
    builder.Services.AddScoped<UserServices>();
    builder.Services.AddScoped<PasswordHashingService>();



    builder.Services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = HttpLoggingFields.All;
    });

    var app = builder.Build();





    // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    app.UseSwagger();
    app.UseSwaggerUI();
    // }


    app.UseCors();

    app.UseHttpLogging();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();



}


catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}


finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}