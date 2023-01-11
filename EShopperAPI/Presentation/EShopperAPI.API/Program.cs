using EShopperAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy =>
    {
        policy.WithOrigins("https://localhost:7027", "http://localhost:4200")
        .AllowAnyHeader().AllowAnyMethod();
    }));
builder.Services.AddPersistenceServices(); //Service Registrations
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
