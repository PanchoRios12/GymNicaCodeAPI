using GymNicaCodeAPI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Main(args);

app.Run();


static void Main(string[] args)
{
    CreateHostBuilder(args).Build().Run();
}

static IHostBuilder CreateHostBuilder(string[] args) =>
   Host.CreateDefaultBuilder(args)
       .ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseStartup<Startup>();
       });

static IWebHostBuilder CreateDefaultBuilder(string[] args)
{
    var builder = new WebHostBuilder();

    if (string.IsNullOrEmpty(builder.GetSetting(WebHostDefaults.ContentRootKey)))
    {
        builder.UseContentRoot(Directory.GetCurrentDirectory());
    }
    if (args != null)
    {
        builder.UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build());
    }

    builder.ConfigureAppConfiguration((hostingContext, config) =>
    {
        var env = hostingContext.HostingEnvironment;

        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        if (env.IsDevelopment())
        {
            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            if (appAssembly != null)
            {
                config.AddUserSecrets(appAssembly, optional: true);
            }
        }

        config.AddEnvironmentVariables();

        if (args != null)
        {
            config.AddCommandLine(args);
        }
    });
    builder.UseStartup<Startup>();
    return builder;
}