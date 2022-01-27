using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(
    b => b.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
));

// builder.Services.Configure<ForwardedHeadersOptions>(options =>
// {
//     options.ForwardedHeaders =
//         ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
//
//     options.KnownProxies.Add(IPAddress.Parse("88.208.199.31"));
// });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(logging => {
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("My-Request-Header");
    logging.ResponseHeaders.Add("My-Response-Headers");
    logging.MediaTypeOptions.AddText("application/javascript");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//    app.UseSwagger();
//    app.UseSwaggerUI();
// }

app.UseCors();

// app.UseForwardedHeaders();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
