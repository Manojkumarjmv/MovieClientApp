using MovieLibrary.Client.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient(); // connect to backend
builder.Services.AddHttpClient<MovieService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5196/");
});
builder.Services.AddScoped<MovieService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();