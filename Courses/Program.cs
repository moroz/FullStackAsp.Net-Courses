using System.Globalization;
using Courses;
using Courses.Middleware;
using Courses.Models;
using Courses.Repository;
using Courses.Services;
using FluentValidation;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Vite.AspNetCore;
using TailwindMerge.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserTokenRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"), AppDbContext.MapEnums)
        .UseSnakeCaseNamingConvention();
});


var supportedCultures = new[] { "en-GB", "pl-PL" };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-GB");
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddViteServices();
builder.Services.AddTailwindMerge();

ValidatorOptions.Global.LanguageManager = new ValidatorLanguageManager();

var app = builder.Build();

app.UseRequestLocalization();

if (args.Contains("seed"))
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await Seeds.Run(db);
    }

    Environment.Exit(0);
}

if (app.Environment.IsProduction())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();

    // app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseViteDevelopmentServer();
}

app.UseMiddleware<AuthenticationMiddleware>();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapStaticAssets();

app.Run();

public partial class Program
{
}