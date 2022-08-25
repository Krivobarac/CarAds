using CarAds.Managers;
using CarAds.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CarAds.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using CarAds;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityCarAdsContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityCarAdsContextConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<CarAdsContext>(option => option.UseSqlServer(CarAdsContext.GetConfiguration().GetConnectionString("PrimaryConnectionString")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityCarAdsContext>();
builder.Services.AddDbContext<IdentityCarAdsContext>(option => option.UseSqlServer(IdentityCarAdsContext.GetConfiguration().GetConnectionString("IdentityCarAdsContextConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddLocalization(opts => opts.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews().
    AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
        AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
        });

builder.Services.AddTransient<CarManager>();
builder.Services.AddTransient<ImageManager>();

IdentityCarAdsContext.CreateIdentityUserAndRoleSeedAsync();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed
using var scope = app.Services.CreateScope();
CarAdsContext carAdsContext = scope.ServiceProvider.GetRequiredService<CarAdsContext>();
carAdsContext.Database.Migrate();
IdentityCarAdsContext identityCarAdsContext = scope.ServiceProvider.GetRequiredService<IdentityCarAdsContext>();
identityCarAdsContext.Database.Migrate();

// Localization options
var supportedCultures = new[] { "en", "de-DE", "sr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/Home/Error404/{0}");
app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

