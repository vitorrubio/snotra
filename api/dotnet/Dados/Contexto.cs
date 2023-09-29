using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using SnotraApiDotNet.Dominio.Entidades;

namespace SnotraApiDotNet.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Nota> Notas => Set<Nota>();
        public DbSet<Link> Links => Set<Link>();

        public DbSet<Lista> Listas => Set<Lista>();


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Conventions.Add(_ => new MaxStringLengthConvention());

            base.ConfigureConventions(configurationBuilder);

        }
    }


    public class MaxStringLengthConvention : IModelFinalizingConvention
    {
        public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var property in modelBuilder.Metadata.GetEntityTypes()
                         .SelectMany(
                             entityType => entityType.GetDeclaredProperties()
                                 .Where(
                                     property => property.ClrType == typeof(string))))
            {
                property.Builder.HasMaxLength(40);
            }
        }
    }
}
