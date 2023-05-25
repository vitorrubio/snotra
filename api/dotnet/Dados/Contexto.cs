using Microsoft.EntityFrameworkCore;
using SnotraApiDotNet.Dados.Modelo;

namespace SnotraApiDotNet.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<NotaModelo> Notas => Set<NotaModelo>();
    }
}
