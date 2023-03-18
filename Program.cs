using adminMeuApp.Models.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
