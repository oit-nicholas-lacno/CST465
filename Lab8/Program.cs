using Lab8.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IImageRepository, CachingDbImageRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();
builder.Services.AddOutputCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseResponseCaching();
app.UseOutputCache();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();
