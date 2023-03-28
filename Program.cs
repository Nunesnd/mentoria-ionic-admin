using adminMeuApp.Models.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("MinhaConexao");
builder.Services.AddDbContext<BancoContexto>(options => options.UseSqlServer(connString));

/*
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
    optionsBuilder.UseSqlServer(jAppSettings["MinhaConexao"].ToString());  
}
*/

builder.Services.AddDbContext<BancoContexto>(options => options.UseSqlServer("MinhaConexao"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession();

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();