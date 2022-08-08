using EmployeesArrivalTracker.BlazorServer.Data;
using EmployeesArrivalTracker.BlazorServer.Data;
using EmployeesArrivalTracker.BlazorServer.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ArrivalService>();


builder.Services.AddDbContext<EmployeesArrivalDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllers();

app.Run();


// scaffold the dbcontext:
// dotnet ef dbcontext scaffold "server=localhost;uid=root;pwd=Parola1;database=employees_arrival" Pomelo.EntityFrameworkCore.MySql -o EmployeesArrival -f -p EmployeesArrivalTracker.BlazorServer