using Microsoft.EntityFrameworkCore;
using Teste.Entities;

namespace Teste.Data.DbContexts
{
    public class AppMySqlDbContext : DbContext
    {
        public AppMySqlDbContext(DbContextOptions optios) : base(optios) { }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<ContatosTipos> ContatosTipos { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
    }
}
