using System.Data;
using System.IdentityModel.Tokens.Jwt;
using HM4_M6.Data;
using HM4_M6.Interface;
using HM4_M6.Servises;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:5001";

        options.ClientId = "web";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        options.Scope.Add("verification");
        options.ClaimActions.MapJsonKey("email_verified", "email_verified");

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.GetClaimsFromUserInfoEndpoint = true;

        options.SaveTokens = true;
    });
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddTransient<ITimer, TimerServise>();
builder.Services.AddSingleton<IDataCars, DataCars>();
builder.Services.AddTransient<ICarSevises, CarServises>();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
