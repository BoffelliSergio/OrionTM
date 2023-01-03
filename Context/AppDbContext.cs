using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Models;

namespace OrionTM_Web.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>

    {

        public AppDbContext(DbContextOptions<AppDbContext> options  ) : base( options )
        {
        }

      
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Terminal> Terminal { get; set; }
        public DbSet<Configuracao> Configuracao { get; set; }
        public DbSet<LogAuditoria> LogAuditoria { get; set; }
        public DbSet<ListaEnvio> ListaEnvio { get; set; }
        public DbSet<DetalheListaEnvio> DetalheListaEnvio { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Comando> Comando { get; set; }
        public DbSet<Pacote> Pacote { get; set; }
        public DbSet<FilaTasks> FilaTasks { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<tst_SP> tst_SP { get; set; }


    }
}
