using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using adminMeuApp.Models.Dominio.Entidades;

namespace adminMeuApp.Models.Infraestrutura.Database
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options) { }
        public DbSet<Adminstrador> Administradores { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseSqlServer(jAppSettings["MinhaConexao"].ToString());  
        }
        */
    }
}