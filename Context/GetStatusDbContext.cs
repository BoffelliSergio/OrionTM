using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Models;
using System.Xml;

namespace OrionTM_Web.Context
{
    public class GetStatusDBContext : DbContext
    {

        public GetStatusDBContext(DbContextOptions<GetStatusDBContext> options)
        : base(options)
        {
        }

        public DbSet<StatusTerminal> StatusTerminal { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTerminal>()
                .HasKey(e => e.TerminalId);
        }



        // Chama uma stored procedure que retorna uma lista de entidades
        public List<StatusTerminal> GetMyEntitiesFromStoredProcedure()
        {
            return StatusTerminal.FromSqlRaw("EXECUTE dbo.GetStatusTerminais").ToList();
        }



    }
}
