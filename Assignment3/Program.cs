var builder = WebApplication.CreateBuilder(args);
var connstring = builder.Configuration["ConnectionStrings:DB_BlogPosts"];

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();