using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AcmeCorp.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AcmeCorp.Domain.Repository;
using AcmeCorp.Services.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AcmeCorpAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AcmeCorpAPIContext") ?? throw new InvalidOperationException("Connection string 'AcmeCorpAPIContext' not found.")));

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddBearerToken(options =>
{
    options.BearerTokenExpiration = TimeSpan.FromMinutes(60);
});

//builder.Services.AddScoped<IContactInfoRepository, ContactInfoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Acme Challange API",
        Description = "A web API solution for a tech interview",
        TermsOfService = new Uri("https://something.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Developer",
            Url = new Uri("https://something.com/devcontact")
        }
    });

    var security = new Dictionary<string, IEnumerable<string>>
        {
            {"Bearer", new string[0]}
        };

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

