using Microsoft.AspNetCore.Identity;
using PracticaCurso.DAL;
using PracticaCurso.DAL.Interfaces;
using PracticaCurso.DAL.Repositorios;
using PracticaCurso.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioCuentas, RepositorioCuentas>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddTransient<IUserStore<UsuarioViewModel>, UsuarioStore>();
builder.Services.AddIdentityCore<UsuarioViewModel>();
builder.Services.AddTransient<SignInManager<UsuarioViewModel>>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
}).AddCookie(IdentityConstants.ApplicationScheme);

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
