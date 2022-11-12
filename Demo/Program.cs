using Demo.Entity;
using Demo.Repo;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IrepoCar, repoCar>();
builder.Services.AddTransient<IrepoLogin, repoLogin>();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<CarDetailsDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("BloggingDatabase")));

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
    pattern: "{controller=login}/{action=Index}/{id?}");

app.Run();
