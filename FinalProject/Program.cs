using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:FinalProjectContextConnection"];

builder.Services.AddDbContext<FinalProjectContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PlannerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FinalProjectContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

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
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
