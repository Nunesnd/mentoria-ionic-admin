using Microsoft.EntityFrameworkCore;
using adminMeuApp.Models.Dominio.Entidades;
using Newtonsoft.Json.Linq;

namespace adminMeuApp.Models.Infraestrutura.Database
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options) { }

        public BancoContexto(){}
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseSqlServer(jAppSettings["ConnectionStrings"]["MinhaConexao"].ToString());
        }
        
        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Pagina> Paginas { get; set; }

    }
}