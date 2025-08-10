using MovieLibrary.Client.Services;
using Azure.Identity;
using Microsoft.Azure.AppConfiguration.AspNetCore;
using Microsoft.Extensions.Options;
using MovieLibrary.Client.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient(); // connect to backend
builder.Services.AddHttpClient<MovieService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5196/");
});

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var settings = config.Build();
    var env = context.HostingEnvironment;

    var endpoint = settings["AppConfig:Endpoint"];

    if (env.IsDevelopment())
    {
        var connectionString = settings["AppConfig:ConnectionString"];
        if (!string.IsNullOrEmpty(connectionString))
        {
            config.AddAzureAppConfiguration(connectionString);
        }
    }
    else
    {
        config.AddAzureAppConfiguration(options =>
        {
            options.Connect(new Uri(endpoint), new DefaultAzureCredential())
                   .Select("*", env.EnvironmentName);
        });
    }
});

builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<TokenService>();
builder.Services.Configure<AzureAdOptions>(builder.Configuration.GetSection("AzureAd"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();