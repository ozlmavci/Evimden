using Evimden.BusinessLayer.DependencyInjection;using Evimden.CoreLayer.Common;using Evimden.CoreLayer.Concrete.IdentityEntities;using Evimden.DataAccessLayer.Concrete;using Google;using Microsoft.AspNetCore.Authentication.Cookies;using Microsoft.AspNetCore.Components.Authorization;using Microsoft.AspNetCore.Identity;using Microsoft.EntityFrameworkCore;var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());


// DB Context
builder.Services.AddDbContext<EvimdenDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add business layer services
builder.Services.AddBusinessLayerServices(builder.Configuration);

//Cloud Configuration
builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
// Identity hizmetlerini ekleyin ve parola gereksinimlerini yap�land�r�n
builder.Services.AddIdentity<CustomUser, CustomRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<EvimdenDbContext>()
.AddDefaultTokenProviders();


//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));
//});

builder.Services.AddMvc();builder.Services.AddAuthentication(      CookieAuthenticationDefaults.AuthenticationScheme)    .AddCookie(x =>    {        x.LoginPath = "/Login/Index/";        x.LogoutPath = "/Logout/Index/";        x.AccessDeniedPath = "/Home/AccessDenied/"; // Eri�im engellendi�inde y�nlendirilecek sayfa
        x.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie'nin s�resi. 30 dakika sonra cookie silinir
        x.SlidingExpiration = true; // Kullan�c� siteyi kullanmaya devam etti�i s�rece cookie'nin s�resi uzar

        x.Cookie.Name = "EvimdenCookie";

        //   x.DataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(@"\wwwroot\Identity")); // Cookie'yi korumak i�in kullan�lan bir anahtar olu�turulur
        //  x.Cookie.HttpOnly = true; // Cookie'ye sadece HTTP �zerinden eri�ilebilir
        //  x.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Cookie'nin HTTPS �zerinden g�nderilmesi sa�lan�r
        //  x.Cookie.SameSite = SameSiteMode.Strict; // Cookie'nin sadece ayn� domain �zerinden g�nderilmesi sa�lan�r
        //  x.CookieManager = new ChunkingCookieManager(); // Cookie'nin boyutu b�y�k oldu�unda par�alara b�l�nerek g�nderilmesini sa�lar
        //  x.SessionStore = new MemoryCacheTicketStore(); // Cookie'nin session �zerinde saklanmas�n� sa�lar
        x.Events = new CookieAuthenticationEvents        {            OnRedirectToLogin = context =>            {                context.Response.Redirect("/Login/Index/");                return Task.CompletedTask;            }// Kullan�c� yetkisiz bir sayfaya eri�meye �al��t���nda y�nlendirilecek sayfa
        };    });var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();}app.UseHttpsRedirection();app.UseStaticFiles();app.UseRouting();app.UseAuthorization();app.MapControllerRoute(    name: "default",    pattern: "{controller=Home}/{action=Index}/{id?}");app.Run();