using NC.SPENDCS.Models;
using Microsoft.AspNetCore.Hosting.Server;
using NC.SPENDCS.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IService_API, Service_API>();
builder.Services.AddScoped<ICatGastosService, CatGastosService>();
builder.Services.AddScoped<IAdmonService, AdmonService>();
builder.Services.AddScoped<IAsignService, AsignService>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
//CServer.Initialize(builder.Environment, builder.Configuration);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();