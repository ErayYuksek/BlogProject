using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant�s� ayar� (Connection string'inizi appsettings.json'dan okuyun)
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity ayarlar� (AppUser ve IdentityRole ile)
//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<DbContext>()
//    .AddDefaultTokenProviders();

// Kullan�c� i�lemleri i�in gerekli servisler
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<SignInManager<AppUser>>();

// Session ayarlar�
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session zaman a��m�
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Cookie tabanl� kimlik do�rulama
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/AccessDenied";
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hata sayfalar� i�in �zel y�nlendirme
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
