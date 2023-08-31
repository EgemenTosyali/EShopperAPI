using Azure.Storage.Blobs.Models;
using EShopperAPI.API.Configurations.Builder;
using EShopperAPI.API.Middlewares;
using EShopperAPI.Application;
using EShopperAPI.Application.Validators;
using EShopperAPI.Infrastructure;
using EShopperAPI.Infrastructure.Filters;
using EShopperAPI.Infrastructure.Services.Storage.Google_Cloud;
using EShopperAPI.Persistence;
using EShopperAPI.Persistence.Contexts;
using EShopperAPI.SignalR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using System.Security.Claims;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddPersistenceServices();
        builder.Services.AddInfrastructureServices();
        builder.Services.AddAplicationServices();
        builder.Services.AddSignalRServices();

        //builder.Services.AddStorage<AzureStorage>();
        builder.Services.AddStorage<GoogleCloudStorage>();

        //builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>{policy.WithOrigins("https://localhost:7777", "http://localhost:7777").AllowAnyHeader().AllowAnyMethod().AllowCredentials();}));

        builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials()));

        builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateProduct_Validator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        Logger log = LoggerConfig.getLogger();

        builder.Host.UseSerilog(log);

        builder.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.RequestHeaders.Add("sec-ch-ua");
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin", o =>
        {
            o.TokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidAudience = builder.Configuration["TokenAudience"],
                ValidIssuer = builder.Configuration["TokenIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSecurityKey"])),
                LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
                NameClaimType = ClaimTypes.Name
            };
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<EShopperAPIDbContext>();
            if (!db.Database.EnsureCreated())
                db.Database.Migrate();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

        app.UseStaticFiles();

        app.UseSerilogRequestLogging();
        app.UseHttpLogging();

        app.UseCors();
        //app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.Use(async (context, next) =>
        {
            var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
            LogContext.PushProperty("user_name", username);
            await next();
        });

        app.MapControllers();

        app.MapHubs();

        app.Run();
    }
}