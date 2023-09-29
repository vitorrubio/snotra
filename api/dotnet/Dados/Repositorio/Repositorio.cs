using System.Linq.Expressions;
using SnotraApiDotNet.Dados;
using SnotraApiDotNet.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

public class Repositorio<T> : IRepositorio<T> where T : class, new()
{
    private readonly Contexto _contexto;

    public Repositorio(Contexto ctx)
    {
        _contexto = ctx;
    }


    public virtual T? ObterPorId(int id)
    {
        return _contexto.Set<T>().Find(id);
    }

    public virtual IQueryable<T> ObterTodos(params Expression<Func<T, object?>>[] includes)
    {
        return includes
            .Aggregate<Expression<Func<T, object?>>, IQueryable<T>>
            (_contexto.Set<T>(), (current, expression) => current.Include(expression));
    }
}

