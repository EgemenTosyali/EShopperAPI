using EShopperAPI.Application.Validators;
using EShopperAPI.Infrastructure;
using EShopperAPI.Infrastructure.Filters;
using EShopperAPI.Infrastructure.Services.Storage.Azure;
using EShopperAPI.Infrastructure.Services.Storage.Google_Cloud;
using EShopperAPI.Infrastructure.Services.Storage.Local;
using EShopperAPI.Persistence;
using EShopperAPI.Persistence.Contexts;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddPersistenceServices();
        builder.Services.AddInfrastructureServices();

        builder.Services.AddStorage<LocalStorage>();
        //builder.Services.AddStorage<AzureStorage>();
        //builder.Services.AddStorage<GoogleCloudStorage>();

        builder.Services.AddCors(options => options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("https://localhost:7777","http://localhost:7777")
                .AllowAnyHeader().AllowAnyMethod();
            }));
        builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateProduct_Validator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //using (var scope = app.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<EShopperAPIDbContext>();
        //    db.Database.Migrate();
        //}

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}