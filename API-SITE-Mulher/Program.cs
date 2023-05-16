using API_SITE_Mulher.Business;
using API_SITE_Mulher.Business.Implementations;
using API_SITE_Mulher.Configuration;
using API_SITE_Mulher.Data.Converter.Implementations;
using API_SITE_Mulher.Data.FillingEntities;
using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;
using API_SITE_Mulher.Services;
using API_SITE_Mulher.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddApiVersioning();

var connectionString = "Server=containers-us-west-184.railway.app;DataBase=railway;Uid=root;Pwd=Gh9iFxPucvqrVjuT3S3q;port=5512";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<MySQLContext>(
    DbContextOptions => DbContextOptions
    .UseMySql(connectionString, serverVersion)
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);

TokenConfiguration tokenConfigurations = new TokenConfiguration();

tokenConfigurations.Audience = "ExempleAudience";
tokenConfigurations.Issuer = "ExempleIssuer";
tokenConfigurations.Minutes = 60;
tokenConfigurations.Secret = "MY_SUPER_SECRET_KEY";
tokenConfigurations.DaysToExpiry = 7;

builder.Services.AddSingleton(tokenConfigurations);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfigurations.Issuer,
        ValidAudience = tokenConfigurations.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;

    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
}).AddXmlSerializerFormatters();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api-nao-se-cale-mulher",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Api-nao-se-cale-mulher",
            Url = new Uri("https://github.com/arthurcant/Nao-Se-Cale-Mulher")
        }
    });
});

builder.Services.AddScoped<ICategoriasBusiness, CategoriasBusinessImplementation>();
builder.Services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
builder.Services.AddScoped<IPosteresBusiness, PosteresBusinessImplementation>();

builder.Services.AddScoped<UsuarioConverter>();
builder.Services.AddScoped<CategoriaConverter>();
builder.Services.AddScoped<PosterConverter>();
builder.Services.AddScoped<FillingEntity>();

builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddScoped<IPosteresRepository, PosteresRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "REST API's From 0 to Azure with ASP.NET Core 5 and Docker - v1");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute("DefaultApi", "{controller=swagger}/index");
});

app.MapControllers();

app.Run();
