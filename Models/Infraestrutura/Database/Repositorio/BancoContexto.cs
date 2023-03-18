using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace adminMeuApp.Models.Infraestrutura.Database
{
    public class BancoContexto: DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options): base(options){}

        public BancoContexto(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseSqlServer(jAppSettings["MinhaConexao"].ToString());
        }
    }
}