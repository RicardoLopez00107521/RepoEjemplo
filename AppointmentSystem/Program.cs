using AppointmentSystem.Data;
using AppointmentSystem.Repositories;
using AppointmentSystem.Repositories.Interfaces;
using AppointmentSystem.Services;
using AppointmentSystem.Services.Interfaces;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Configuration.AddEnvironmentVariables();

var connectionSting = builder.Configuration.GetConnectionString("AppointmentSystemDbContext")
                    ?? throw new InvalidOperationException("Connection string AppointmentSystemDbContext not found.");

builder.Services.AddDbContext<AppointmentSystemDbContext>(options =>
    options.UseSqlite(connectionSting));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
