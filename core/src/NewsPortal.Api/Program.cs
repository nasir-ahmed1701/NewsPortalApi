using NewsPortal.Api.Helpers;
using NewsPortal.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommonServices();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext(builder.Configuration);

var corsConfiguration = builder.Configuration.GetSection("Cors").Get<CorsConfiguration>();
builder.Services.AddCorsConfiguration(corsConfiguration!);

builder.Services.AddControllers();

builder.Services.AddFluentValidators();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(corsConfiguration!.PolicyName);

app.MapControllers();

app.Run();
