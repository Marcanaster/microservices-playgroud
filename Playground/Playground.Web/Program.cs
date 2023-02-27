using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Logging;
using Playground.Web.Services;
using Playground.Web.Services.IService;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = builder.Configuration["ServicesUrls:IdentityServer"];
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "geek_shopping";
    options.ClientSecret = "my_superSecret";
    options.ResponseType = "code";
    options.ClaimActions.MapJsonKey("role", "role", "role");
    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add("geek_shopping");
    options.SaveTokens = true;
});

builder.Services.AddHttpClient<IProductService, ProductService>(c => c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:ProductAPI"]));

builder.Services.AddHttpClient<ICartService, CartService>(c => c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:CartAPI"]));

builder.Services.AddHttpClient<ICouponService, CouponService>(c => c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:CouponAPI"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
IdentityModelEventSource.ShowPII = true;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
