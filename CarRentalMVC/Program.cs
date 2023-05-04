﻿using CarRentalMVC.Abstraction;
using CarRentalMVC.DAL;
using CarRentalMVC.Models;
using CarRentalMVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
//    builder.Configuration.GetConnectionString("DefaultConnection"),
//    new MySqlServerVersion(new Version(8, 0, 23)) // do�ru ServerVersion degeri

//));
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseRepository<Car>, BaseRepository<Car>>();

builder.Services.AddIdentity<Customer, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
    opt.User.RequireUniqueEmail = true;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}"

          );

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Cars}/{action=Index}/{id?}"

          );




app.Run();
