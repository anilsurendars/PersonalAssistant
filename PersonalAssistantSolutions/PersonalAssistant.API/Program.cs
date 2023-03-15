using Microsoft.EntityFrameworkCore;
using PersonalAssistant.Models.OptionModels;
using PersonalAssistant.Service;
using PersonalAssistant.Utilities;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PADatabaseConnection");

var configOption = new ConfigOption()
{
    ConnectionString = connectionString,
};

AddServices(builder, configOption);

builder.Host.UseSerilog((context, logConfig) =>
{
    logConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddServices(WebApplicationBuilder builder, ConfigOption configOption)
{
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.RegisterUtilityComponents(configOption);
    builder.Services.RegisterServiceComponents(configOption);

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
    });
}