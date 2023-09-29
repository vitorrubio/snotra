using Microsoft.EntityFrameworkCore;
using SnotraApiDotNet.Dominio.Entidades;

namespace SnotraApiDotNet.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Nota> Notas => Set<Nota>();
        public DbSet<Link> Links => Set<Link>();

        public DbSet<Lista> Listas => Set<Lista>();
    }
}
