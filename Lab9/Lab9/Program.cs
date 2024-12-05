using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab9.Data;
using Lab9.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:Lab9ContextConnection"];

builder.Services.AddDbContext<Lab9Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Lab9User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Lab9Context>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
