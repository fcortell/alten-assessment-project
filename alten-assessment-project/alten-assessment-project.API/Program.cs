
using alten_assessment_project.API.Setup;
using alten_assessment_project.Infrastructure;
using alten_assessment_project.Application;
using alten_assessment_project.API.Middleware;
using alten_assessment_project.API.Middleware.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
    //.AddUserSecrets<Program>()
    .AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAuthentication("ApiKey").AddScheme<ApiKeyAuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", opts => opts.ApiKey = builder.Configuration.GetValue<string>("AllowedApiKeys")
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();


app.MapControllers();
app.EnsurePersistenceIsReady();

Configuration = app.Configuration;

app.Run();

public partial class Program
{
    public static IConfiguration? Configuration { get; private set; }
    public static bool EnableBackgroundJobs = true;
}