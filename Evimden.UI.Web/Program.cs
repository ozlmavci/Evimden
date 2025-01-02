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
// Identity hizmetlerini ekleyin ve parola gereksinimlerini yapýlandýrýn
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

builder.Services.AddMvc();builder.Services.AddAuthentication(      CookieAuthenticationDefaults.AuthenticationScheme)    .AddCookie(x =>    {        x.LoginPath = "/Login/Index/";        x.LogoutPath = "/Logout/Index/";        x.AccessDeniedPath = "/Home/AccessDenied/"; // Eriþim engellendiðinde yönlendirilecek sayfa
        x.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie'nin süresi. 30 dakika sonra cookie silinir
        x.SlidingExpiration = true; // Kullanýcý siteyi kullanmaya devam ettiði sürece cookie'nin süresi uzar

        x.Cookie.Name = "EvimdenCookie";

        //   x.DataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(@"\wwwroot\Identity")); // Cookie'yi korumak için kullanýlan bir anahtar oluþturulur
        //  x.Cookie.HttpOnly = true; // Cookie'ye sadece HTTP üzerinden eriþilebilir
        //  x.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Cookie'nin HTTPS üzerinden gönderilmesi saðlanýr
        //  x.Cookie.SameSite = SameSiteMode.Strict; // Cookie'nin sadece ayný domain üzerinden gönderilmesi saðlanýr
        //  x.CookieManager = new ChunkingCookieManager(); // Cookie'nin boyutu büyük olduðunda parçalara bölünerek gönderilmesini saðlar
        //  x.SessionStore = new MemoryCacheTicketStore(); // Cookie'nin session üzerinde saklanmasýný saðlar
        x.Events = new CookieAuthenticationEvents        {            OnRedirectToLogin = context =>            {                context.Response.Redirect("/Login/Index/");                return Task.CompletedTask;            }// Kullanýcý yetkisiz bir sayfaya eriþmeye çalýþtýðýnda yönlendirilecek sayfa
        };    });var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();}app.UseHttpsRedirection();app.UseStaticFiles();app.UseRouting();app.UseAuthorization();app.MapControllerRoute(    name: "default",    pattern: "{controller=Home}/{action=Index}/{id?}");app.Run();