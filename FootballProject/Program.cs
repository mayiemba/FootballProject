using FootballProject;
using FootballProject.DbContexts;
using FootballProject.Repositories;
using FootballProject.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;


Log.Logger = new LoggerConfiguration() 
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/teamInfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
/*builder.Logging.ClearProviders();
builder.Logging.AddConsole();*/
builder.Services.AddDbContext<TeamInfoContext>(DbContextOptions
    => DbContextOptions.UseNpgsql(builder.Configuration["ConnectionStrings:TeamInfoDBConnectionString"]));

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

builder.Services.AddProblemDetails();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService,CloudMailService>();
#endif

builder.Services.AddSingleton<TeamsDataStore>();
builder.Services.AddScoped<TeamInfoContext>();
builder.Services.AddScoped<TeamRepository>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();


app.Run();