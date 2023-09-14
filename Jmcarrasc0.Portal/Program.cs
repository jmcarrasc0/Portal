
using FluentValidation;
using Jmcarrasc0.Blazor.Loading;
using Jmcarrasc0.Portal.Data;
using Jmcarrasc0.Portal.Models;
using Jmcarrasc0.Portal.Models.Validations;
using Jmcarrasc0.Portal.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PortalContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:Portal"]));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication(
    o =>
    {
        o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(
    r =>
    {
        r.SlidingExpiration = true;
        r.Cookie.Name = "jmcarrasc0.Session";
        r.LoginPath = new PathString("/Account/Login");
        r.LogoutPath = new PathString("/Account/LogOff");
        r.AccessDeniedPath = new PathString("/Account/CallUnauthorized");
        r.SlidingExpiration = true;
        r.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        r.Cookie.SameSite = SameSiteMode.None;
    });


builder.Services.AddSignalR(e => { e.MaximumReceiveMessageSize = 102400000; });

builder.Services.AddScoped<Mensajeria, Mensajeria>();
builder.Services.AddScoped<LoadingServices>();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });


builder.Services.AddTransient<IValidator<Usuarios>, UsuariosValidator>();
builder.Services.AddTransient<IValidator<UsuarioPass>, UsuarioPassValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
