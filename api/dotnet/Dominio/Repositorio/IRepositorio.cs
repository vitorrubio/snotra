using System.Linq.Expressions;

public interface IRepositorio<T> where T : new()
{
   T? ObterPorId(int id); 

   IQueryable<T> ObterTodos(params Expression<Func<T, object?>>[] includes);


   
}