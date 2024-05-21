using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blazored.Toast;
using Blazored.Modal;
using Frontend.Data;
using Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient<ISubLevelsService, SubLevelsService>(client => client.BaseAddress = new Uri("https://localhost:7193"));
builder.Services.AddHttpClient<ISchoolarLevelsService, SchoolarLevelsService>(client => client.BaseAddress = new Uri("https://localhost:7193"));
builder.Services.AddHttpClient<IStudentsService, StudentsService>(client => client.BaseAddress = new Uri("https://localhost:7193"));

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();

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

app.Run();
